using Controllers_v01_0 = MFedatto.Wermo.ApiLibrary.Controllers.v01_0;
using IControllers_v01_0 = MFedatto.Wermo.Domain.ApiLibrary.Controllers.v01_0;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MFedatto.Wermo.CrossCutting.IoC.ServiceConfigurators
{
	public class ApiLibraryServiceConfigurator : IServiceConfigurator
	{
		public void ConfigureServices(
			IServiceCollection services,
			IConfiguration configuration,
			IWebHostEnvironment env,
			Assembly appPart)
		{
			services
				.AddSingleton<
					IControllers_v01_0.IMockupController,
					Controllers_v01_0.MockupController>();
		}
	}
}
