using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
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
    public partial class ListaClientiView : Form
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IClientiFornitoriService clientiFornitoriService;

        public ListaClientiView(ILogger logger,
                                IKernel kernel,
                                IClientiFornitoriService clientiFornitoriService)
        {
            InitializeComponent();
            this.logger = logger;
            this.kernel = kernel;
            this.clientiFornitoriService = clientiFornitoriService;
        }

        private async void ListaClienti_Load(object sender, EventArgs e)
        {
            clientiBindingSource.DataSource = await clientiFornitoriService.GetClienti();
        }
    }
}
