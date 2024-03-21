using AutoMapper;
using Microsoft.AspNetCore.Http;

using OP.FK_Framework.Dto.Response;
using Tekton.ECommerce.IApplication.UseCases.Auth;

using System.Net;


using Tekton.ECommerce.Domain.Entity.Core.Product;
using Tekton.ECommerce.Dto.Core.Product;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Tekton.ECommerce.IApplication.UseCases.Core;
using Tekton.ECommerce.Domain.IQuery.ISQLServer.Core;
using Tekton.ECommerce.Domain.ICommand.ISQLServer.Core;
using Tekton.ECommerce.Dto.ExternalApi;
using RestSharp;
using Newtonsoft.Json;
using Tekton.ECommerce.Dto.Core.ProductDiscount;


namespace Tekton.ECommerce.Application.UseCases.Product
{
    public class ProductService : GenericApplication, IProductService
    {
        private readonly IProductQuery query;
        private readonly IProductCommand command;
        private readonly IJWTTokenService jwtTokenService;
        private readonly IStatusService statusApplication;

        public ProductService(IMapper mapper, IJWTTokenService _jwtTokenService, IProductQuery _query, IProductCommand _command, IStatusService _statusApplication) : base(mapper)
        {
            query = _query;
            command = _command;
            jwtTokenService = _jwtTokenService;
            statusApplication = _statusApplication;
        }

        public async Task<BaseResponse<PostProductResponseDto>> Post(PostProductRequestDto request)
        {
            var response = new BaseResponse<PostProductResponseDto>()
            {
                Code = "200",
                Data = new PostProductResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<PostProductRequestDto, USP_PRODUCT_INS_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                uspRequest.USER_ID = token.User.Id;

                var uspResult = await command.USP_PRODUCT_INS(uspRequest);
                response.Data = mapper.Map<USP_PRODUCT_INS_Result, PostProductResponseDto>(uspResult);

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

        public async Task<BaseResponse<PutProductResponseDto>> Put(PutProductRequestDto request)
        {
            var response = new BaseResponse<PutProductResponseDto>()
            {
                Code = "200",
                Data = new PutProductResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<PutProductRequestDto, USP_PRODUCT_UPD_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                uspRequest.USER_ID = token.User.Id;

                var uspResult = await command.USP_PRODUCT_UPD(uspRequest);
                response.Data = mapper.Map<USP_PRODUCT_UPD_Result, PutProductResponseDto>(uspResult);

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

        public async Task<BaseResponse<GetProductByIdResponseDto>> GetById(GetProductByIdRequestDto request, ConfigurationExternalApiDto configurationExternalApi)
        {
            var response = new BaseResponse<GetProductByIdResponseDto>()
            {
                Code = "200",
                Data = new GetProductByIdResponseDto(),
                Message = "",
                Success = true,
                Validations = null
            };

            try
            {
                var token = jwtTokenService.GetTokenInfo();

                var uspRequest = mapper.Map<GetProductByIdRequestDto, USP_PRODUCT_SEL_BY_ID_Request>(request);

                uspRequest.OWNER_ID = token.User.BusinessOwnerId;
                uspRequest.COMPANY_ID = token.SelectedOrganizations.Where(x => x.Class == "O").FirstOrDefault()!.Id;
                var uspResult = await query.USP_PRODUCT_SEL_BY_ID(uspRequest);
                
                if (uspResult != null)
                {
                    var data = mapper.Map<USP_PRODUCT_SEL_BY_ID_Result, GetProductByIdResponseDto>(uspResult);

                    // BEGIN Conection External API
                    var uri = configurationExternalApi.Url;
                    var endPoint = configurationExternalApi.EndPoint;

                    uri = uri + endPoint;
                    var valueToken = jwtTokenService.GetToken();
                    var client = new RestClient();
                    var requestHttp = new RestRequest(uri, Method.Get);
                    requestHttp.AddHeader("Content-Type", "application/json");
                    requestHttp.AddHeader("Accept", "application/json");
                    requestHttp.AddHeader("Authorization", "Bearer " + valueToken);

                    requestHttp.AddQueryParameter("productId", request.ProductId.Value);
                    
                    var responseClient = client.Execute(requestHttp);
                    string resultString = responseClient.Content;
                    decimal DiscountRate = 0;
                    if (responseClient.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var externalApiResponse = JsonConvert.DeserializeObject<BaseResponse<List<GetProductDiscountByProductIdResponseDto>>>(resultString);
                        if (externalApiResponse.Data.Any())
                        {
                            DiscountRate = externalApiResponse.Data.FirstOrDefault().DiscountRate;
                            data.Discount = DiscountRate;
                            data.FinalPrice = Math.Round( (data.Price*100- DiscountRate)/100 , 2);
                        }
                    }
                    // END Conection External API

                    // BEGIN Get data Caching
                    var statusData = await statusApplication.GetAll();
                    if (statusData.Data.Count > 0)
                    {
                        var statusItem = statusData.Data.Where(x => x.StatusId == data.Status).FirstOrDefault();
                        if (statusItem != null)
                        {
                            data.StatusName = statusItem.StatusName;
                        }
                    }
                    // END Get data Caching

                    response.Data = data;
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

    }
}