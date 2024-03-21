using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Core;

namespace Tekton.ECommerce.Api.Validator.Core.Product
{
    public class GetCoreAllByParentIdRequestDtoValidator : AbstractValidator<GetCoreAllByParentIdRequestDto>
    {
        
        public GetCoreAllByParentIdRequestDtoValidator()
        {
            RuleFor(x => x.ParentId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CoreRequired.ParentId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.CoreFormat.ParentId);

        }
    }
}