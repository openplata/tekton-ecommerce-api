using OP.FK_Framework.Dto.Base;

namespace Tekton.ECommerce.Dto.Core.Category
{
    public class GetCategoryAllByParentIdResponseDto : GetByIdBaseResponse
    {
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public string Ordering { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Additional { get; set; }
        public string Observation { get; set; }
        public int ParentId { get; set; }
    }
}