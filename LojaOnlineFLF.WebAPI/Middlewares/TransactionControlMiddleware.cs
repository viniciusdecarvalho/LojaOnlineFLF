using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class TransactionControlMiddleware<TContext> : IMiddleware where TContext: DbContext
{
    private readonly ILogger<TransactionControlMiddleware<TContext>> _logger;
    private readonly TContext context;

    public TransactionControlMiddleware(
        ILogger<TransactionControlMiddleware<TContext>> logger,
        TContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        if (CanOpenTransaction(httpContext))
        {
            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync<object, object>(null!, operation: async (ctx, state, cancel) =>
            {
                await using var transaction = await ctx.Database.BeginTransactionAsync();
                await next(httpContext);
                await ctx.SaveChangesAsync();
                await transaction.CommitAsync();

                return null!;
            }, null);
        }
        else
        {
            await next(httpContext);
        }
    }

    //public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    //{        
    //    using var transaction = context.Database.BeginTransaction();
    //    await next(httpContext);
    //    await context.SaveChangesAsync();
    //    await transaction.CommitAsync();
    //}

    private static bool CanOpenTransaction(HttpContext httpContext)
    {
        return true;// !"GET".Equals(httpContext.Request.Method.ToUpper());
    }
}