using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SelectClienteView : Form, ISelectClienteView
    {
        private readonly ILogger<SelectClienteView> logger;

        public SelectClienteView(ILogger<SelectClienteView> logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public event EventHandler<int> SelectClienteEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;

        public void SetClienti(IList<Cliente> clienti)
        {
            clientiBindingSource.DataSource = clienti;
        }

        private void ClientiDialog_Load(object s, EventArgs e) => LoadEvent?.Invoke(s, e);

        private void DataGridView1_CellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (clientiBindingSource.Current is Cliente cliente)
            {
                SelectClienteEvent?.Invoke(s, cliente.Id);
                Close();
            }
        }

        void IView.ShowDialog() => ShowDialog();

        private void SelectClienteView_FormClosed(object s, FormClosedEventArgs e)
        {
            CloseEvent?.Invoke(s, e);
        }
    }
}
