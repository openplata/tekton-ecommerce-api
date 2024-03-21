using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Tekton.ECommerce.Api.Configurations
{
    public class ConfigureSwaggerVersionServices : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;
        public IConfiguration Configuration { get; }

        public ConfigureSwaggerVersionServices(IApiVersionDescriptionProvider provider, IConfiguration configuration)
        {
            this.provider = provider;
            Configuration = configuration;
        }

        public void Configure(SwaggerGenOptions options)
        {
            string urlDocumentoValidacion = "https://www.openplata.com";
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, urlDocumentoValidacion));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description, string url)
        {
            var info = new OpenApiInfo()
            {
                Title = "Tekton > MicroService > EComerce API",
                Version = description.ApiVersion.ToString(),
                Description = "Catalogo de recursos disponibles",
                Contact = new OpenApiContact() { Name = "Juan Casiano @ Openplata", Email = "carlos.casiano@openplata.com" },
                License = new OpenApiLicense() { Name = "Openplata", Url = new Uri(url) },
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta API ha quedado obsoleta.";
            }

            return info;
        }
    }
}