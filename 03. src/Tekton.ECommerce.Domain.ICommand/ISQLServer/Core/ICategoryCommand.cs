using System.Threading.Tasks;
using Tekton.ECommerce.Domain.Entity.Core.Category;

namespace Tekton.ECommerce.Domain.ICommand.ISQLServer.Core
{
    public interface ICategoryCommand
    {
        Task<USP_CATEGORY_INS_Result> USP_CATEGORY_INS(USP_CATEGORY_INS_Request request);
        Task<USP_CATEGORY_UPD_Result> USP_CATEGORY_UPD(USP_CATEGORY_UPD_Request request);
    }
}