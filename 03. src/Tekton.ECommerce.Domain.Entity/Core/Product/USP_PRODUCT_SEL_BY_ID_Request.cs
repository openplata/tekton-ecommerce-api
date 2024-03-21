using OP.FK_Framework.Domain.Base;

namespace Tekton.ECommerce.Domain.Entity.Core.Product
{
    public class USP_PRODUCT_SEL_BY_ID_Request : OWNER_Base_Request
    {
        public int PRODUCT_ID { get; set; }
    }
}