using CiccioGest.Infrastructure.Conf;
using CiccioGest.Presentation.AppForm.View;
using CiccioGest.Presentation.Mvp;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Linq;

namespace CiccioGest.Presentation.AppForm
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Program(args);
        }

        public Program(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostBuilderContext, loggingBuilder) =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(hostBuilderContext.Configuration);
                })
                .ConfigureServices(ConfigureServices)
                .Build();
            if (args.Contains("config"))
            {
                var asdfg = host.Services.GetService<SettingView>();
                System.Windows.Forms.Application.Run(asdfg);
            }
            else
            {
                host.Run();
            }
        }

        private void ConfigureServices(HostBuilderContext hostBuilderContext,
                                       IServiceCollection serviceCollection)
        {
            // Configuration
            //serviceCollection.Configure<AppConfig>(hostBuilderContext.Configuration.GetSection(nameof(AppConfig)));
            var conf = CiccioGestConfMgr.GetCurrent();
            serviceCollection.AddSingleton<CiccioGestConf>(conf);

            serviceCollection
                .ConfigureMvp()
                .AddHostedService<WinFormsHostedService>()
                .AddSingleton<IMainView, MainView>()
                .AddTransient<IListaFattureView, ListaFattureView>()
                .AddTransient<IFatturaView, FatturaView>()
                .AddTransient<IListaClientiView, ListaClientiView>()
                .AddTransient<ICategoriaView, CategoriaView>()
                .AddTransient<IArticoloView, ArticoloView>()
                .AddTransient<IListaFornitoriView, ListaFornitoriView>()
                .AddTransient<IListaArticoliView, ListaArticoliView>()
                .AddTransient<ISelectClienteView, SelectClienteView>()
                .AddTransient<SettingView>();
        }
    }
}
