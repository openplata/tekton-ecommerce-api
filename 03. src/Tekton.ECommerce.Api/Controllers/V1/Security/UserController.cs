using Autofac.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.IApplication.UseCases.Security.User;

namespace Tekton.ECommerce.Api.Controllers.V1.Security
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/security/users")]
    public class UserController : BaseAuthController
    {
        private readonly IUserService service;

        public UserController(IUserService _service)
        {
            service = _service;
        }

        [HttpGet("All")]
        [SwaggerOperation(Tags = new[] { "Security - Usuarios" }, Summary = "Listar usuarios", OperationId = "GetAll")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAll();
            result.Data.ForEach(a => a.Password = "XXXXX");
            return Ok(result);
        }
    }
}