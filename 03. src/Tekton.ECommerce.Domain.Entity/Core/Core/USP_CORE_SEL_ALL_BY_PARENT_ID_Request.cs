using OP.FK_Framework.Domain.Base;

namespace Tekton.ECommerce.Domain.Entity.Core.Core
{
    public class USP_CORE_SEL_ALL_BY_PARENT_ID_Request : OWNER_Base_Request
    {
        public int PARENT_ID { get; set; }
    }
}