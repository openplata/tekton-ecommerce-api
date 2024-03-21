using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Category;

namespace Tekton.ECommerce.Api.Validator.Core.Category
{
    public class GetCategoryByIdRequestDtoValidator : AbstractValidator<GetCategoryByIdRequestDto>
    {
        
        public GetCategoryByIdRequestDtoValidator()
        {
            RuleFor(x => x.CategoryId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CategoryRequired.CategoryId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivo(p.Value)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.CategoryId);

        }
    }
}