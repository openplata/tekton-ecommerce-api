namespace Tekton.ECommerce.Dto.Auth.Login
{
    public class PostSignInRequestDto
    {
        public int OwnerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}