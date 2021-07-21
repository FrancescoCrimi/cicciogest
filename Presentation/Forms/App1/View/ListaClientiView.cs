//using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ListaClientiView : Form, IListaClientiView
    {
        private readonly ILogger<ListaClientiView> logger;

        public event EventHandler LoadEvent;
        public event EventHandler<int> SelectClienteEvent;
        public event EventHandler CloseEvent;

        public ListaClientiView(ILogger<ListaClientiView> logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void SetClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
        }

        void IView.ShowDialog() => ShowDialog();

        private void AboutTSB_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void ListaClientiView_FormClosed(object s, FormClosedEventArgs e) =>
            CloseEvent?.Invoke(s, e);

        private void ListaClientiView_Load(object s, EventArgs e) =>
            LoadEvent?.Invoke(s, e);

        private void ClientiDataGridView_CellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (clientiBindingSource.Current is Cliente cliente)
            {
                SelectClienteEvent?.Invoke(s, cliente.Id);
            }
        }
    }
}
