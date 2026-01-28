using CiccioGest.Application;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.Presenters;
using CiccioGest.Presentation.AppForm.Services;
using CiccioGest.Presentation.AppForm.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace CiccioGest.Presentation.AppForm
{
    public static class ConfigureServiceProviderExtensions
    {
        public static IServiceCollection ConfigureFormsApp(this IServiceCollection serviceCollection)
        {
            var gestConf = CiccioGestConfMgr.GetCurrent();
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation!)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            return serviceCollection
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    //loggingBuilder.AddNLog();
                    loggingBuilder.AddDebug();
                })

                .AddSingleton(gestConf)
                .ConfigureApplication(gestConf)

                .AddTransient<WindowService>()

                .AddTransient<MainPresenter>()
                .AddTransient<SettingPresenter>()

                .AddTransient<ArticoloPresenter>()
                .AddTransient<ArticoliPresenter>()
                .AddTransient<CategoriaPresenter>()
                .AddTransient<CategoriePresenter>()
                .AddTransient<ClientePresenter>()
                .AddTransient<ClientiPresenter>()
                .AddTransient<FatturaPresenter>()
                .AddTransient<FatturePresenter>()
                .AddTransient<FornitorePresenter>()
                .AddTransient<FornitoriPresenter>()

                .AddSingleton<MainView>()
                .AddSingleton<IMainView>(sp => sp.GetRequiredService<MainView>())
                .AddTransient<ISettingView, SettingView>()

                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<IArticoliView, ArticoliView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<ICategorieView, CategorieView>()
                .AddTransient<IClienteView, ClienteView>()
                .AddTransient<IClientiView, ClientiView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IFattureView, FattureView>()
                .AddTransient<IFornitoreView, FornitoreView>()
                .AddTransient<IFornitoriView, FornitoriView>()

                .AddTransient<SettingView>();
        }
    }
}
