using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Domain.Entity.Core.Product;

namespace Tekton.ECommerce.Domain.IQuery.ISQLServer.Core
{
    public interface IProductQuery
    {
        Task<USP_PRODUCT_SEL_BY_ID_Result> USP_PRODUCT_SEL_BY_ID(USP_PRODUCT_SEL_BY_ID_Request request);        
    }
}