using OP.FK_Framework.Dto.JWTToken;
using OP.FK_Framework.Dto.Response;
using System.Threading.Tasks;

namespace Tekton.ECommerce.IApplication.UseCases.Auth
{
    public interface IJWTTokenService
    {
        Task<BaseResponse<JwtTokenResponseDto>> GenerarToken(TokenInformationDto request);
        TokenInformationDto GetTokenInfo();
        string GetToken();
    }
}
