using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Product;

namespace Tekton.ECommerce.Api.Validator.Core.Product
{

    public class PostProductRequestDtoValidator : AbstractValidator<PostProductRequestDto>
    {
        
        public PostProductRequestDtoValidator()
        {

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 10)).WithMessage(GlobalMessages.Length.Core.ProductLength.Code)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Code)
                ;

            RuleFor(x => x.ExternalCode)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 50)).WithMessage(GlobalMessages.Length.Core.ProductLength.ExternalCode)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.ExternalCode)
                ;

            RuleFor(x => x.ProductName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.ProductName)
                .Must(p => GlobalValidator<string>.IsNotNullOrEmpty(p)).WithMessage(GlobalMessages.Required.Core.ProductRequired.ProductName)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 3, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.ProductName)
                .Must(p => GlobalValidator<string>.IsName(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.ProductName)
                ;

            RuleFor(x => x.ProductDescription)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.ProductDescription)
                .Must(p => GlobalValidator<string>.IsNotNullOrEmpty(p)).WithMessage(GlobalMessages.Required.Core.ProductRequired.ProductDescription)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 3, 500)).WithMessage(GlobalMessages.Length.Core.ProductLength.ProductDescription)
                .Must(p => GlobalValidator<string>.IsName(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.ProductDescription)
                ;

            RuleFor(x => x.Ordering)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 10)).WithMessage(GlobalMessages.Length.Core.ProductLength.Ordering)
                .Must(p => GlobalValidator<string>.IsNumber(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Ordering)
                ;

            RuleFor(x => x.Barcode)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 50)).WithMessage(GlobalMessages.Length.Core.ProductLength.Barcode)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Barcode)
                ;

            RuleFor(x => x.BrandId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.BrandId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.BrandId);

            RuleFor(x => x.CategoryId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.CategoryId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.CategoryId);

            RuleFor(x => x.SubcategoryId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.SubcategoryId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.SubcategoryId);

            RuleFor(x => x.Stock)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.Stock)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Stock);

            RuleFor(x => x.Price)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.Price)
              .Must(p => GlobalValidator<decimal>.IsNumeroPositivoDecimal(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Price);

            RuleFor(x => x.Color)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 50)).WithMessage(GlobalMessages.Length.Core.ProductLength.Color)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Color)
                ;

            RuleFor(x => x.Icon)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.Icon)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Icon)
                ;

            RuleFor(x => x.Data1)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.Data1)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Data1)
                ;

            RuleFor(x => x.Data2)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.Data2)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Data2)
                ;

            RuleFor(x => x.Additional)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.Additional)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Additional)
                ;

            RuleFor(x => x.Observation)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 0, 100)).WithMessage(GlobalMessages.Length.Core.ProductLength.Observation)
                .Must(p => GlobalValidator<string>.IsText(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Observation)
                ;

            RuleFor(x => x.Status)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.Status)
               .Must(p => GlobalValidator<short?>.IsValidStatus(p)).WithMessage(GlobalMessages.Format.Core.ProductFormat.Status)
               ;
        }
    }
}