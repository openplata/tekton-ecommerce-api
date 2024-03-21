﻿using Tekton.ECommerce.Api.Filters;

namespace Tekton.ECommerce.Api.Extensions
{
    public static class CustomExtensionMvc
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection Services)
        {
            Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => $"{y} contiene valores no permitidos.");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) => $"El valor '{x}' no es correcto.");
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => $"El valor '{x}' no es correcto.");
                options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((x) => $"{x} debe ser un número.");
            })
            .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            //Services.AddMvc().AddFluentValidation();

            Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return Services;
        }
    }
}