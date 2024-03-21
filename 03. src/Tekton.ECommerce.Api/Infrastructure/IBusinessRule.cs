using Microsoft.AspNetCore.Mvc;

namespace Tekton.EComerce.Api.Infrastructure
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error)
            : base(error)
        {
            base.StatusCode = 500;
        }
    }
}