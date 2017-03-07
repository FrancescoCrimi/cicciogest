using Castle.Core.Logging;
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
        private IProdottoService service;

        public SelectProdottoView(ILogger logger, IProdottoService service)
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
            IdProdotto = ((Prodotto)prodottiBindingSource.Current).Id;
            Close();
        }

        public int IdProdotto { get; private set; }
    }
}
