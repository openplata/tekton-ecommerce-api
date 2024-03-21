using AutoMapper;
using Microsoft.AspNetCore.Http;

using OP.FK_Framework.Dto.Response;
using Tekton.ECommerce.IApplication.UseCases.Auth;

using System.Net;
using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;

using Tekton.ECommerce.Domain.Entity.Core.Core;
using Tekton.ECommerce.Dto.Core.Core;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Tekton.ECommerce.IApplication.UseCases.Core;


namespace Tekton.ECommerce.Application.UseCases.Core
{
    public class CoreService : GenericApplication, ICoreService
    {
        private readonly ICoreQuery query;
        private readonly ICoreCommand command;
        private readonly IJWTTokenService jwtTokenService;

        public CoreService(IMapper mapper, IJWTTokenService _jwtTokenService, ICoreQuery _query, ICoreCommand _command) : base(mapper)
        {
            query = _query;
            command = _command;
            jwtTokenService = _jwtTokenService;
        }

        public async Task<BaseResponse<PostCoreResponseDto>> Post(PostCoreRequestDto request)
        {
            var response = new BaseResponse<PostCoreResponseDto>()
            {
                Code = "200",
                Data = new PostCoreResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<PostCoreRequestDto, USP_CORE_INS_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                uspRequest.USER_ID = token.User.Id;

                var uspResult = await command.USP_CORE_INS(uspRequest);
                response.Data = mapper.Map<USP_CORE_INS_Result, PostCoreResponseDto>(uspResult);

                response.Code = HttpStatusCode.OK.ToString();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Code = StatusCodes.Status500InternalServerError.ToString();
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<PutCoreResponseDto>> Put(PutCoreRequestDto request)
        {
            var response = new BaseResponse<PutCoreResponseDto>()
            {
                Code = "200",
                Data = new PutCoreResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var getCoreByIdRequestDto = new GetCoreByIdRequestDto();
                getCoreByIdRequestDto.CoreId = request.CoreId;
                var getCoreByIdResponse = await GetById(getCoreByIdRequestDto);

                if (getCoreByIdResponse.Success)
                {
                    var uspRequest = mapper.Map<PutCoreRequestDto, USP_CORE_UPD_Request>(request);

                    uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                    uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                    uspRequest.USER_ID = token.User.Id;

                    var uspResult = await command.USP_CORE_UPD(uspRequest);
                    response.Data = mapper.Map<USP_CORE_UPD_Result, PutCoreResponseDto>(uspResult);

                    response.Code = HttpStatusCode.OK.ToString();
                }
                else
                {
                    response.Success = false;
                    response.Code = StatusCodes.Status204NoContent.ToString();                    
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

        public async Task<BaseResponse<GetCoreByIdResponseDto>> GetById(GetCoreByIdRequestDto request)
        {
            var response = new BaseResponse<GetCoreByIdResponseDto>()
            {
                Code = "200",
                Data = new GetCoreByIdResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<GetCoreByIdRequestDto, USP_CORE_SEL_BY_ID_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                var uspResult = await query.USP_CORE_SEL_BY_ID(uspRequest);
                response.Success = true;

                if (uspResult != null)
                {
                    response.Data = mapper.Map<USP_CORE_SEL_BY_ID_Result, GetCoreByIdResponseDto>(uspResult);
                    response.Code = HttpStatusCode.OK.ToString();
                }
                else
                {
                    response.Success = false;
                    response.Code = StatusCodes.Status204NoContent.ToString();                  
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

        public async Task<BaseResponse<IEnumerable<GetCoreAllByParentIdResponseDto>>> GetAllByParentId(GetCoreAllByParentIdRequestDto request)
        {
            var response = new BaseResponse<IEnumerable<GetCoreAllByParentIdResponseDto>>()
            {
                Code = "200",
                Data = new List<GetCoreAllByParentIdResponseDto>(),
                Message = "",
                Success = true,
                Validations = null
            };

            var token = jwtTokenService.GetTokenInfo();

            try
            {
                var uspRequest = mapper.Map<GetCoreAllByParentIdRequestDto, USP_CORE_SEL_ALL_BY_PARENT_ID_Request>(request);
                
                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                var uspResult = await query.USP_CORE_SEL_ALL_BY_PARENT_ID(uspRequest);
                response.Success = true;

                if (uspResult.Any())
                {
                    response.Data = mapper.Map<IEnumerable<USP_CORE_SEL_ALL_BY_PARENT_ID_Result>, IEnumerable<GetCoreAllByParentIdResponseDto>>(uspResult);
                    response.Code = HttpStatusCode.OK.ToString();
                }
                else
                {
                    response.Success = false;
                    response.Code = StatusCodes.Status204NoContent.ToString();
                    response.Data = [];
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