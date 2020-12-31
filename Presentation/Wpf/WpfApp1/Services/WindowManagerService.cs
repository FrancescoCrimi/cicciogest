using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.View;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.Services
{
    public class WindowManagerService : IWindowManagerService
    {
        private readonly IKernel kernel;

        public WindowManagerService(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public Window MainWindow
            => System.Windows.Application.Current.MainWindow;

        public bool? OpenInDialog(WindowKey key)
        {
            using (kernel.BeginScope())
            {
                var window = GetNewWindow(key);
                window.Closed += OnWindowClosed;
                return window.ShowDialog();
            }
        }

        public void OpenInNewWindow(WindowKey key)
        {
            var window = GetWindow(key);
            if (window != null)
            {
                window.Activate();
            }
            else
            {
                using (kernel.BeginScope())
                {
                    window = GetNewWindow(key);
                    window.Closed += OnWindowClosed;
                    window.Show();
                }
            }
        }

        public Window GetWindow(WindowKey key)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window is IView view)
                {
                    if (view.WindowKey == key)
                    {
                        return window;
                    }
                }
            }
            return null;
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Closed -= OnWindowClosed;
            kernel.ReleaseComponent(window.DataContext);
        }

        private Window GetNewWindow(WindowKey key)
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
