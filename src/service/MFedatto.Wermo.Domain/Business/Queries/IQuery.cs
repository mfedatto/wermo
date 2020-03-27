using System.Threading.Tasks;

namespace MFedatto.Wermo.Domain.Business.Queries
{
	public interface IQuery<
		TRequest,
		TResponse>
		where TRequest : IQueryRequest
		where TResponse : IQueryResponse
	{
		TResponse Execute(TRequest request);
		Task<TResponse> ExecuteAsync(TRequest request);
	}
}
