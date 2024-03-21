using OP.FK_Framework.Dto.Base;

namespace Tekton.ECommerce.Dto.Core.Product
{
    public class GetProductAllByBrandIdResponseDto : GetByIdBaseResponse
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

        public string Color { get; set; }
        public string Icon { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Additional { get; set; }
        public string Observation { get; set; }
    }
}