using OP.FK_Framework.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Security.User;

namespace Tekton.ECommerce.IApplication.UseCases.Security.User
{
    public interface IUserService
    {
        Task<BaseResponse<List<GetUserAllResponse>>> GetAll();
    }
}