using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Core.ProductDiscount;

namespace Tekton.ECommerce.Api.Validator.Core.Core
{
    public class GetProductDiscountByProductIdRequestDtoValidator : AbstractValidator<GetProductDiscountByProductIdRequestDto>
    {
        
        public GetProductDiscountByProductIdRequestDtoValidator()
        {
            RuleFor(x => x.ProductId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.ProductDiscountRequired.ProductId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivo(p.Value)).WithMessage(GlobalMessages.Format.Core.ProductDiscountFormat.ProductId);

        }
    }
}