using CiccioGest.Presentation.Mvp.Presenter;
using CiccioGest.Presentation.Mvp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Hosting
{
    public class FormHostedService<TForm> : IHostedService, IDisposable where TForm : IPresenter
    {
        private readonly ILogger logger;
        private readonly WindowService windowService;
        private readonly IServiceProvider serviceProvider;

        public FormHostedService(ILogger<FormHostedService<TForm>> logger,
                                 WindowService windowService,
                                 IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.windowService = windowService;
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }
            var asdfg = serviceProvider.GetService<TForm>().View;
            System.Windows.Forms.Application.Run((Form)asdfg);
            logger.LogDebug("StartAsync: " + GetHashCode().ToString());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Stopping WinForms application.");
            //foreach (var form in System.Windows.Forms.Application.OpenForms.Cast<Form>().ToList())
            //{
            //    try
            //    {
            //        form.Close();
            //        form.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogWarning(ex, "Couldn't cleanup a Form");
            //    }
            //}
            //System.Windows.Forms.Application.ExitThread();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
