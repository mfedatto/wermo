using System.Threading.Tasks;

namespace MFedatto.Wermo.Domain.Business.Commands
{
	public interface ICommand<
		TRequest>
		where TRequest : ICommandRequest
	{
		void Execute(TRequest request);
		Task ExecuteAsync(TRequest request);
	}
}
