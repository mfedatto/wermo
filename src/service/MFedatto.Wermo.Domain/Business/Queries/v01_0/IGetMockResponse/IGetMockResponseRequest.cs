namespace MFedatto.Wermo.Domain.Business.Queries.v01_0.IGetMockResponse
{
	public interface IGetMockResponseRequest
		: IQueryRequest
	{
		string MockName { get; }
		string RouteId { get; }
		string Slug { get; }
	}
}
