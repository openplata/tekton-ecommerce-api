using OP.FK_Framework.Domain.Base;

namespace Tekton.ECommerce.Domain.Entity.Core.Product
{
    public class USP_PRODUCT_UPD_Request : CRUD_Base_Request
    {
        public int PRODUCT_ID { get; set; }
        public string CODE { get; set; }
        public string EXTERNAL_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }

        public string ORDERING { get; set; }

        public string BARCODE { get; set; }
        public int BRAND_ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public int SUBCATEGORY_ID { get; set; }

        public int STOCK { get; set; }
        public decimal PRICE { get; set; }

        public string COLOR { get; set; }
        public string ICON { get; set; }

        public string DATA1 { get; set; }
        public string DATA2 { get; set; }
        public string ADDITIONAL { get; set; }
        public string OBSERVATION { get; set; }

        public short STATUS { get; set; }

    }
}