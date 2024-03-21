using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Category;

namespace Tekton.ECommerce.Api.Validator.Core.Category
{
    public class GetCategoryAllByParentIdRequestDtoValidator : AbstractValidator<GetCategoryAllByParentIdRequestDto>
    {
        
        public GetCategoryAllByParentIdRequestDtoValidator()
        {
            RuleFor(x => x.ParentId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CategoryRequired.ParentId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.ParentId);

        }
    }
}