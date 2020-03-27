using MFedatto.Wermo.Domain.Business.Queries.v01_0.IGetMockResponse;
using System;
using System.Threading.Tasks;

namespace MFedatto.Wermo.Business.Queries.v01_0.GetMockResponse
{
	public class GetMockResponseQuery : IGetMockResponseQuery
	{
		public IGetMockResponseResponse Execute(IGetMockResponseRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<IGetMockResponseResponse> ExecuteAsync(IGetMockResponseRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
