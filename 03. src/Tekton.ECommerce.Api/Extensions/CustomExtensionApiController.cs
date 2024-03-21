using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using OP.FK_Framework.Dto.Response;

namespace Tekton.ECommerce.Api.Extensions
{
    /// <summary>
    /// Custom ApiController
    /// </summary>
    public static class CustomExtensionApiController
    {
        public static IServiceCollection AddCustomApiController(this IServiceCollection Services)
        {
            //Services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    //options.SuppressConsumesConstraintForFormFileParameters = true;
            //    //options.SuppressInferBindingSourcesForParameters = true;
            //    //options.SuppressModelStateInvalidFilter = true;
            //});

            Services.PostConfigure((Action<ApiBehaviorOptions>)(options =>
            {
                var defaultFactory = options.InvalidModelStateResponseFactory;
                options.InvalidModelStateResponseFactory = context =>
                {
                    AllowSynchronousIO(context.HttpContext);

                    ////////////////////// CURRENT ModelValidation Filter /////////////
                    var modelState = context.ModelState;
                    var prop = modelState.Keys.ToList().FirstOrDefault();
                    var key = prop.Replace("$.", "");

                    var statusResponse = CustomResponse(context, key);
                    ////////////////////// CURRENT ModelValidation Filter /////////////
                    var result = defaultFactory(context);

                    var bad = result as BadRequestObjectResult;
                    if (bad?.Value is ValidationProblemDetails problem)
                        LogInvalidModelState(context, problem);

                    return new BadRequestObjectResult(statusResponse);
                };
            }));
            return Services;
        }

        private static void AllowSynchronousIO(HttpContext httpContext)
        {
            IHttpBodyControlFeature? maybeSyncIoFeature = httpContext.Features.Get<IHttpBodyControlFeature>();
            if (maybeSyncIoFeature is IHttpBodyControlFeature syncIoFeature)
                syncIoFeature.AllowSynchronousIO = true;
        }

        private static BaseResponse<IEnumerable<bool>> CustomResponse(ActionContext context, string key)
        {
            var validations = CustomMessageResponse(context, key);
            return new BaseResponse<IEnumerable<bool>>()
            {
                Code = "40001",
                Message = "Solicitud con inconsistencias.",
                Success = false,
                Data = new List<bool>(),
                Validations = validations
            };
        }

        private static List<MessageResponse> CustomMessageResponse(ActionContext context, string key)
        {
            var validations = new List<MessageResponse>();
            var index = 0;
            foreach (var model in context.ModelState.Values)
            {
                var errors = model.Errors;
                if (errors.Count > 0)
                {
                    var error = errors.FirstOrDefault();
                    var errorMessage = (
                             error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int16")) ? "El parámetro " + key + " contiene valores no permitidos, valores permitidos (Int16)"
                        : (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Date")) ? $"El parámetro {key}  contiene valores no permitidos, el valor del parámetro no cumple con el formato aaaa-mm-dd."
                        : (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Boolean")) ? $"El parámetro {key} contiene valores no permitidos, valores permitidos(true,false) ."
                        : (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.String")) ? $"El parámetro {key} contiene valores no permitidos, valores permitidos (string)"
                        : (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int32")) ? $"El parámetro {key} contiene valores no permitidos, valores permitidos (Int32)"
                        : error.ErrorMessage.Contains("The JSON value could not be converted") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage.Contains("The JSON object contains a trailing comma") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage.Contains("is an invalid start of a") ? "La petición HTTP contiene esquema Json no válido."
                        : error.ErrorMessage;

                    validations.Add(new MessageResponse(errorMessage, index.ToString()));
                    index++;
                }
            }
            return validations;
        }

        private static List<MessageResponse> CustomMessageDateResponse(ActionContext context, string key)
        {
            var validations = new List<MessageResponse>();
            foreach (var error in context.ModelState)
            {
                string message = error.Value.Errors != null && error.Value.Errors.Count() > 0 ?
                                    error.Value.Errors[0].Exception != null ?
                                            error.Key + " : " + error.Value.Errors[0].Exception.Message   //More weight-age is given to exception, so in case of one, use the exception message
                                    : error.Value.Errors[0].ErrorMessage != null ?
                                            error.Key + " : " + error.Value.Errors[0].ErrorMessage //Otherwise use error message
                                    : string.Empty
                            : string.Empty;

                if (!string.IsNullOrWhiteSpace(message))
                {
                    validations.Add(new MessageResponse(message, context.HttpContext.TraceIdentifier));
                }
            }

            return validations;
        }

        private static List<string> GetModelStateError(ActionContext actionContext)
        {
            return actionContext.ModelState.Values.SelectMany(x => x.Errors)
                            .Select(x => x.ErrorMessage).ToList();
        }

        private static void LogInvalidModelState(ActionContext actionContext, ValidationProblemDetails error)
        {
            var errorJson = System.Text.Json.JsonSerializer.Serialize(error);

            var reqBody = actionContext.HttpContext.Request.Body;
            if (reqBody.CanSeek) reqBody.Position = 0;
            var sr = new System.IO.StreamReader(reqBody);
            string body = sr.ReadToEnd();

            actionContext.HttpContext
                .RequestServices.GetRequiredService<ILoggerFactory>()
                .CreateLogger(nameof(ApiBehaviorOptions.InvalidModelStateResponseFactory))
                .LogWarning("Invalid model state. Responded: '{ValidationProblemDetails}'. Received: '{Request}'", errorJson, body);
        }
    }
}