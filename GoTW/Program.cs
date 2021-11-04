using BlazorStrap;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoTW
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBootstrapCss();

            string apiAddress = string.Empty;
            if (builder.HostEnvironment.IsDevelopment())
                apiAddress = "https://localhost:44309/";
            else
                apiAddress = "https://gotwapi.azurewebsites.net/";
 
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });
            builder.Services.AddHttpClient<GoTWHttp>("GoTWApi", client => client.BaseAddress = new Uri(apiAddress));

            await builder.Build().RunAsync();
        }
    }
}
