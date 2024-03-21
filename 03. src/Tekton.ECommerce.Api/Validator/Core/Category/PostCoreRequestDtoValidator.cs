using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Category;

namespace Tekton.ECommerce.Api.Validator.Core.Category
{

    public class PostCategoryRequestDtoValidator : AbstractValidator<PostCategoryRequestDto>
    {
        
        public PostCategoryRequestDtoValidator()
        {

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 5)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Code)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Code)
                ;

            RuleFor(x => x.Ordering)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 10)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Ordering)
                .Must(p => GlobalValidator<string>.IsNumber(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Ordering)
                ;

            RuleFor(x => x.CategoryName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(GlobalMessages.Required.Core.CategoryRequired.CategoryName)
                .Must(p => GlobalValidator<string>.IsNotNullOrEmpty(p)).WithMessage(GlobalMessages.Required.Core.CategoryRequired.CategoryName)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 3, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.CategoryName)
                .Must(p => GlobalValidator<string>.IsName(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.CategoryName)
                ;

            RuleFor(x => x.Color)
                .Cascade(CascadeMode.Stop)                                
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 50)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Color)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Color)
                ;

            RuleFor(x => x.Icon)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Icon)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Icon)
                ;

            RuleFor(x => x.Data1)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Data1)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Data1)
                ;

            RuleFor(x => x.Data2)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Data2)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Data2)
                ;

            RuleFor(x => x.Additional)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Additional)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Additional)
                ;

            RuleFor(x => x.Observation)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.CategoryLength.Observation)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.Observation)
                ;

            RuleFor(x => x.ParentId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CategoryRequired.ParentId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.CategoryFormat.ParentId);

        }
    }
}