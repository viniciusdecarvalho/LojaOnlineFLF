using System;
using System.IO;
using FluentValidation;
using GlobalExceptionHandler.WebApi;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services;
using LojaOnlineFLF.WebAPI.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace LojaOnlineFLF.WebAPI
{
    public static class StartupExceptionHandlerExtensions
    {        
        public static IApplicationBuilder UseExceptionHandlerConfig(this IApplicationBuilder app)
        {
            // app.UseGlobalExceptionHandler(x => {
            //     x.ContentType = K.MediaTypes.AplicationJson;
            //     x.ResponseBody(e => {
            //         var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
            //         {
            //             Status = StatusCodes.Status403Forbidden,
            //             Type = "https://example.com/probs/out-of-credit",
            //             Title = "Division by zero...",
            //             Detail = ex.StackTrace,
            //             Instance = HttpContext.Request.Path
            //         };

            //         return JsonConvert.SerializeObject(problemDetails);
            //     });

            //     //x.Map<RecordNotFoundException>().ToStatusCode(StatusCodes.Status404NotFound);
            //     x.Map<Exception>().ToStatusCode(StatusCodes.Status400BadRequest);
            // });

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        
                        var problemDetails = new ProblemDetails
                        {
                            Title = exception.Message,
                            Status = StatusCodes.Status400BadRequest,
                            Detail = exception.ToString(),
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
    }
}
