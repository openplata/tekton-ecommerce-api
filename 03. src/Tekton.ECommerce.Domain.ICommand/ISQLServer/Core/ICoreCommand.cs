using System.Threading.Tasks;
using Tekton.ECommerce.Domain.Entity.Core.Core;

namespace Tekton.ECommerce.Domain.ICommand.ISQLServer.Core
{
    public interface ICoreCommand
    {
        Task<USP_CORE_INS_Result> USP_CORE_INS(USP_CORE_INS_Request request);
        Task<USP_CORE_UPD_Result> USP_CORE_UPD(USP_CORE_UPD_Request request);
    }
}