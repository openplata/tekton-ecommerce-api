using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.Dto.Core.Core;
using Tekton.ECommerce.IApplication.UseCases.Core;

namespace Tekton.ECommerce.Api.Controllers.V1.Core
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/core/core")]
    public class CoreController : BaseAuthController
    {
        private readonly ICoreService service;

        public CoreController(ICoreService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Registrar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// POST .../api/v1/core/core<br></br>
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
        ///         <td>coreName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreName] debe ser m�nimo de 3 y m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [coreName] debe contener s�lo letras y n�meros.</li>
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
        [SwaggerOperation(Tags = new[] { "N�cleo - Tablas Generales" }, Summary = "Registrar tabla/�tem general", OperationId = "PostCoreRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] PostCoreRequestDto request)
        {
            var result = await service.Post(request);

            return Ok(result);
        }

        /// <summary>
        /// Actualizar tablas/�tems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// PUT .../api/v1/core/core<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "coreId": "1000",
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
        ///         <td>coreId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [coreId] debe ser igual o mayor a cero.</li>
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
        ///         <td>coreName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanum�rico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreName] debe ser m�nimo de 3 y m�ximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y n�meros , sino cumple => El [coreName] debe contener s�lo letras y n�meros.</li>
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
        [SwaggerOperation(Tags = new[] { "N�cleo - Tablas Generales" }, Summary = "Actualizar tabla/�tem general", OperationId = "PutCoreRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> Put([FromBody] PutCoreRequestDto request)
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
        /// GET .../api/v1/core/core<br></br>
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
        ///         <td>coreId</td>
        ///			<td>Obligatorio</td>
        ///         <td>D�gitos num�ricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreId] de ser n�meros.</li>
        ///	                <li>Solo n�meros mayor o igual a cero, sino cumple => El [coreId] del padre debe ser igual o mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "N�cleo - Tablas Generales" }, Summary = "Obtener tabla/�tem general", OperationId = "GetCoreByIdRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromQuery] GetCoreByIdRequestDto request)
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
        /// GET .../api/v1/core/core/all-by-parent-id<br></br>
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
        [HttpGet("get-all-by-parent-id")]
        [SwaggerOperation(Tags = new[] { "N�cleo - Tablas Generales" }, Summary = "Obtener �tems por parentId", OperationId = "GetCoreAllByParentIdRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllByParentId([FromQuery] GetCoreAllByParentIdRequestDto request)
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