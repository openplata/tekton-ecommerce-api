using OP.FK_Framework.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Core.Status;

namespace Tekton.ECommerce.IApplication.UseCases.Core
{
    public interface IStatusService
    {
        Task<BaseResponse<List<GetStatusAllResponse>>> GetAll();
    }
}