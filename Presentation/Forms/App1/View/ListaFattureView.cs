//using Castle.Core.Logging;
using CiccioGest.Domain.Documenti;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ListaFattureView : Form, IListaFattureView
    {
        private readonly ILogger<ListaFattureView> logger;

        public event EventHandler LoadEvent;
        public event EventHandler<int> SelectFatturaEvent;
        public event EventHandler NuovaEvent;
        public event EventHandler ApriEvent;
        public event EventHandler CloseEvent;

        public ListaFattureView(ILogger<ListaFattureView> logger)
        {
            this.logger = logger;
            InitializeComponent();
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
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

        private void NuovaClick(object s, EventArgs e)
        {
            NuovaEvent?.Invoke(s, e);
        }

        private void ApriClick(object s, EventArgs e)
        {
            ApriEvent?.Invoke(s, e);
        }

        private void EsciClick(object s, EventArgs e)
        {
            CloseEvent?.Invoke(s, e);
        }

        void IView.ShowDialog() => ShowDialog();

        private void ListaFattureView_FormClosed(object s, FormClosedEventArgs e)
        {
            CloseEvent?.Invoke(s, e);
        }
    }
}
