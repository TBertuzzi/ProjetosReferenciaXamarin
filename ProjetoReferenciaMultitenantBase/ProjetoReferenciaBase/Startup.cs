using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoReferenciaMultitenantBase.Services;
using ProjetoReferenciaMultitenantBase.Services.Dialog;
using ProjetoReferenciaMultitenantBase.Services.Navigation;
using ProjetoReferenciaMultitenantBase.ViewModels;
using Xamarin.Essentials;

namespace ProjetoReferenciaMultitenantBase
{
    public static class Startup
    {
        public static App Init(Action<HostBuilderContext,
            IServiceCollection> services)
        {
            var systemDir = FileSystem.CacheDirectory;
            Helpers.ResourcesHelper.ExtractSaveResource("ProjetoReferenciaMultitenantBase.appsettings.json", systemDir);
            var fullConfig = Path.Combine(systemDir, "ProjetoReferenciaMultitenantBase.appsettings.json");

            var host = new HostBuilder()
                            .ConfigureHostConfiguration(c =>
                            {
                                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                                c.AddJsonFile(fullConfig);
                            })
                            .ConfigureServices((c, x) =>
                            {
                                services(c, x);
                                ConfigureServices(c, x);
                            })
                            .ConfigureLogging(l => l.AddConsole(o =>
                            {
                                o.DisableColors = true;
                            }))
                            .Build();

            App.ServiceProvider = host.Services;

            return App.ServiceProvider.GetService<App>();
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            if (ctx.HostingEnvironment.IsDevelopment())
            {
                var variavelJson = ctx.Configuration["VariavelJson"];
            }

            services.AddSingleton<App>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IDialogService, DialogService>();

            services.AddTransient<MainPageViewModel>();
            ViewModelLocator.Current.Mappings.Add(typeof(MainPageViewModel), typeof(MainPage));
        }
    }
}
