using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tekton.ECommerce.IApplication.UseCases.Core;

namespace Tekton.ECommerce.Api.Controllers.V1.Security
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/core/status")]
    public class StatusController : BaseAuthController
    {
        private readonly IStatusService service;

        public StatusController(IStatusService _service)
        {
            service = _service;
        }

        [HttpGet("All")]
        [SwaggerOperation(Tags = new[] { "Core - Estados" }, Summary = "Listar estados", OperationId = "GetAll")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAll();

            return Ok(result);
        }
    }
}