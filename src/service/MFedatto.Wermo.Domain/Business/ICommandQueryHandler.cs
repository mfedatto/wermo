using MFedatto.Wermo.Domain.Business.Commands;
using System.Threading.Tasks;

namespace MFedatto.Wermo.Domain.Business
{
	public interface ICommandQueryHandler
	{
		void ExecuteCommand<TRequest>(TRequest request)
			where TRequest : ICommandRequest;
		Task ExecuteCommandAsync<TRequest>(TRequest request)
			where TRequest : ICommandRequest;
		TResponse ExecuteQuery<TRequest, TResponse>(TRequest request);
		Task<TResponse> ExecuteQueryAsync<TRequest, TResponse>(TRequest request);
	}
}
