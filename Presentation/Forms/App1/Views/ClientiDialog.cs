using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Domain.ClientiFornitori;
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
    public partial class ClientiDialog : Form
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IClientiFornitoriService clientiFornitoriService;

        public ClientiDialog(ILogger logger,
                             IKernel kernel,
                             IClientiFornitoriService clientiFornitoriService)
        {
            InitializeComponent();
            this.logger = logger;
            this.kernel = kernel;
            this.clientiFornitoriService = clientiFornitoriService;
        }

        public Cliente Cliente { get; private set; }

        private async void ClientiDialog_Load(object sender, EventArgs e)
        {
            clientiBindingSource.DataSource = await clientiFornitoriService.GetClienti();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clientiBindingSource.Current != null)
            {
                Cliente = (Cliente)clientiBindingSource.Current;
            }
            Close();
        }
    }
}
