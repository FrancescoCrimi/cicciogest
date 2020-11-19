using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ListaClientiView : Form, IListaClientiView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler<int> SelectClienteEvent;
        public event EventHandler CloseEvent;

        public ListaClientiView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void SetClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
        }

        private void ListaClientiView_Load(object s, EventArgs e)
        {
            LoadEvent?.Invoke(s, e);
        }

        private void ClientiDataGridView_CellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (clientiBindingSource.Current is Cliente cliente)
            {
                SelectClienteEvent?.Invoke(s, cliente.Id);
            }
        }

        private void AboutTSB_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
