using OP.FK_Framework.Dto.Response;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Auth.Login;

namespace Tekton.ECommerce.IApplication.UseCases.Auth
{
    public interface ILoginService
    {
        Task<BaseResponse<PostSignInResponseDto>> PostSignIn(PostSignInRequestDto request);
    }
}