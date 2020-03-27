using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MFedatto.Wermo.ApiGateway.Controllers.v01_0
{
    [ApiController]
    [Route("/v01_0/mockup")]
    public class MockupController : ControllerBase
    {
        protected const string MockupBaseRoute = "mocks";
        protected const string MockupSlugRoute = MockupBaseRoute + "/{mock-name}/{*slug}";

        [HttpGet(MockupSlugRoute)]
        [HttpPost(MockupSlugRoute)]
        [HttpPut(MockupSlugRoute)]
        [HttpDelete(MockupSlugRoute)]
        [HttpOptions(MockupSlugRoute)]
        [HttpHead(MockupSlugRoute)]
        [HttpPatch(MockupSlugRoute)]
        public async Task<ActionResult> GetMockupResponse(
            [FromRoute(Name = "mock-name")] string mockName,
            [FromRoute(Name = "slug")] string slug)
        {
            return Ok(
                JsonConvert.SerializeObject(
                        new
                        {
                            MockName = mockName,
                            Route = slug
                        }
                    ));
        }
    }
}