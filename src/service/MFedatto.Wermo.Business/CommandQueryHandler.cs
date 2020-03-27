using MFedatto.Wermo.Business.Commands;
using MFedatto.Wermo.Domain.Business;
using MFedatto.Wermo.Domain.Business.Commands;
using MFedatto.Wermo.Domain.ExtensionMethods;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MFedatto.Wermo.Business
{
	public class CommandQueryHandler : ICommandQueryHandler
	{
		protected readonly ILogger<ICommandQueryHandler> _logger;
		protected readonly IServiceProvider _serviceProvider;

		public CommandQueryHandler(
			ILogger<ICommandQueryHandler> logger,
			IServiceProvider serviceProvider)
		{
			_logger = logger;
			_serviceProvider = serviceProvider;
		}

		public void ExecuteCommand<TRequest>(TRequest request)
			where TRequest : ICommandRequest
		{
			throw new NotImplementedException();
		}

		public async Task ExecuteCommandAsync<TRequest>(TRequest request)
			where TRequest : ICommandRequest
		{
			Type commandType = request.GetCommandType();
			Guid commandExecutionGuid = Guid.NewGuid();

			_logger.LogBeforeCommand(request, commandExecutionGuid);

			try
			{
				((ICommand<TRequest>)_serviceProvider.GetService(commandType))
					.Execute(request);

				_logger.LogAfterCommand(request, commandExecutionGuid);
			}
			catch(Exception ex)
			{
				_logger.LogCommandError(request, ex, commandExecutionGuid);

				throw;
			}
		}

		public TResponse ExecuteQuery<TRequest, TResponse>(TRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<TResponse> ExecuteQueryAsync<TRequest, TResponse>(TRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
