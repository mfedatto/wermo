using MFedatto.Wermo.Domain.Business;
using MFedatto.Wermo.Domain.Business.Commands;
using MFedatto.Wermo.Domain.ExtensionMethods;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace MFedatto.Wermo.Business.Commands
{
	public static class ExtensionMethods
	{
		static Regex InferCommandTypeNamePatternExpression
			=> new Regex(@"^\[([^\]]+)Request\]$");
		static string InferCommandTypeNameReplaceExpression
			=> "[$1Command`1[$1Request]]";

		public static Type GetCommandType(this ICommandRequest request)
		{
			var commandTypeName = InferCommandTypeNamePatternExpression.Replace(
					request.GetType().ToString(),
					InferCommandTypeNameReplaceExpression);
			
			return request.GetType().Assembly.GetType(commandTypeName);
		}

		public static void LogBeforeCommand<TRequest>(
			this ILogger<ICommandQueryHandler> _logger,
			TRequest request,
			Guid? commandExecutionGuid = null)
			where TRequest : ICommandRequest
		{
			Type commandType = request.GetCommandType();
			string queryLogEntry = commandType.GetNameWithGenerics();
			string guidSufix = (commandExecutionGuid.HasValue)
				? $" [#{commandExecutionGuid.ToString()}]"
				: string.Empty;

			queryLogEntry = Regex.Replace(queryLogEntry, @"([A-Z])", " $1").ToLower();
			queryLogEntry = Regex.Replace(queryLogEntry, @" (.*) command$", "[business command] $1");
			queryLogEntry += guidSufix;

			_logger.LogTrace(queryLogEntry);
			_logger.LogDebug($"Executando command '{commandType.GetNameWithGenerics()}' com o request '{JsonConvert.SerializeObject(request)}'{guidSufix}");
		}

		public static void LogAfterCommand<TRequest>(
			this ILogger<ICommandQueryHandler> _logger,
			TRequest request,
			Guid? commandExecutionGuid = null)
			where TRequest : ICommandRequest
		{
			string guidSufix = (commandExecutionGuid.HasValue)
				? $" [#{commandExecutionGuid.ToString()}]"
				: string.Empty;

			_logger.LogDebug($"Executado command '{request.GetCommandType().GetNameWithGenerics()}'{guidSufix}");
		}

		public static void LogCommandError<TRequest>(
			this ILogger<ICommandQueryHandler> _logger,
			TRequest request,
			Exception ex,
			Guid? commandExecutionGuid = null)
			where TRequest : ICommandRequest
		{
			Type commandType = request.GetCommandType();
			string guidSufix = (commandExecutionGuid.HasValue)
				? $" [#{commandExecutionGuid.ToString()}]"
				: string.Empty;

			_logger.LogError(ex, $"Erro ao executar command '{commandType.GetNameWithGenerics()}'{guidSufix}");
		}
	}
}
