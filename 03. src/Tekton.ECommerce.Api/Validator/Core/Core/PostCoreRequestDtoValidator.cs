using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Core;

namespace Tekton.ECommerce.Api.Validator.Core.Core
{

    public class PostCoreRequestDtoValidator : AbstractValidator<PostCoreRequestDto>
    {
        
        public PostCoreRequestDtoValidator()
        {

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 5)).WithMessage(GlobalMessages.Length.Core.CoreLength.Code)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Code)
                ;

            RuleFor(x => x.Ordering)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 10)).WithMessage(GlobalMessages.Length.Core.CoreLength.Ordering)
                .Must(p => GlobalValidator<string>.IsNumber(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Ordering)
                ;

            RuleFor(x => x.CoreName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(GlobalMessages.Required.Core.CoreRequired.CoreName)
                .Must(p => GlobalValidator<string>.IsNotNullOrEmpty(p)).WithMessage(GlobalMessages.Required.Core.CoreRequired.CoreName)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 3, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.CoreName)
                .Must(p => GlobalValidator<string>.IsName(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.CoreName)
                ;

            RuleFor(x => x.Color)
                .Cascade(CascadeMode.Stop)                                
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 50)).WithMessage(GlobalMessages.Length.Core.CoreLength.Color)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Color)
                ;

            RuleFor(x => x.Icon)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.Icon)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Icon)
                ;

            RuleFor(x => x.Data1)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.Data1)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Data1)
                ;

            RuleFor(x => x.Data2)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.Data2)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Data2)
                ;

            RuleFor(x => x.Additional)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.Additional)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Additional)
                ;

            RuleFor(x => x.Observation)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CoreLength.Observation)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CoreFormat.Observation)
                ;

            RuleFor(x => x.ParentId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CoreRequired.ParentId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.CoreFormat.ParentId);

        }
    }
}