using Ciccio1.Application;
using Ciccio1.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciccio1.Presentation.WinForm.Views
{
    public partial class SelectProdottoView : Form
    {
        private ICiccioService service;

        public SelectProdottoView(ICiccioService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void View_Load(object sender, EventArgs e)
        {
            prodottiBindingSource.DataSource = service.GetProdotti();
        }

        private void ProdottiDataGridView_DoubleClick(object sender, EventArgs e)
        {
            ProdottoSelezionato = prodottiBindingSource.Current as Prodotto;
            Close();
        }

        public Prodotto ProdottoSelezionato { get; private set; }
    }
}
