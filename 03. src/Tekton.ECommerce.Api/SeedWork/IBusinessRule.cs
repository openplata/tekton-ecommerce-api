
namespace Tekton.ECommerce.Api.Filters
{
    public interface IBusinessRule
    {
        string Message { get; set; }

        string Code { get; }

        bool Failed();
    }
}