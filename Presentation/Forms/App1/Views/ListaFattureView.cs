using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ListaFattureView : Form, IListaFattureView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler<int> SelectFatturaEvent;
        public event EventHandler NuovaEvent;
        public event EventHandler ApriEvent;
        public event EventHandler CloseEvent;

        public ListaFattureView(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void SetFatture(IList<FatturaReadOnly> listFatture)
        {
            fattureBindingSource.DataSource = listFatture;
            fattureDataGridView.ClearSelection();
        }

        private void ListaFattureViewLoad(object s, EventArgs e)
        {
            LoadEvent?.Invoke(this, e);
        }

        private void FattureDataGridViewCellDoubleClick(object s, DataGridViewCellEventArgs e)
        {
            if (fattureBindingSource.Current != null)
            {
                int IdFattura = ((FatturaReadOnly)fattureBindingSource.Current).Id;
                SelectFatturaEvent?.Invoke(this, IdFattura);
            }
        }

        private void NuovaClick(object sender, EventArgs e)
        {
            NuovaEvent?.Invoke(this, e);
        }

        private void ApriClick(object sender, EventArgs e)
        {
            ApriEvent?.Invoke(this, e);
        }

        private void EsciClick(object sender, EventArgs e)
        {
            CloseEvent?.Invoke(this, e);
        }
    }
}
