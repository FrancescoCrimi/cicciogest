//using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ArticoloView : Form, IArticoloView
    {
        private readonly ILogger<ArticoloView> logger;

        public event EventHandler AggiungiCategoriaEvent;
        public event EventHandler ApriArticoloEvent;
        public event EventHandler<int> EliminaArticoloEvent;
        public event EventHandler RimuoviCategoriaEvent;
        public event EventHandler<Articolo> SalvaArticoloEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<int> SelezionaArticoloEvent;

        public ArticoloView(ILogger<ArticoloView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void View_Load(object s, EventArgs e) => LoadEvent?.Invoke(s, e);

        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            articoloBindingSource.DataSource = new Articolo();
        }

        private void SalvaToolStripButton_Click(object s, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo p)
            {
                try
                {
                    SalvaArticoloEvent?.Invoke(s, p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CancellaToolStripButton_Click(object s, EventArgs e)
        {
            articoloBindingSource.EndEdit();
            if (articoloBindingSource.Current is Articolo p)
            {
                try
                {
                    EliminaArticoloEvent?.Invoke(s, p.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void ProdottiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (articoliBindingSource.Current is ArticoloReadOnly art)
                SelezionaArticoloEvent?.Invoke(sender, art.Id);
        }

        public void SetArticolo(Articolo articolo)
        {
            articoloBindingSource.DataSource = articolo;
        }

        public void SetArticoli(IList<ArticoloReadOnly> list)
        {
            articoliBindingSource.DataSource = list;
        }

        public void SetCategorie(IList<Categoria> list)
        {
            categorieBindingSource.DataSource = list;
        }

        void IView.ShowDialog() => ShowDialog();

        private void ArticoloView_FormClosed(object s, FormClosedEventArgs e)
        {
            CloseEvent?.Invoke(s, e);
        }
    }
}
