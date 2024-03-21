using Tekton.ECommerce.Dto.Core.Core;
using OP.FK_Framework.Dto.Response;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tekton.ECommerce.IApplication.UseCases.Core
{
    public interface ICoreService
    {
        Task<BaseResponse<PostCoreResponseDto>> Post(PostCoreRequestDto request);
        Task<BaseResponse<PutCoreResponseDto>> Put(PutCoreRequestDto request);
        Task<BaseResponse<GetCoreByIdResponseDto>> GetById(GetCoreByIdRequestDto request);
        Task<BaseResponse<IEnumerable<GetCoreAllByParentIdResponseDto>>> GetAllByParentId(GetCoreAllByParentIdRequestDto request);
    }
}