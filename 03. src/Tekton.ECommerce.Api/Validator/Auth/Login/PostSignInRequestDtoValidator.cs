using FluentValidation;
using Tekton.ECommerce.Api.Messages;
using Tekton.ECommerce.Dto.Auth.Login;

namespace Tekton.ECommerce.Api.Validator.Seccion
{

    public class PostSignInRequestDtoValidator : AbstractValidator<PostSignInRequestDto>
    {
        
        public PostSignInRequestDtoValidator()
        {
            RuleFor(x => x.OwnerId)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage(GlobalMessages.Required.Core.CoreRequired.CoreId)
              .Must(p => GlobalValidator<int>.IsNumeroPositivoEntero(p)).WithMessage(GlobalMessages.Format.Auth.Login.OwnerId);

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 3, 20)).WithMessage(GlobalMessages.Length.Auth.Login.Username)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Auth.Login.Username)
                ;

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .Must(p => GlobalValidator<string>.IsValidLength(p, 1, 10)).WithMessage(GlobalMessages.Length.Auth.Login.Password)
                .Must(p => GlobalValidator<string>.IsNumberLetter(p)).WithMessage(GlobalMessages.Format.Auth.Login.Password)
                ;
        }
    }
}