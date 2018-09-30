using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class SelectProdottoView : Form
    {
        private IMagazinoService service;

        public SelectProdottoView(ILogger logger, IMagazinoService service)
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
            IdProdotto = ((ProdottoReadOnly)prodottiBindingSource.Current).Id;
            Close();
        }

        public int IdProdotto { get; private set; }
    }
}
