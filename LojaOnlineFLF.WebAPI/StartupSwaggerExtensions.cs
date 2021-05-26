using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupSwaggerExtensions
    {
        private const string Bearer = JwtBearerDefaults.AuthenticationScheme;

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LojaOnlineFLF v1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }

        public static IServiceCollection AddSwaggerGenConfig(this IServiceCollection services)
        {
            var xmlDoc = Path.Combine(System.AppContext.BaseDirectory, "LojaOnlineFLF.xml");
            services.AddSwaggerGen(c => {

                c.CustomSchemaIds(x => {
                    var annotation = x.GetCustomAttributes(typeof(ResultNameAttribute), false)
                                      .Cast<ResultNameAttribute>()
                                      .FirstOrDefault();

                    return annotation?.NameAs ?? x.GetType().Name;
                });

                c.AddSecurityDefinition(Bearer, new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization, cabecalho usando o Bearer. 
                      Informe 'Bearer'([espaço]) e então seu token na caixa de texto.
                      Exemplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Bearer
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Bearer
                            },
                            Scheme = Bearer,
                            Name = Bearer,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LojaOnlineFLF", Version = "v1" });
                if (File.Exists(xmlDoc))
                    c.IncludeXmlComments(xmlDoc);
            });

            return services;
        }
    }
}
