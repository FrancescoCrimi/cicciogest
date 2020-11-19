using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ListaArticoliView : Form, IListaArticoliView
    {
        private readonly ILogger logger;

        public event EventHandler<int> SelezionaArticoloEvent;
        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;

        public ListaArticoliView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadEvent?.Invoke(sender, e);
        }

        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if(articoliBindingSource.Current is ArticoloReadOnly art)
            {
                SelezionaArticoloEvent?.Invoke(sender, art.Id);
                Close();
            }
        }

        public void SetArticoli(IList<ArticoloReadOnly> articoli)
        {
            articoliBindingSource.DataSource = articoli;
        }
    }
}
