using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ListaFattureView : Form, IListaFattureView
    {
        private readonly ILogger logger;

        public event EventHandler EventLoad;
        public event EventHandler<int> EventSelectFattura;
        public event EventHandler EventNuova;
        public event EventHandler EventApri;
        public event EventHandler EventEsci;

        public ListaFattureView(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void ViewFatture(IList<FatturaReadOnly> listFatture)
        {
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }

        private void ListaFattureViewLoad(object s, EventArgs e)
        {
            EventLoad?.Invoke(this, e);
        }

        private void FattureDataGridViewCellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (fattureBindingSource.Current != null)
            {
                int IdFattura = ((FatturaReadOnly)fattureBindingSource.Current).Id;
                EventSelectFattura?.Invoke(this, IdFattura);
            }
        }

        private void NuovaClick(object sender, EventArgs e)
        {
            EventNuova?.Invoke(this, e);
        }

        private void ApriClick(object sender, EventArgs e)
        {
            EventApri?.Invoke(this, e);
        }

        private void EsciClick(object sender, EventArgs e)
        {
            EventEsci?.Invoke(this, e);
        }
    }
}
