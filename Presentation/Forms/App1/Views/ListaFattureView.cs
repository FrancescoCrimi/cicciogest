using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class ListaFattureView : Form
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IFatturaService fatturaService;

        public ListaFattureView(ILogger logger, IKernel kernel, IFatturaService fatturaService)
        {
            this.logger = logger;
            this.kernel = kernel;
            this.fatturaService = fatturaService;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private async void Fatture_Load(object sender, EventArgs e)
        {
            var listFatture = await fatturaService.GetFatture();
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }

        private void FattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fattureBindingSource.Current != null)
            {
                var IdFattura = ((FatturaReadOnly)fattureBindingSource.Current).Id;
                var fv = kernel.Resolve<FatturaView>(new Arguments().AddNamed("idFattura", IdFattura));
                fv.FormClosing += (s, a) => kernel.ReleaseComponent(s);
                fv.Show();
                Close();
            }
        }
    }
}
