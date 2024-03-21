using Autofac.Core;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.Dto.Core.ProductDiscount;
using Tekton.ECommerce.IApplication.UseCases.Core;

namespace Tekton.ECommerce.Api.Controllers.V1.Security
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/core/product-discounts")]
    public class ProductDiscountController : BaseAuthController
    {
        private readonly IProductDiscountService service;

        public ProductDiscountController(IProductDiscountService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Obtener descuento de producto
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// GET .../api/v1/core/product-discounts/get-by-product-id<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "productId": "1"
        /// }
        /// </code>
        /// </example>
        /// <br></br>
        ///	<b>Parámetros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Parámetro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripción/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>productId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productId] de ser número.</li>
        ///	                <li>Solo números mayor a cero, sino cumple => El [productId] debe ser mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>        
        /// </table>
        ///	<br/>
        ///	<br/>
        ///	<b>Reglas de negocio</b>
        ///	<ul>
        ///	<li>No definido.</li>
        ///	</ul>
        ///	</remarks>
        /// <response code="200">Solicitud satisfactoria.</response>
        /// <response code="400">Solicitud con inconsistencias.</response> 
        [HttpGet("get-by-product-id")]
        [SwaggerOperation(Tags = new[] { "Core - Descuentos de Productos" }, Summary = "Obtener descuentos por productId", OperationId = "GetProductDiscountByProductIdRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByProductId([FromQuery] GetProductDiscountByProductIdRequestDto request)
        {
            var result = await service.GetAll();

            var data = result.Data;

            if (data.Any())
            {
                var productDiscount = data.Where(x => x.ProductId == request.ProductId).FirstOrDefault();
                if (productDiscount != null)
                {
                    var items = new List<GetProductDiscountByProductIdResponseDto>();
                    items.Add(productDiscount);
                    result.Data = items;
                    return Ok(result);
                }
                else
                {
                    result.Success = false;
                    result.Code = StatusCodes.Status204NoContent.ToString();
                    result.Data = [];
                    return NoContent();
                }
            }
            else
                return NoContent();
        }
    }
}