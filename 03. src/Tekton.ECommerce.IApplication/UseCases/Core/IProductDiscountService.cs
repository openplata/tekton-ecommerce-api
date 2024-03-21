using OP.FK_Framework.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Dto.Core.ProductDiscount;

namespace Tekton.ECommerce.IApplication.UseCases.Core
{
    public interface IProductDiscountService
    {
        Task<BaseResponse<List<GetProductDiscountByProductIdResponseDto>>> GetAll();
    }
}