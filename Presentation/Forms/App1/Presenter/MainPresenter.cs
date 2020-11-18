using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;
using CiccioGest.Presentation.AppForm.Views;
using CiccioGest.Presentation.Forms.App1.Views;
using System;
using System.Globalization;

namespace CiccioGest.Presentation.AppForm.Presenter
{
    public class MainPresenter : IPresenter
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;

        public MainPresenter(ILogger logger,
                             IKernel kernel,
                             IMainView view)
        {
            this.logger = logger;
            this.kernel = kernel;
            View = view;

            view.EventLoad += Load;
            view.EventFatture += Fatture;
            view.EventClienti += Clienti;
            view.EventFornitori += Fornitori;
            view.EventArticoli += Articoli;
            view.EventCategorie += Categorie;
            view.EventInformazioni += Informazioni;
            view.EventOpzioni += Opzioni;

            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public IMainView View { get; }


        private void Load(object s, EventArgs e)
        {
        }

        private void Fatture(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                var sfv = kernel.Resolve<ListaFatturePresenter>();
                sfv.Show();
                //sfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
            }
        }

        private void Clienti(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                //var lcv = kernel.Resolve<ListaClientiView>();
                //lcv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                //lcv.Show();
                var lcp = kernel.Resolve<ListaClientiPresenter>();
                lcp.Show();
            }
        }

        private void Fornitori(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                var lfv = kernel.Resolve<ListaFornitoriView>();
                lfv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                lfv.Show();
            }
        }

        private void Articoli(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                ArticoloView pv = kernel.Resolve<ArticoloView>();
                pv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                pv.Show();
            }
        }

        private void Categorie(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                CategoriaPresenter cv = kernel.Resolve<CategoriaPresenter>();
                //cv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                cv.Show();
            }
        }

        private void Informazioni(object s, EventArgs e)
        {
            _ = new AboutBox().ShowDialog();
        }

        private void Opzioni(object s, EventArgs e)
        {
            using (kernel.BeginScope())
            {
                var sett = kernel.Resolve<SettingView>();
                sett.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                sett.Show();
            }
        }

        public void Show() { }
    }
}
