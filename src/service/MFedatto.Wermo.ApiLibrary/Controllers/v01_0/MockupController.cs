using MFedatto.Wermo.Domain.ApiLibrary.Controllers.v01_0;
using System.Threading.Tasks;

namespace MFedatto.Wermo.ApiLibrary.Controllers.v01_0
{
	public class MockupController : IMockupController
	{
		public string GetMockupResponse(
			string mockupName,
			string routeId,
			string slug)
		{
			return GetMockupResponseAsync(
					mockupName,
					routeId,
					slug)
				.Result;
		}

		public async Task<string> GetMockupResponseAsync(
			string mockupName,
			string routeId,
			string slug)
		{
			return slug;
		}
	}
}
