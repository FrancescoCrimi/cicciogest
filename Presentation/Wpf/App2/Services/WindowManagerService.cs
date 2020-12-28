using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Presentation.Wpf.App2.View;
using System;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.Services
{
    public class WindowManagerService : IWindowManagerService
    {
        private readonly IKernel kernel;

        public WindowManagerService(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public bool? OpenInDialog(WindowKey key)
        {
            using (kernel.BeginScope())
            {
                var window = GetWindow(key);
                window.Closed += OnWindowClosed;
                return window.ShowDialog();
            }
        }

        public void OpenInNewWindow(WindowKey key)
        {
            using (kernel.BeginScope())
            {
                var window = GetWindow(key);
                window.Closed += OnWindowClosed;
                window.Show();
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Closed -= OnWindowClosed;
            kernel.ReleaseComponent(window.DataContext);
        }

        private Window GetWindow(WindowKey key)
        {
            switch (key)
            {
                case WindowKey.Main:
                    return new MainView();
                case WindowKey.Fattura:
                    return new FatturaView();
                case WindowKey.Articolo:
                    return new ArticoloView();
                case WindowKey.Categoria:
                    return new CategoriaView();
                case WindowKey.ListaArticoli:
                    return new ListaArticoliView();
                case WindowKey.ListaFatture:
                    return new ListaFattureView();
                case WindowKey.ListaClienti:
                    return new ListaClientiView();
                default:
                    return null;
            }
        }
    }
}
