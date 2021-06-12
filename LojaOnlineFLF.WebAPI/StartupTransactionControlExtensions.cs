using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using LojaOnlineFLF.DataModel.Providers;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace LojaOnlineFLF.WebAPI
{
    internal static class StartupTransactionControlExtensions
    {
        public static IApplicationBuilder UseTransactionControlMiddleware<TContext>(this IApplicationBuilder app) where TContext: DbContext
        {
            app.UseMiddleware<TransactionControlMiddleware<TContext>>();

            return app;
        }

        public static IServiceCollection AddTransactionControlMiddleware<TContext>(this IServiceCollection services) where TContext: DbContext
        {
            services
                .AddTransient<TransactionControlMiddleware<TContext>>(provider => {
                    var context = provider.GetService<TContext>();
                    return new TransactionControlMiddleware<TContext>(context);
                });

            return services;
        }
    }
}
