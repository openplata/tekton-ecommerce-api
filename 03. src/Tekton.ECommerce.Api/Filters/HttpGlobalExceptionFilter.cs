using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using OP.FK_Framework.Dto.Response;
using Tekton.EComerce.Api.Infrastructure;

namespace Tekton.ECommerce.Api.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter, IFilterMetadata
    {
        private readonly IWebHostEnvironment env;

        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult), context.Exception, context.Exception.Message);
            if (context.Exception.GetType() == typeof(BusinessRuleValidationException))
            {
                List<MessageResponse> list = new List<MessageResponse>();
                string text = context.Exception.Source ?? "";
                list.Add(new MessageResponse(context.Exception.Message.ToString(), (text == "") ? "00" : text));
                BaseResponse<string> error = new BaseResponse<string>
                {
                    Success = false,
                    Code = "",
                    Message = "Ha sucedido un error al acceder al recurso",
                    Validations = list
                };

                context.Result = new BadRequestObjectResult(error);
                context.HttpContext.Response.StatusCode = 400;
            }
            else
            {
                BaseResponse<bool> statusResponse = new BaseResponse<bool>
                {
                    Success = false,
                    Code = "",
                    Message = "Ha sucedido un error al acceder al recurso"                    
                };
                if (env.IsDevelopment())
                {
                    statusResponse.Message = context.Exception.Message;
                }

                context.Result = new InternalServerErrorObjectResult(statusResponse);
                context.HttpContext.Response.StatusCode = 500;
            }

            context.ExceptionHandled = true;
        }
    }
}