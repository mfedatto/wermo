using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace MFedatto.Wermo.ApiGateway
{
	public class Program
	{
		public static void Main(string[] args) =>
			CreateHostBuilder(args)
				.Build()
				.Run();

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.AddJsonFile(
							Path.Combine(AppContext.BaseDirectory,
								"appsettings.json"),
							optional: true,
							reloadOnChange: true)
						.AddJsonFile(
							Path.Combine(AppContext.BaseDirectory,
								$"appsettings.{hostingContext.HostingEnvironment.EnvironmentName.ToLower()}.json"),
							optional: true,
							reloadOnChange: true);
					config.AddEnvironmentVariables();
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
