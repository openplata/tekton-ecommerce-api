using Tekton.ECommerce.Api.DistributedCache;

using Tekton.ECommerce.IApplication.UseCases.Core;
using Tekton.ECommerce.IApplication.UseCases.Security.User;
using Tekton.ECommerce.IApplication.UseCases.Auth;

using Tekton.ECommerce.Application.UseCases.Core;
using Tekton.ECommerce.Application.UseCases.Security;
using Tekton.ECommerce.Application.UseCases.Auth;
using Tekton.ECommerce.Application.UseCases.Category;
using Tekton.ECommerce.Application.UseCases.Product;



namespace Tekton.ECommerce.Api.Core.Infraestructure
{
    public class ServicesAddScoped
    {
        public ServicesAddScoped()
        {
            
        }

        public static void Load(IServiceCollection sevices)
        {
            sevices.AddScoped<ICacheProviderFactory, CacheProviderFactory>();
            sevices.AddScoped<IJWTTokenService, JWTTokenService>();

            sevices.AddScoped<ILoginService, LoginService>();
            sevices.AddScoped<IUserService, UserService>();
            sevices.AddScoped<IStatusService, StatusService>();
            sevices.AddScoped<ICoreService, CoreService>();
            sevices.AddScoped<ICategoryService, CategoryService>();
            sevices.AddScoped<IProductDiscountService, ProductDiscountService>();
            sevices.AddScoped<IProductService, ProductService>();

        }
    }
}