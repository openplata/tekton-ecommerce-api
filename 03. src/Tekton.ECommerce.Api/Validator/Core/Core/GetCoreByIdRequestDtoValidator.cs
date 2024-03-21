using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Core;

namespace Tekton.ECommerce.Api.Validator.Core.Core
{
    public class GetCoreByIdRequestDtoValidator : AbstractValidator<GetCoreByIdRequestDto>
    {
        
        public GetCoreByIdRequestDtoValidator()
        {
            RuleFor(x => x.CoreId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CoreRequired.CoreId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivo(p.Value)).WithMessage(GlobalMessages.Format.Core.CoreFormat.CoreId);

        }
    }
}