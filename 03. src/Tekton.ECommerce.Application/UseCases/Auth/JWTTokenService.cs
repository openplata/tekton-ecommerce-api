using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OP.FK_Framework.Dto.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using OP.FK_Framework.Dto.JWTToken;
using Tekton.ECommerce.IApplication.UseCases.Auth;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tekton.ECommerce.Application.UseCases.Auth
{
    public class JWTTokenService : IJWTTokenService
    {
        public static IConfiguration configuration;
        public readonly IHttpContextAccessor httpContextAccessor;
        private readonly TokenConfigurationsDto tokenConfigurations;
        private readonly SignConfigurationsDto signConfigurations;

        public JWTTokenService(IOptions<TokenConfigurationsDto> tokenConfigs, IHttpContextAccessor _httpContextAccessor)
        {
            tokenConfigurations = tokenConfigs.Value;
            signConfigurations = new SignConfigurationsDto(tokenConfigurations.SecretKey);
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<BaseResponse<JwtTokenResponseDto>> GenerarToken(TokenInformationDto request)
        {
            var jwtTokenResponseDto = new JwtTokenResponseDto();
            var response = new BaseResponse<JwtTokenResponseDto>
            {
                Code = "200",
                Data = jwtTokenResponseDto,
                Message = "",
                Success = true,
                Validations = new List<MessageResponse>()
            };

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(tokenConfigurations.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(tokenConfigurations.AccessTokenExpiration),
                SigningCredentials = signConfigurations.SignCredentials,
                Subject = new ClaimsIdentity(GetClaims(request))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);
            //var securityToken = tokenHandler.CreateToken(descriptor);
            var token = tokenHandler.WriteToken(securityToken);

            jwtTokenResponseDto.Token = token;
            jwtTokenResponseDto.Type = "Bearer";
            jwtTokenResponseDto.ExpiresIn = descriptor.Expires;

            response.Data = jwtTokenResponseDto;
            return response;
        }

        private IEnumerable<Claim> GetClaims(TokenInformationDto info)
        {
            var claims = new List<Claim>
            {
                new Claim("TokenInformacion", JsonConvert.SerializeObject(info)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, info.User.Username!),
                new Claim("role", info.Role!.Name!)
            };
            return claims;
        }

        public TokenInformationDto GetTokenInfo()
        {
            string token = GetToken();

            var handler = new JwtSecurityTokenHandler();
            //var jsonToken = handler.ReadToken(token);
            var tokens = handler.ReadToken(token) as JwtSecurityToken;


            var TokenInfo = JsonConvert.DeserializeObject<TokenInformationDto>(
                tokens.Claims.First(claim => claim.Type == "TokenInformacion").Value);

            return TokenInfo;
        }

        public string GetToken()
        {
            var authorizationHeader = httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }
    }
}
