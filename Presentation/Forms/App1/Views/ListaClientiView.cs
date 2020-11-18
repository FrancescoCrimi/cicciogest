using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ListaClientiView : Form, IListaClientiView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler<Cliente> SelezionaClienteEvent;

        public ListaClientiView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void MostraClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
        }

        private void ListaClientiView_Load(object s, EventArgs e)
        {
            LoadEvent?.Invoke(s, e);
        }

        private void ClientiDataGridView_CellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (clientiBindingSource.Current != null)
            {
                Cliente cliente = (Cliente)clientiBindingSource.Current;
                SelezionaClienteEvent?.Invoke(s, cliente);
            }
        }

        private void AboutTSB_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
