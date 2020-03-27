using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MFedatto.Wermo.CrossCutting.IoC
{
	public interface IServiceConfigurator
	{
		void ConfigureServices(
			IServiceCollection services,
			IConfiguration configuration,
			IWebHostEnvironment env,
			Assembly appPart);
	}
}
