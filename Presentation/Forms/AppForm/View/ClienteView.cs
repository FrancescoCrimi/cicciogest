using CiccioGest.Domain.ClientiFornitori;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ClienteView : Form, IClienteView
    {
        public ClienteView()
        {
            InitializeComponent();
        }

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler NuovoCliente;
        public event EventHandler SalvaCliente;
        public event EventHandler ApriCliente;

        public void MostraCliente(Cliente cliente)
            => clienteBindingSource.DataSource = cliente;

        #region GestioneEventi

        private void ClienteView_Load(object sender, EventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void ClienteView_FormClosing(object sender, FormClosingEventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
            => NuovoCliente?.Invoke(sender, e);

        private void ApriToolStripButton_Click(object sender, EventArgs e)
            => SalvaCliente?.Invoke(sender, e);

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
            => ApriCliente?.Invoke(sender, e);

        private void ToolStripButton_Click(object sender, EventArgs e)
            => new AboutBox().ShowDialog();

        #endregion
    }
}
