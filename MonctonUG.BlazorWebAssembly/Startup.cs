using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using MonctonUG.BlazorWebAssembly.Pages;
using MonctonUG.BlazorWebAssembly.Services;
using System;
using System.Net.Http;

namespace MonctonUG.BlazorWebAssembly
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CounterService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
