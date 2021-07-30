using CiccioGest.Presentation.Mvp.Presenter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CiccioGest.Presentation.Mvp.Services
{
    public class DialogService : IDisposable
    {
        private readonly ILogger<DialogService> logger;
        private readonly IServiceProvider serviceProvider;

        public DialogService(ILogger<DialogService> logger,
                             IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            logger.LogDebug("Created: " + GetHashCode().ToString());
        }

        public TPresenter OpenDialog<TPresenter>(Object owner) where TPresenter : IPresenter
        {
            TPresenter presenter = serviceProvider.GetService<TPresenter>();
            presenter.ShowDialog(owner);
            return presenter;
        }

        public void Dispose()
        {
            logger.LogDebug("Disposed: " + GetHashCode().ToString());
        }
    }
}
