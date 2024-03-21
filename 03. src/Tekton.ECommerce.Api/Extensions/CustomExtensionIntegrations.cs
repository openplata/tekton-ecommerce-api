
using Tekton.ECommerce.Api.DistributedCache;

namespace Tekton.ECommerce.Api.Extensions
{
    public static class CustomExtensionIntegrations
    {
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection Services)
        {
            Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();            
            Services.AddScoped<ICacheProviderFactory, CacheProviderFactory>();
            return Services;
        }
    }
}