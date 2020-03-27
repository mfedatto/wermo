using System;
using System.IO;
using System.Reflection;
using MFedatto.Wermo.CrossCutting.IoC.Configurators;
using MFedatto.Wermo.CrossCutting.IoC.ServiceConfigurators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Debugging;

namespace MFedatto.Wermo.CrossCutting.IoC
{
	public class RootComposition
	{
		protected readonly IConfiguration _configuration;
		protected readonly IWebHostEnvironment _webHostEnvironment;
		protected readonly IServiceConfigurator[] _serviceConfigurators;
		protected readonly IConfigurator[] _configurators;
		protected readonly Assembly _startupAppPart;

		public RootComposition(
			IConfiguration configuration,
			IWebHostEnvironment environment,
			Assembly startupAppPart)
		{
			_configuration = configuration;
			_webHostEnvironment = environment;
			_startupAppPart = startupAppPart;

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(_configuration)
				.CreateLogger();

			SelfLog.Enable(msg => File.AppendAllText(
				Path.Combine(AppContext.BaseDirectory,
					"serilogSelfLog.txt"),
				$"{msg}\n\r"));

			_serviceConfigurators = new IServiceConfigurator[]
			{
				new ApiLibraryServiceConfigurator(),
				new ApiGatewayServiceConfigurator()
			};

			_configurators = new IConfigurator[]
			{
				new ApiGatewayConfigurator()
			};
		}

		public void ConfigureServices(
			IServiceCollection services)
		{
			services.AddLogging(loggingBuilder =>
			{
				loggingBuilder.AddSerilog(dispose: true);
			});

			for (int i = 0; i < _serviceConfigurators.Length; i++)
			{
				_serviceConfigurators[i].ConfigureServices(
					services,
					_configuration,
					_webHostEnvironment,
					_startupAppPart);
			}
		}

		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env,
			IHostApplicationLifetime hostApplicationLifetime)
		{
			//hostApplicationLifetime.ApplicationStopped
			//	.Register(Log.CloseAndFlush);

			for (int i = 0; i < _configurators.Length; i++)
			{
				_configurators[i].Configure(app, env);
			}
		}
	}
}
