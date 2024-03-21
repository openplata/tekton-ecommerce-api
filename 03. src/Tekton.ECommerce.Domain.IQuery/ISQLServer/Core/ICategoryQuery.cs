using System.Collections.Generic;
using System.Threading.Tasks;
using Tekton.ECommerce.Domain.Entity.Core.Category;

namespace Tekton.ECommerce.Domain.IQuery.ISQLServer.Core
{
    public interface ICategoryQuery
    {
        Task<USP_CATEGORY_SEL_BY_ID_Result> USP_CATEGORY_SEL_BY_ID(USP_CATEGORY_SEL_BY_ID_Request request);
        Task<IEnumerable<USP_CATEGORY_SEL_ALL_Result>> USP_CATEGORY_SEL_ALL(USP_CATEGORY_SEL_ALL_Request request);
        Task<IEnumerable<USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Result>> USP_CATEGORY_SEL_ALL_BY_PARENT_ID(USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Request request);
    }
}