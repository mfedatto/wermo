using MFedatto.Wermo.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MFedatto.Wermo.ApiGateway
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		protected RootComposition RootComposition { get; set; }

		public Startup(
			IConfiguration configuration,
			IWebHostEnvironment environment)
		{
			Configuration = configuration;
			RootComposition = new RootComposition(
				Configuration,
				environment,
				typeof(Startup).GetTypeInfo()
					.Assembly);
		}

		public void ConfigureServices(
			IServiceCollection services)
		{
			RootComposition.ConfigureServices(services);
		}

		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env,
			IHostApplicationLifetime hostApplicationLifetime)
		{
			RootComposition.Configure(
				app,
				env,
				hostApplicationLifetime);
		}
	}
}
