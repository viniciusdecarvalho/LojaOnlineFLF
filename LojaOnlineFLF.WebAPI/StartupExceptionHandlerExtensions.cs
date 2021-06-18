using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI
{
    internal static class StartupExceptionHandlerExtensions
    {        
        public static IApplicationBuilder UseExceptionHandlerConfig(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();

                    if (feature != null)
                    {
                        var exception = feature.Error;

                        var problemDetails = new ProblemDetails
                        {
                            Title = exception.Message,
                            Status = StatusCodes.Status400BadRequest,
                            Detail = exception.Messages(),
                            Instance = context.Request.Path
                        };

                        var json = JsonConvert.SerializeObject(problemDetails);

                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = K.MediaTypes.AplicationProblemJson;
                        await context.Response.WriteAsync(json);
                    }
                });
            });

            return app;
        }

        public static string Messages(this Exception exception)
        {
            StringBuilder builder = new StringBuilder();

            var ex = exception?.InnerException;

            while (ex != null)
            {
                builder.Insert(0, ex.Message).AppendLine();

                ex = ex.InnerException;
            }

            return builder.ToString();
        }
    }
}
