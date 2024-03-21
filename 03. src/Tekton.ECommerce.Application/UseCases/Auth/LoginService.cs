using AutoMapper;
using OP.FK_Framework.Dto.JWTToken;
using OP.FK_Framework.Dto.Response;

using System.Net;
using Microsoft.AspNetCore.Http;
using Tekton.ECommerce.IApplication.UseCases.Auth;
using System.Threading.Tasks;
using Tekton.ECommerce.IApplication.UseCases.Security.User;
using System.Linq;
using System;
using System.Collections.Generic;
using Tekton.ECommerce.Dto.Auth.Login;


namespace Tekton.ECommerce.Application.UseCases.Auth
{
    public class LoginService : GenericApplication, ILoginService
    {
        private readonly IJWTTokenService jwtTokenService;
        private readonly IUserService userService;
        
        public LoginService(IMapper mapper, IJWTTokenService _jwtTokenService, IUserService _userService) : base(mapper)
        {
            jwtTokenService = _jwtTokenService;
            userService = _userService;
        }

        public async Task<BaseResponse<PostSignInResponseDto>> PostSignIn(PostSignInRequestDto request)
        {
            var signInPostResponseDto = new PostSignInResponseDto();
            var response = new BaseResponse<PostSignInResponseDto>()
            {
                Code = "200",
                Data = null,
                Message = "",
                Success = true,
                Validations = null
            };
            
            try
            {
                var users = await userService.GetAll();

                var user = users.Data.Where(x => x.OwnerId == request.OwnerId && x.UserName == request.Username && x.Password == request.Password && x.IsActive == true).FirstOrDefault();

                if (user != null)
                {
                    var tokenUserDto = new TokenUserDto();
                    tokenUserDto.BusinessOwnerId = request.OwnerId;
                    tokenUserDto.BusinessOwner = "Tekton";
                    tokenUserDto.Id = user.UserId;
                    tokenUserDto.Username = user.UserName;

                    signInPostResponseDto.User = tokenUserDto;
                    signInPostResponseDto.User.BusinessOwner = tokenUserDto.BusinessOwner;
                    var tokenRoleDto = new TokenRoleDto();
                    tokenRoleDto.Id = 1;
                    tokenRoleDto.Name = "Admin";
                    tokenRoleDto.Description = "Administrador";

                    signInPostResponseDto.Role = tokenRoleDto;
                    signInPostResponseDto.Apps = [];
                    var organizations = new List<TokenOrganizationDto>();
                    var organization = new TokenOrganizationDto();
                    organization.Id = 100;
                    organization.Name = "Tekton Company";
                    organization.Class = "O";
                    organizations.Add(organization);
                    signInPostResponseDto.Organizations = organizations;

                    var tokenInformationDto = new TokenInformationDto();
                    var businessOwners = new List<TokenBusinessOwnerDto>();
                    var businessOwner = new TokenBusinessOwnerDto();
                    businessOwner.BusinessOwner = tokenUserDto.BusinessOwner;
                    businessOwners.Add(businessOwner);

                    tokenInformationDto.BusinessOwners = businessOwners;
                    tokenInformationDto.User = signInPostResponseDto.User;
                    tokenInformationDto.Role = signInPostResponseDto.Role;

                    var selectedOrganizations = new List<TokenSelectedOrganizationDto>();
                    var selectedOrganization = new TokenSelectedOrganizationDto();
                    selectedOrganization.Id = 100;
                    selectedOrganization.Class = "O";
                    selectedOrganization.Data1 = "200123456789";
                    selectedOrganizations.Add(selectedOrganization);
                    tokenInformationDto.SelectedOrganizations = selectedOrganizations;

                    var tokenResponse = await jwtTokenService.GenerarToken(tokenInformationDto);
                    signInPostResponseDto.JwtToken = tokenResponse.Data;
                    
                    response.Data = signInPostResponseDto;
                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "El Username o Password es incorrecto!";
                    response.Code = HttpStatusCode.Unauthorized.ToString();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Code = StatusCodes.Status500InternalServerError.ToString();
                response.Message = ex.Message;
            }
            
            return response;
        }

    }
}