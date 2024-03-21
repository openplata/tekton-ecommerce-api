using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using System.Reflection;
using Tekton.ECommerce.Api.Configurations;
using Tekton.ECommerce.Api.Filters;

namespace Tekton.ECommerce.Api.Extensions
{
    public static class CustomExtensionsSwagger
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection Services)
        {
            Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerVersionServices>();

            Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Tekton eComercer API",
                    Version = "v1",
                    Description = "MicroService Architecture",
                    Contact = new OpenApiContact
                    {
                        Name = "Juan Casiano @ Openplata",
                        Email = "carlos.casiano@openplata.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Derechos Reservados"
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.SchemaFilter<SwaggerBodyJsonIgnore>();
                c.OperationFilter<SwaggerQueryJsonIgnore>();
                //c.OperationFilter<SwaggerAddRequiredHeaderParameter>();
                c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                c.DescribeAllParametersInCamelCase();
            });

            Services.AddFluentValidationRulesToSwagger();

            return Services;
        }
    }
}