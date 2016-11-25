using Ciccio1.Application;
using Ciccio1.Domain;
using Ciccio1.Presentation.WinForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Presentation.WinForm.Presenters
{
    public class SelectProdottoPresenter : IDisposable
    {
        private ICiccioService service;
        private SelectProdottoView view;

        public SelectProdottoPresenter(ICiccioService service, SelectProdottoView view)
        {
            this.service = service;
            this.view = view;
            view.Load += View_Load;
            view.ProdottiDataGridView.DoubleClick += ProdottiDataGridView_DoubleClick;
        }

        private void View_Load(object sender, EventArgs e)
        {
            view.prodottiBindingSource.DataSource = service.GetProdotti();
        }

        private void ProdottiDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ProdottoSelezionato = view.prodottiBindingSource.Current as Prodotto;
            view.Close();
        }

        public Prodotto ProdottoSelezionato { get; private set; }

        public void Show()
        {
            view.ShowDialog();
        }

        public void Dispose()
        {
            view.Dispose();
        }
    }
}
