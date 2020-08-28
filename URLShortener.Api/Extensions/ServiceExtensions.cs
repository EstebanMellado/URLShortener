using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.Api.Repositories;
using URLShortener.Api.Services;

namespace URLShortener.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            string mongoConnectionString = Configuration.GetConnectionString("MongoConnectionString");
            services.AddTransient<IURLRepository>(s => new URLRepository(mongoConnectionString, "Url", "ShortUrl"));
            services.AddTransient<IURLService, URLService>();
        }
    }
}
