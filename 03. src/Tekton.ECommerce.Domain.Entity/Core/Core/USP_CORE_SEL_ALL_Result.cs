using OP.FK_Framework.Domain.Base;

namespace Tekton.ECommerce.Domain.Entity.Core.Core
{
    public class USP_CORE_SEL_ALL_Result : SEL_BY_ID_Base_Result
    {
        public int CORE_ID { get; set; }
        public string CODE { get; set; }
        public string ORDERING { get; set; }
        public string CORE_NAME { get; set; }

        public string COLOR { get; set; }
        public string ICON { get; set; }

        public string DATA1 { get; set; }
        public string DATA2 { get; set; }
        public string ADDITIONAL { get; set; }
        public string OBSERVATION { get; set; }

        public int PARENT_ID { get; set; }

    }
}