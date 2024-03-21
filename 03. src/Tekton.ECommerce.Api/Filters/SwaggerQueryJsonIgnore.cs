using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Tekton.ECommerce.Api.Filters
{
    public class SwaggerQueryJsonIgnore : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parametersToRemove = operation.Parameters.Where(x => x.Name == "api-version").ToList();
            foreach (var parameter in parametersToRemove)
                operation.Parameters.Remove(parameter);

            List<PropertyInfo> list = context.MethodInfo.GetParameters().SelectMany((ParameterInfo p) => from prop in p.ParameterType.GetProperties()
                                                                                                         where prop.GetCustomAttribute<SwaggerJsonIgnoreAttribute>() != null
                                                                                                         select prop).ToList();
            if (!list.Any())
            {
                return;
            }

            foreach (PropertyInfo property in list)
            {
                operation.Parameters = operation.Parameters.Where((OpenApiParameter p) => !p.Name.Equals(property.Name, StringComparison.InvariantCulture) && !p.Name.StartsWith(property.Name + ".", StringComparison.InvariantCulture) && !p.Name.Equals("route", StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }
    }
}