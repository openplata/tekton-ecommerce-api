using OP.FK_Framework.Dto.JWTToken;
using System.Collections.Generic;

namespace Tekton.ECommerce.Dto.Auth.Login
{
    public class PostSignInResponseDto
    {
        public PostSignInResponseDto()
        {
            JwtToken = new JwtTokenResponseDto();
        }
                
        public TokenUserDto User { get; set; }
        public TokenRoleDto Role { get; set; }
        public List<TokenAppDto> Apps { get; set; }
        public List<TokenOrganizationDto> Organizations { get; set; }
        public JwtTokenResponseDto JwtToken { get; set; }        
    }
}