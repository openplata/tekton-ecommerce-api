using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.Dto.Core.Core;
using Tekton.ECommerce.Dto.Core.Product;
using Tekton.ECommerce.Dto.ExternalApi;
using Tekton.ECommerce.IApplication.UseCases.Core;

namespace Tekton.ECommerce.Api.Controllers.V1.Core
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/core/products")]
    public class ProductController : BaseAuthController
    {
        private readonly IProductService service;
        private readonly IConfiguration configuration;

        public ProductController(IProductService _service, IConfiguration _configuration)
        {
            service = _service;
            configuration = _configuration;
        }

        /// <summary>
        /// Registrar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// POST .../api/v1/core/products<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "code": "COR",
        ///   "externalCode": "EXT-COR",
        ///   "productName": "Detalle",
        ///   "ProductDescription": "Detalle",
        ///   "ordering": "01",
        ///   "barcode": "01",
        ///   "brandId": 0,
        ///   "categoryId": 0,
        ///   "subcategoryId": 0,
        ///   "stockt": 0,
        ///   "price": 0,
        ///   "color": "",
        ///   "icon": "",
        ///   "data1": "",
        ///   "data2": "",
        ///   "additional": "",
        ///   "observation": "",        
        ///   "status": "1"
        /// }
        /// </code>
        /// </example>
        /// <br></br>
        ///	<b>Par�metros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Par�metro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripci�n/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>code</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [code] debe tener un m�ximo de 5 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [code] debe tener entre 3 y 5 caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>externalCode</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [externalCode] debe tener un m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [externalCode] debe tener un m�ximo de caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>productName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productName] debe ser m�nimo de 3 y m�ximo de 10 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [productName] debe contener s�lo letras y n�meros.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>productDescription</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productDescription] debe ser m�nimo de 3 y m�ximo de 500 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [productDescription] debe contener s�lo letras y n�meros.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener entre 1 y 10 d�gitos.</li>
        ///	                <li>Valores solo n�meros sino cumple => El [ordering] debe tener entre 1 y 10 d�gitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>barcode</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [barcode] debe tener un m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [barcode] debe tener un m�ximo 50 de caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>brandId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [brandId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [brandId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>categoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [categoryId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>subcategoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [subcategoryId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [subcategoryId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>stock</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [stock] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [stock] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>price</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [price] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [price] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>color</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [color] debe ser m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [color] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>icon</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [icon] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [icon] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data1</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data1] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [data1] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data2</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data2] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [data2] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>additional</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [additional] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [additional] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>abservation</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [abservation] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [abservation] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>Status</td>
        ///			<td>Obligatorio</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///                 <li>Status del producto.</li>
        ///	                <li>Valores fijos "0" o "1", sino cumple => El status debe tener 1 d�gito positivo, comprendido entre 0 y 1.</li>
        ///	            </ul>
        ///         </td>
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
        [HttpPost]        
        [SwaggerOperation(Tags = new[] { "N�cleo - Productos" }, Summary = "Registrar productos", OperationId = "PostProductRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] PostProductRequestDto request)
        {
            var result = await service.Post(request);

            return Ok(result);
        }

        /// <summary>
        /// Actualizar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// PUT .../api/v1/core/products<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "productId": "1000",
        ///   "code": "COR",
        ///   "externalCode": "EXT-COR",
        ///   "productName": "Detalle",
        ///   "ProductDescription": "Detalle",
        ///   "ordering": "01",
        ///   "barcode": "01",
        ///   "brandId": 0,
        ///   "categoryId": 0,
        ///   "subcategoryId": 0,
        ///   "stockt": 0,
        ///   "price": 0,
        ///   "color": "",
        ///   "icon": "",
        ///   "data1": "",
        ///   "data2": "",
        ///   "additional": "",
        ///   "observation": "", 
        ///   "status": "1",
        ///   "isActive": true
        /// }
        /// </code>
        /// </example>
        /// <br></br>
        ///	<b>Par�metros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Par�metro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripci�n/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>code</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [code] debe tener un m�ximo de 5 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [code] debe tener entre 3 y 5 caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>externalCode</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [externalCode] debe tener un m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [externalCode] debe tener un m�ximo de caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>productName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productName] debe ser m�nimo de 3 y m�ximo de 10 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [productName] debe contener s�lo letras y n�meros.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>productDescription</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productDescription] debe ser m�nimo de 3 y m�ximo de 500 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [productDescription] debe contener s�lo letras y n�meros.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener entre 1 y 10 d�gitos.</li>
        ///	                <li>Valores solo n�meros sino cumple => El [ordering] debe tener entre 1 y 10 d�gitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>barcode</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [barcode] debe tener un m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [barcode] debe tener un m�ximo 50 de caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>brandId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [brandId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [brandId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>categoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [categoryId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>subcategoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [subcategoryId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [subcategoryId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>stock</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [stock] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [stock] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>price</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [price] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [price] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>color</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [color] debe ser m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [color] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>icon</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [icon] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [icon] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data1</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data1] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [data1] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data2</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data2] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [data2] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>additional</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [additional] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [additional] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>abservation</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanum�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [abservation] debe ser m�ximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros y caracteres especiales # � , / - . � ( ) �, sino cumple => El [abservation] tiene caracteres inv�lidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>Status</td>
        ///			<td>Obligatorio</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///                 <li>Status del producto.</li>
        ///	                <li>Valores fijos "0" o "1", sino cumple => El status debe tener 1 d�gito positivo, comprendido entre 0 y 1.</li>
        ///	            </ul>
        ///         </td>
        ///     </tr>
        ///     <tr>
        ///         <td>isActive</td>
        ///			<td>Obligatorio</td>
        ///         <td>Booleano</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [isActive] de ser booleano.</li>
        ///	                <li>Solo true o false, sino cumple => El [isActive] debe ser true o false.</li>
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
        [HttpPut]
        [SwaggerOperation(Tags = new[] { "N�cleo - Productos" }, Summary = "Actualizar productos", OperationId = "PutProductRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> Put([FromBody] PutProductRequestDto request)
        {
            var result = await service.Put(request);

            return Ok(result);
        }

        /// <summary>
        /// Obtener tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// GET .../api/v1/core/products<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "coreId": "1000"
        /// }
        /// </code>
        /// </example>
        /// <br></br>
        ///	<b>Par�metros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Par�metro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripci�n/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>productId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [productId] de ser n�mero.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [productId] debe ser igual o mayor a cero.</li>
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
        [HttpGet("get-by-id")]
        [SwaggerOperation(Tags = new[] { "N�cleo - Productos" }, Summary = "Obtener producto por Id", OperationId = "GetProductByIdRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromQuery] GetProductByIdRequestDto request)
        {
            var contigurationExternalApi = configuration.GetSection("ExternalApi").Get<ConfigurationExternalApiDto>();
            var result = await service.GetById(request, contigurationExternalApi);

            var data = result.Data;

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return NoContent();
        }

    }
}
