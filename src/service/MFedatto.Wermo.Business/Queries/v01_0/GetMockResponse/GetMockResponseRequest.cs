using MFedatto.Wermo.Domain.Business.Queries.v01_0.IGetMockResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFedatto.Wermo.Business.Queries.v01_0.GetMockResponse
{
	public class GetMockResponseRequest : IGetMockResponseRequest
	{
		public string MockName { get; }
		public string RouteId { get; }
		public string Slug { get; }
		public bool IsValid
			=> !string.IsNullOrEmpty(Slug)
				|| !string.IsNullOrEmpty(RouteId)
				|| (!string.IsNullOrEmpty(MockName)
					&& Slug != null);
	}
}
