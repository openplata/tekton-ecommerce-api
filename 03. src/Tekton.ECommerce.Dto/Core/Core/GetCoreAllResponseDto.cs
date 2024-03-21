using OP.FK_Framework.Dto.Base;

namespace Tekton.ECommerce.Dto.Core.Core
{
    public class GetCoreAllResponseDto : GetByIdBaseResponse
    {
        public int CoreId { get; set; }
        public string Code { get; set; }
        public string Ordering { get; set; }
        public string CoreName { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Additional { get; set; }
        public string Observation { get; set; }
        public int ParentId { get; set; }
    }
}