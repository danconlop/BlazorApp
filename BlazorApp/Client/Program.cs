using BlazorApp.Client.Services.Abstractions;
using BlazorApp.Client.Services.Implementations;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Singleton: se instancia una sola vez a lo largo de toda la aplicacion
            //Scoped: Bajo la capa de cliente es lo mismo que el singleton, pero si se hace en el server que sobrevive mientras el request sigue vivo
            //  
            //Transient: Instancía un objeto en cada llamada, genera una nueva instancia del objeto cada que es llamado
            //services.AddSingleton<ServiceSingleton>();
            //services.AddTransient<ServiceTransient>();
            services.AddScoped<IMovieApi, MovieApi>();
            services.AddScoped<IGenreApi, GenreApi>();
            services.AddScoped<IActorApi, ActorApi>();
        }
    }
}
