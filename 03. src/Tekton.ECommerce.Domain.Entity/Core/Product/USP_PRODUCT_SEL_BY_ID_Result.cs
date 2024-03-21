using OP.FK_Framework.Domain.Base;
using System;

namespace Tekton.ECommerce.Domain.Entity.Core.Product
{
    public class USP_PRODUCT_SEL_BY_ID_Result
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

        public int CREATION_USER_ID { get; set; }
        public string CREATION_USER_NAME { get; set; }
        public DateTime CREATION_DATE { get; set; }
        public int? UPDATE_USER_ID { get; set; }
        public string? UPDATE_USER_NAME { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public short STATUS { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string HOST { get; set; }

    }
}