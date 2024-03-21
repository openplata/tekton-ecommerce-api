namespace Tekton.ECommerce.Dto.Core.Status
{
    public class GetStatusAllResponse
    {
        public GetStatusAllResponse()
        {
            StatusId = 0;
            StatusName = "";            
        }

        public short StatusId { get; set; }
        public string StatusName { get; set; }
        
    }
}