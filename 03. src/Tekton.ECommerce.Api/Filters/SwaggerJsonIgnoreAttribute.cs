namespace Tekton.ECommerce.Api.Filters
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class SwaggerJsonIgnoreAttribute : Attribute
    {
    }
}