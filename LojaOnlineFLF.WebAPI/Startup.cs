using System;
using FluentValidation.AspNetCore;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using LojaOnlineFLF.WebAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddControllers(options => {
                options.Filters.Add(typeof(TransactionFilter));
                options.Filters.Add(typeof(ErrorFilter));
            })
            .AddFluentValidation();

            services.AddDbContext<LojaEFContext>(opt => {
                string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ??
                                          Configuration.GetConnectionString("lojaonline");

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
            services.AddAutoMapperConfig();
            services.AddBearerAuthentication();            
            services.AddSwaggerGenConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfig();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().WithMethods("GET", "POST", "OPTIONS", "DELETE", "PUT"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
