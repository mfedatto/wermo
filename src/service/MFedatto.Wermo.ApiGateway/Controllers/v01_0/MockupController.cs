using System.Threading.Tasks;
using MFedatto.Wermo.Domain.ApiLibrary.Controllers.v01_0;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MFedatto.Wermo.ApiGateway.Controllers.v01_0
{
    [ApiController]
    [Route("/v01_0/mockup")]
    public class MockupController : ControllerBase
    {
        protected const string MockupBaseRoute = "mocks";
        protected const string MockupSlugRoute = MockupBaseRoute + "/{name}/{**slug}";

        protected readonly ILogger<MockupController> _logger;
        protected readonly IMockupController _mockupController;

        public MockupController(
            ILogger<MockupController> logger,
            IMockupController mockupController)
        {
            _logger = logger;
            _mockupController = mockupController;
        }

        [HttpGet(MockupSlugRoute)]
        [HttpPost(MockupSlugRoute)]
        [HttpPut(MockupSlugRoute)]
        [HttpDelete(MockupSlugRoute)]
        [HttpOptions(MockupSlugRoute)]
        [HttpHead(MockupSlugRoute)]
        [HttpPatch(MockupSlugRoute)]
        public async Task<ActionResult> GetMockupResponse(
            [FromRoute] string name,
            [FromRoute] string slug,
            [FromHeader(Name = "X-Wermo-RouteId")] string routeId = null)
        {
            return Ok(await _mockupController.GetMockupResponseAsync(
                    name,
                    routeId,
                    slug + Request.QueryString)
                .ConfigureAwait(false));
        }
    }
}
