using FluentValidation.AspNetCore;

namespace Tekton.ECommerce.Api.Extensions
{
    public static class CustomExtensionFluentValidation
    {
        public static IServiceCollection AddFluent(this IServiceCollection Services)
        {
            Services.AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<Startup>();
                configuration.DisableDataAnnotationsValidation = true;
                configuration.ImplicitlyValidateChildProperties = true;
            });
            return Services;
        }
    }
}