using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OP.FK_Framework.Dto.Response;

namespace Tekton.ECommerce.Api.Filters
{
    public class GeneralModelValidation : ActionFilterAttribute, IActionFilter, IFilterMetadata
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var modelState = context.ModelState;
                var prop = modelState.Keys.ToList().FirstOrDefault();
                var key = prop.Replace("$.", "");

                var validations = new List<MessageResponse>();
                var index = 0;
                foreach (var model in context.ModelState.Values)
                {
                    var errors = model.Errors;
                    if (errors.Count > 0)
                    {
                        var error = errors.FirstOrDefault();
                        //var errorMessage = (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int")) ? "El parámetro " + key + " contiene valores no permitidos."
                        //    : error.ErrorMessage.Contains("The JSON value could not be converted") ? "La petición HTTP contiene esquema Json no válido."
                        //    : error.ErrorMessage.Contains("The JSON object contains a trailing comma") ? "La petición HTTP contiene esquema Json no válido."
                        //    : error.ErrorMessage.Contains("is an invalid start of a") ? "La petición HTTP contiene esquema Json no válido."
                        //    : error.ErrorMessage;
                        //validations.Add(new MessageStatusResponse(errorMessage, index.ToString()));
                        var errorMessage = (
                       error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Int16")) ? "El parámetro " + key + " contiene valores no permitidos, valores permitidos (Int16)"
                     : (error.ErrorMessage.Contains("The JSON value could not be converted") && error.ErrorMessage.Contains("System.Date")) ? $"El parámetro {key}  contiene valores no permitidos, el valor del parámetro no cumple con el formato aaaa-mm-dd."
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

                var statusResponse = new BaseResponse<IEnumerable<bool>>()
                {
                    Code = "40001",
                    Message = "Solicitud con inconsistencias.",
                    Success = false,
                    Data = new List<bool>(),
                    //Validations = context.ModelState.Values
                    //                .SelectMany(x => x.Errors)
                    //                .Select((x, ixc) => new MessageStatusResponse((x.ErrorMessage.Contains("The JSON value could not be converted") ? "El valor '" + key + "' no es correcto." : x.ErrorMessage), ixc.ToString())).ToList<MessageStatusResponse>()
                    Validations = validations
                };
                context.Result = new BadRequestObjectResult(statusResponse);
                return;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}