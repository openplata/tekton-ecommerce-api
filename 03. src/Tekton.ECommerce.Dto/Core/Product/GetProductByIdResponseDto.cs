using OP.FK_Framework.Dto.Base;

namespace Tekton.ECommerce.Dto.Core.Product
{
    public class GetProductByIdResponseDto
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ExternalCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Ordering { get; set; }

        public string Barcode { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public int Stock { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }

        public string Color { get; set; }
        public string Icon { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Additional { get; set; }
        public string Observation { get; set; }

        public short Status { get; set; }
        public string StatusName { get; set; }

        public int CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public string CreationDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string? UpdateUserName { get; set; }
        public string? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public string Host { get; set; }
    }
}