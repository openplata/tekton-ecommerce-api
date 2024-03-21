using Tekton.ECommerce.Dto.Core.Product;
using OP.FK_Framework.Dto.Response;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tekton.ECommerce.Dto.ExternalApi;

namespace Tekton.ECommerce.IApplication.UseCases.Core
{
    public interface IProductService
    {
        Task<BaseResponse<PostProductResponseDto>> Post(PostProductRequestDto request);
        Task<BaseResponse<PutProductResponseDto>> Put(PutProductRequestDto request);
        Task<BaseResponse<GetProductByIdResponseDto>> GetById(GetProductByIdRequestDto request, ConfigurationExternalApiDto configurationExternalApi);        
    }
}