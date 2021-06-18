using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LojaOnlineFLF.WebAPI
{
    internal static class StartupResponseCompressionExtensions
    {
        public static IApplicationBuilder UseCompressionConfig(this IApplicationBuilder app)
        {
            app.UseResponseCompression();

            return app;
        }

        public static IServiceCollection AddCompressionConfig(this IServiceCollection services)
        {
            services.AddResponseCompression(config =>
            {
                config.Providers.Add<GzipCompressionProvider>();
            })
            .Configure<GzipCompressionProviderOptions>(opt =>
            {
                opt.Level = System.IO.Compression.CompressionLevel.Fastest;
            });

            return services;
        }
    }
}
