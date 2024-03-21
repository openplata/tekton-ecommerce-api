using OP.FK_Framework.Dto.Base;

namespace Tekton.ECommerce.Dto.Security.User
{
    public class GetUserAllResponse
    {
        public GetUserAllResponse()
        {
            OwnerId = 0;
            UserId = 0;
            UserName = "";
            IsActive = true;
        }

        public int OwnerId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}