using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.Dto.Core.Category;
using Tekton.ECommerce.Dto.Core.Core;
using Tekton.ECommerce.IApplication.UseCases.Core;

namespace Tekton.ECommerce.Api.Controllers.V1.Core
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/core/categories")]
    public class CategoryController : BaseAuthController
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Registrar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// POST .../api/v1/core/categories<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "code": "COR",
        ///   "ordering": "01",
        ///   "coreName": "Detalle",
        ///   "color": "",
        ///   "icon": "",
        ///   "data1": "",
        ///   "data2": "",
        ///   "additional": "",
        ///   "observation": "",
        ///   "parentId": 0
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
        ///	                <li>Valores solo letras, n�meros sino cumple => El [code] debe tener un m�ximo 5 caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener hasta 10 d�gitos.</li>
        ///	                <li>Valores solo n�meros sino cumple => El [ordering] debe tener un m�ximo de 10 d�gitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>categoryName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryName] debe ser m�nimo de 3 y m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [categoryName] debe contener s�lo letras y n�meros.</li>
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
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [parentId] del padre debe ser igual o mayor a cero.</li>
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
        [HttpPost]        
        [SwaggerOperation(Tags = new[] { "N�cleo - Categor�as" }, Summary = "Registrar categor�as", OperationId = "PostCategoryRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] PostCategoryRequestDto request)
        {
            var result = await service.Post(request);

            return Ok(result);
        }

        /// <summary>
        /// Actualizar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// PUT .../api/v1/core/categories<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "categoryId": "1000",
        ///   "code": "COR",
        ///   "ordering": "01",
        ///   "coreName": "Detalle",
        ///   "color": "",
        ///   "icon": "",
        ///   "data1": "",
        ///   "data2": "",
        ///   "additional": "",
        ///   "observation": "",
        ///   "parentId": 0
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
        ///         <td>categoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryId] de ser n�mero.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [categoryId] debe ser mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>code</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [code] debe tener un m�ximo de 5 caracteres.</li>
        ///	                <li>Valores solo letras, n�meros sino cumple => El [code] debe tener un m�ximo 5 caracteres entre letra y/o d�gito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter num�rico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener hasta 10 d�gitos.</li>
        ///	                <li>Valores solo n�meros sino cumple => El [ordering] debe tener un m�ximo de 10 d�gitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>categoryName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryName] debe ser m�nimo de 3 y m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [categoryName] debe contener s�lo letras y n�meros.</li>
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
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser n�mero.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [parentId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
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
        [SwaggerOperation(Tags = new[] { "N�cleo - Categor�as" }, Summary = "Actualizar categor�as", OperationId = "PutCategoryRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> Put([FromBody] PutCategoryRequestDto request)
        {
            var result = await service.Put(request);

            if (result.Success)
            {
                return Ok(result);
            }
            else
                return NoContent();
        }

        /// <summary>
        /// Obtener tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// GET .../api/v1/core/categories<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "categoryId": "1000"
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
        ///         <td>categoryId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [categoryId] de ser n�mero.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [categoryId] debe ser mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "N�cleo - Categor�as" }, Summary = "Obtener categor�as", OperationId = "GetCategoryByIdRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromQuery] GetCategoryByIdRequestDto request)
        {
            var result = await service.GetById(request);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return NoContent();            
        }

        /// <summary>
        /// Obtener tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// GET .../api/v1/core/categories/all-by-parent-id<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "parentId": "1000"
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
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser n�mero.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [parentId] debe ser igual o mayor a cero.</li>
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
        [HttpGet("get-all-by-parent-id")]
        [SwaggerOperation(Tags = new[] { "N�cleo - Categor�as" }, Summary = "Obtener �tems por parentId", OperationId = "GetCategoryAllByParentIdRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllByParentId([FromQuery] GetCategoryAllByParentIdRequestDto request)
        {
            var result = await service.GetAllByParentId(request);

            var data = result.Data;

            if (data.Any())
            {
                return Ok(result);
            }
            else
                return NoContent();
        }
    }
}