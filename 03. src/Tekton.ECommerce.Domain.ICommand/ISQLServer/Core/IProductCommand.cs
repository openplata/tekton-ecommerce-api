using System.Threading.Tasks;
using Tekton.ECommerce.Domain.Entity.Core.Product;

namespace Tekton.ECommerce.Domain.ICommand.ISQLServer.Core
{
    public interface IProductCommand
    {
        Task<USP_PRODUCT_INS_Result> USP_PRODUCT_INS(USP_PRODUCT_INS_Request request);
        Task<USP_PRODUCT_UPD_Result> USP_PRODUCT_UPD(USP_PRODUCT_UPD_Request request);
    }
}