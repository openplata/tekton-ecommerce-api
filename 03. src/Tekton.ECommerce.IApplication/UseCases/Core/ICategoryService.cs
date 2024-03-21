using OP.FK_Framework.Dto.Response;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tekton.ECommerce.Dto.Core.Category;

namespace Tekton.ECommerce.IApplication.UseCases.Core
{
    public interface ICategoryService
    {
        Task<BaseResponse<PostCategoryResponseDto>> Post(PostCategoryRequestDto request);
        Task<BaseResponse<PutCategoryResponseDto>> Put(PutCategoryRequestDto request);
        Task<BaseResponse<GetCategoryByIdResponseDto>> GetById(GetCategoryByIdRequestDto request);
        Task<BaseResponse<IEnumerable<GetCategoryAllByParentIdResponseDto>>> GetAllByParentId(GetCategoryAllByParentIdRequestDto request);
    }
}