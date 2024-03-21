using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.Dto.Auth.Login;
using Tekton.ECommerce.IApplication.UseCases.Auth;

namespace Tekton.ECommerce.Api.Controllers.V1.Auth
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/auth/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService _service)
        {
            service = _service;
        }

        /// <summary>
        /// Actualizar tablas/ítems
        /// </summary>
        /// /// <remarks>
        ///  <strong>Ejemplos:</strong> <br></br>
        /// PUT .../api/v1/auth/login/signin<br></br>
        /// <example>Json de Ejemplo<br></br>
        /// <code>
        /// {
        ///   "ownerId": "1000",
        ///   "username": "COR",
        ///   "password": "01"
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
        ///         <td>ownerId</td>
        ///			<td>Obligatorio</td>
        ///         <td>Dígitos numéricos</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [ownerId] de ser números.</li>
        ///	                <li>Solo números mayor o igual a cero, sino cumple => El [ownerId] debe ser igual o mayor a cero.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>username</td>
        ///			<td>Obligatorio</td>
        ///         <td>Alfanumérico de longitud 20</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [username] debe ser mínimo de 3 y máximo de 20 caracteres.</li>
        ///	                <li>Valores solo letras, números sino cumple => El [username] debe tener entre 3 y 20 caracteres entre letra y/o dígito.</li>
        ///	            </ul>
        ///	        </td>
        ///     </tr>
        ///     <tr>
        ///         <td>password</td>
        ///			<td>Obligatorio</td>
        ///         <td>Caracter numérico</td>
        ///         <td>
        ///             <ul>
        ///	                <li>El [password] debe tener entre 1 y 10 dígitos.</li>
        ///	                <li>Valores solo números sino cumple => El [password] debe tener entre 1 y 10 dígitos.</li>
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
        [HttpPost("signin")]
        [SwaggerOperation(Tags = new[] { "Security - Auth" }, Summary = "Login del usuario", OperationId = "PostSignInRequestDto")]
        [Produces("application/json")]
        public async Task<IActionResult> PostSignIn([FromBody] PostSignInRequestDto request)
        {            
            var result = await service.PostSignIn(request);

            if (result.Success)
                return Ok(result);
            else
                return Unauthorized(result);
            
        }
    }
}