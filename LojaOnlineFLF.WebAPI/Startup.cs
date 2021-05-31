using System;
using System.Globalization;
using FluentValidation;
using FluentValidation.AspNetCore;
using GlobalExceptionHandler.WebApi;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using LojaOnlineFLF.WebAPI.Filters;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>               
                        builder
                            .WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services
                .AddControllers()
                .AddFluentValidation();

            services.AddDbContext<LojaEFContext>(opt =>
            {
                string connectionString = GetConnectionString();

                opt.UseNpgsql(connectionString);
            });

            services.AddIdentity<Acesso, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<LojaEFContext>();
            
            services.AddDependencyInjectConfig();
            services.AddTransactionControlMiddleware();
            services.AddAutoMapperConfig();
            services.AddBearerAuthentication();            
            services.AddSwaggerGenConfig();
        }

        private string GetConnectionString()
        {
            return
                Environment.GetEnvironmentVariable("DB_CONNECTION") ??
                Configuration.GetConnectionString("lojaonline");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LojaEFContext context)
        {        
            if (env.IsProduction())
            {
                context.Database.Migrate();
            }

            app.UseSwaggerConfig();

            app.UseExceptionHandlerConfig();

            app.UseTransactionControlMiddleware<LojaEFContext>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "POST", "OPTIONS", "DELETE", "PUT"));

            //var supportedCultures = new[] { K.Cultures.Default };
            //var localizationOptions = 
            //    new RequestLocalizationOptions()                
            //        .SetDefaultCulture(K.Cultures.Default)
            //        .AddSupportedCultures(supportedCultures)
            //        .AddSupportedUICultures(supportedCultures);

            //app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        }
    }
}
