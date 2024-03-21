using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.Product;

namespace Tekton.ECommerce.Api.Validator.Core.Product
{
    public class GetProductByIdRequestDtoValidator : AbstractValidator<GetProductByIdRequestDto>
    {
        
        public GetProductByIdRequestDtoValidator()
        {
            RuleFor(x => x.ProductId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductRequired.ProductId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivo(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductFormat.ProductId);

        }
    }
}