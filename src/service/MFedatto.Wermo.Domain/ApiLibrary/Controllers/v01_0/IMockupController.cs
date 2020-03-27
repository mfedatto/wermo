using System.Threading.Tasks;

namespace MFedatto.Wermo.Domain.ApiLibrary.Controllers.v01_0
{
	public interface IMockupController
	{
		string GetMockupResponse(
			string mockupName,
			string routeId,
			string slug);
		Task<string> GetMockupResponseAsync(
			string mockupName,
			string routeId,
			string slug);
	}
}
