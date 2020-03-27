using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace MFedatto.Wermo.CrossCutting.IoC.ServiceConfigurators
{
	public class ApiGatewayServiceConfigurator : IServiceConfigurator
	{
		public void ConfigureServices(
			IServiceCollection services,
			IConfiguration configuration,
			IWebHostEnvironment env,
			Assembly appPart)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1.0.0",
					Title = $"Wermo v1.0",
					Description = "Wermo is a web request mockup solution",
					TermsOfService = new Uri("https://github.com/mfedatto/wermo"),
					Contact =
						new OpenApiContact
						{
							Name = "Maurício Fedatto",
							Email = "mfedatto@gmail.com",
						},
					License =
						new OpenApiLicense
						{
							Name = "Apache-2.0",
							Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
						}
				});
			});

			services.AddControllers();
			services.AddConnections();
			services.AddHealthChecks();
			//services.AddApplicationInsightsTelemetry();
		}
	}
}
