using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.AppForm
{
    public class WinFormsHostedService : IHostedService
    {
        private readonly ILogger<WinFormsHostedService> logger;
        private readonly IServiceProvider serviceProvider;

        public WinFormsHostedService(ILogger<WinFormsHostedService> logger,
                                     IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.ApplicationExit += OnApplicationExit;

            //Form shell = (Form)serviceProvider.GetService<IMainView>();
            //System.Windows.Forms.Application.Run(shell);

            var asdfg = serviceProvider.GetService<MainPresenter>();
            System.Windows.Forms.Application.Run((Form)asdfg.View);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Stopping WinForms application.");
            foreach (var form in System.Windows.Forms.Application.OpenForms.Cast<Form>().ToList())
            {
                try
                {
                    form.Close();
                    form.Dispose();
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Couldn't cleanup a Form");
                }
            }
            System.Windows.Forms.Application.ExitThread();
            return Task.CompletedTask;
        }

        private void OnApplicationExit(object sender, EventArgs eventArgs)
        {
            System.Windows.Forms.Application.ApplicationExit -= OnApplicationExit;
            serviceProvider.GetService<IHostApplicationLifetime>().StopApplication();
        }
    }
}
