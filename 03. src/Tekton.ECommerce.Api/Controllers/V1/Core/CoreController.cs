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
        /// Registrar tablas/ítems
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
        ///	<b>Parámetros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Parámetro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripción/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>code</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanumérico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [code] debe tener un máximo de 5 caracteres.</li>
        ///	                <li>Valores solo letras, números sino cumple => El [code] debe tener un máximo 5 caracteres entre letra y/o dígito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter numérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener hasta 10 dígitos.</li>
        ///	                <li>Valores solo números sino cumple => El [ordering] debe tener un máximo de 10 dígitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>coreName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanumérico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreName] debe ser mínimo de 3 y máximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y números , sino cumple => El [coreName] debe contener sólo letras y números.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>color</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [color] debe ser máximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [color] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>icon</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [icon] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [icon] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data1</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data1] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [data1] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data2</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data2] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [data2] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>additional</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [additional] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [additional] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>abservation</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [abservation] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [abservation] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser número.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [parentId] del padre debe ser igual o mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "Núcleo - Tablas Generales" }, Summary = "Registrar tabla/ítem general", OperationId = "PostCoreRequest")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] PostCoreRequestDto request)
        {
            var result = await service.Post(request);

            return Ok(result);
        }

        /// <summary>
        /// Actualizar tablas/ítems
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
        ///	<b>Parámetros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Parámetro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripción/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>coreId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreId] de ser números.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [coreId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>code</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanumérico de longitud 5</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [code] debe tener un máximo de 5 caracteres.</li>
        ///	                <li>Valores solo letras, números sino cumple => El [code] debe tener un máximo 5 caracteres entre letra y/o dígito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>ordering</td>
        ///			<td>Opcional</td>
        ///         <td>Caracter numérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ordering] debe tener hasta 10 dígitos.</li>
        ///	                <li>Valores solo números sino cumple => El [ordering] debe tener un máximo de 10 dígitos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>coreName</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanumérico de longitud 50</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreName] debe ser mínimo de 3 y máximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras y números , sino cumple => El [coreName] debe contener sólo letras y números.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>color</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [color] debe ser máximo de 50 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [color] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>icon</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [icon] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [icon] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data1</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data1] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [data1] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>data2</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [data2] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [data2] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>additional</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [additional] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [additional] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>abservation</td>
        ///			<td>Opcional</td>
        ///         <td>Alfanumérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [abservation] debe ser máximo de 100 caracteres.</li>
        ///	                <li>Valores solo letras, números y caracteres especiales # º , / - . ´ ( ) ’, sino cumple => El [abservation] tiene caracteres inválidos.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser números.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [parentId] del padre debe ser igual o mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "Núcleo - Tablas Generales" }, Summary = "Actualizar tabla/ítem general", OperationId = "PutCoreRequest")]
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
        /// Obtener tablas/ítems
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
        ///	<b>Parámetros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Parámetro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripción/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>coreId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [coreId] de ser números.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [coreId] del padre debe ser igual o mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "Núcleo - Tablas Generales" }, Summary = "Obtener tabla/ítem general", OperationId = "GetCoreByIdRequest")]
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
        /// Obtener tablas/ítems
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
        ///	<b>Parámetros</b>
        /// <table border="1">
        ///		<tr>
        ///			<td width="180px"><strong>Parámetro</strong></td>
        ///			<td width="150px"><strong>Requerido</strong></td>
        ///			<td width="280px"><strong>Valor(es)</strong></td>
        ///			<td><strong>Descripción/Restricciones</strong></td>
        ///     </tr>
        ///     <tr>
        ///         <td>parentId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [parentId] de ser números.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [parentId] del padre debe ser igual o mayor a cero.</li>
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
        [SwaggerOperation(Tags = new[] { "Núcleo - Tablas Generales" }, Summary = "Obtener ítems por parentId", OperationId = "GetCoreAllByParentIdRequest")]
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