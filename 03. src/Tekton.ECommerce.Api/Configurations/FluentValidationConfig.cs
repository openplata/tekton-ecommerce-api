namespace Tekton.ECommerce.Api.Configurations;

public class FluentValidationConfig
{
    public bool GetValidation { get; set; }
    public bool PostValidation { get; set; }

    public bool DelValidation { get; set; }
}
