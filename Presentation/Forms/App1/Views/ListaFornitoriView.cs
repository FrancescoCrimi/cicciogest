using Castle.Core.Logging;
using CiccioGest.Domain.ClientiFornitori;
using CiccioGest.Presentation.Mvp.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{

    public partial class ListaFornitoriView : Form, IListaFornitoriView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler<int> SelectFornitoreEvent;


        public ListaFornitoriView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
        }

        public void SetFornitori(IList<Fornitore> fornitori)
        {
            fornitoriBindingSource.DataSource = fornitori;
        }

        private void ListaFornitoriView_Load(object sender, EventArgs e)
        {
            LoadEvent?.Invoke(sender, e);
        }
    }
}
