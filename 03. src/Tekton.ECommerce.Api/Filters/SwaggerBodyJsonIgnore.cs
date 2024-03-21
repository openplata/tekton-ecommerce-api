using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Tekton.ECommerce.Api.Filters
{
    public class SwaggerBodyJsonIgnore : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            foreach (PropertyInfo ignoreDataMemberProperty in from t in context.Type.GetProperties()
                                                              where t.GetCustomAttribute<SwaggerJsonIgnoreAttribute>() != null
                                                              select t)
            {
                string text = schema.Properties.Keys.SingleOrDefault((string x) => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());
                if (text != null)
                {
                    schema.Properties.Remove(text);
                }
            }
        }
    }
}