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
    public static class StartupTransactionControlExtensions
    {
        public static IApplicationBuilder UseTransactionControlMiddleware<TContext>(this IApplicationBuilder app) where TContext: DbContext
        {
            app.UseMiddleware<TransactionControlMiddleware<TContext>>();

            return app;
        }

        public static IServiceCollection AddTransactionControlMiddleware(this IServiceCollection services)
        {
            services
                .AddTransient<TransactionControlMiddleware<LojaEFContext>>(provider => {
                    var context = provider.GetService<LojaEFContext>();
                    var logger = provider.GetService<ILogger<TransactionControlMiddleware<LojaEFContext>>>();
                    return new TransactionControlMiddleware<LojaEFContext>(logger, context);
                });

            return services;
        }
    }
}
