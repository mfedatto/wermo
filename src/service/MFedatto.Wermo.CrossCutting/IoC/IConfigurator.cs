using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MFedatto.Wermo.CrossCutting.IoC
{
    public interface IConfigurator
    {
        void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env);
    }
}
