using AutoMapper;
using Microsoft.AspNetCore.Http;

using OP.FK_Framework.Dto.Response;
using Tekton.ECommerce.IApplication.UseCases.Auth;

using System.Net;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Tekton.ECommerce.IApplication.UseCases.Core;
using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;
using Tekton.ECommerce.Dto.Core.Category;
using Tekton.ECommerce.Domain.Entity.Core.Category;
using Tekton.ECommerce.Dto.Core.Core;


namespace Tekton.ECommerce.Application.UseCases.Category
{
    public class CategoryService : GenericApplication, ICategoryService
    {
        private readonly ICategoryQuery query;
        private readonly ICategoryCommand command;
        private readonly IJWTTokenService jwtTokenService;

        public CategoryService(IMapper mapper, IJWTTokenService _jwtTokenService, ICategoryQuery _query, ICategoryCommand _command) : base(mapper)
        {
            query = _query;
            command = _command;
            jwtTokenService = _jwtTokenService;
        }

        public async Task<BaseResponse<PostCategoryResponseDto>> Post(PostCategoryRequestDto request)
        {
            var response = new BaseResponse<PostCategoryResponseDto>()
            {
                Code = "200",
                Data = new PostCategoryResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<PostCategoryRequestDto, USP_CATEGORY_INS_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                uspRequest.USER_ID = token.User.Id;

                var uspResult = await command.USP_CATEGORY_INS(uspRequest);
                response.Data = mapper.Map<USP_CATEGORY_INS_Result, PostCategoryResponseDto>(uspResult);

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

        public async Task<BaseResponse<PutCategoryResponseDto>> Put(PutCategoryRequestDto request)
        {
            var response = new BaseResponse<PutCategoryResponseDto>()
            {
                Code = "200",
                Data = new PutCategoryResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var getCategoryByIdRequestDto = new GetCategoryByIdRequestDto();
                getCategoryByIdRequestDto.CategoryId = request.CategoryId;
                var getCoreByIdResponse = await GetById(getCategoryByIdRequestDto);

                if (getCoreByIdResponse.Success)
                {
                    var uspRequest = mapper.Map<PutCategoryRequestDto, USP_CATEGORY_UPD_Request>(request);

                    uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                    uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                    uspRequest.USER_ID = token.User.Id;

                    var uspResult = await command.USP_CATEGORY_UPD(uspRequest);
                    response.Data = mapper.Map<USP_CATEGORY_UPD_Result, PutCategoryResponseDto>(uspResult);

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

        public async Task<BaseResponse<GetCategoryByIdResponseDto>> GetById(GetCategoryByIdRequestDto request)
        {
            var response = new BaseResponse<GetCategoryByIdResponseDto>()
            {
                Code = "200",
                Data = new GetCategoryByIdResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<GetCategoryByIdRequestDto, USP_CATEGORY_SEL_BY_ID_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                var uspResult = await query.USP_CATEGORY_SEL_BY_ID(uspRequest);
                response.Success = true;

                if (uspResult != null)
                {
                    response.Data = mapper.Map<USP_CATEGORY_SEL_BY_ID_Result, GetCategoryByIdResponseDto>(uspResult);
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

        public async Task<BaseResponse<IEnumerable<GetCategoryAllByParentIdResponseDto>>> GetAllByParentId(GetCategoryAllByParentIdRequestDto request)
        {
            var response = new BaseResponse<IEnumerable<GetCategoryAllByParentIdResponseDto>>()
            {
                Code = "200",
                Data = new List<GetCategoryAllByParentIdResponseDto>(),
                Message = "",
                Success = true,
                Validations = null
            };

            var token = jwtTokenService.GetTokenInfo();

            try
            {
                var uspRequest = mapper.Map<GetCategoryAllByParentIdRequestDto, USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Request>(request);
                
                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                var uspResult = await query.USP_CATEGORY_SEL_ALL_BY_PARENT_ID(uspRequest);
                response.Success = true;

                if (uspResult.Any())
                {
                    response.Data = mapper.Map<IEnumerable<USP_CATEGORY_SEL_ALL_BY_PARENT_ID_Result>, IEnumerable<GetCategoryAllByParentIdResponseDto>>(uspResult);
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