using Controllers_v01_0 = MFedatto.Wermo.ApiLibrary.Controllers.v01_0;
using IControllers_v01_0 = MFedatto.Wermo.Domain.ApiLibrary.Controllers.v01_0;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MFedatto.Wermo.ApiGateway
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddSingleton<
			//	IControllers_v01_0.IMockupController,
			//	Controllers_v01_0.MockupController>();

			services.AddConnections();
			services.AddHealthChecks();

			//services.AddSwaggerGen(options =>
			//{
			//	options.SwaggerDoc(
			//		"v1",
			//		new OpenApiInfo
			//		{
			//			Title = "Wermo",
			//			Version = "v1"
			//		});
			//	options.CustomSchemaIds(i => i.FullName);
			//});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapControllers();
			//});

			//app.UseSwagger();

			//app.UseSwaggerUI(options =>
			//{
			//	options.SwaggerEndpoint(
			//		"/swagger/v1/swagger.json",
			//		"Wermo 1.0");
			//});
		}
	}
}
