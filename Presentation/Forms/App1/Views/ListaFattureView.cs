using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class ListaFattureView : Form, ICazzo
    {
        public int IdFattura { get; private set; }
        private readonly ILogger logger;
        private readonly IFatturaService service;
        private BackgroundWorker backgroundWorker1;

        public ListaFattureView(ILogger logger, IFatturaService service)
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fattureBindingSource.DataSource = e.Result;
            fattureDataGridView.ClearSelection();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var lst = service.GetFatture().Result;
            //Thread.Sleep(2000);
            e.Result = lst;
        }

        private void Fatture_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private Task Suca()
        {
            return Task.Run( () =>
            {
                fattureBindingSource.DataSource =  service.GetFatture().Result;
                fattureDataGridView.ClearSelection();
            });
        }

        private void fattureDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fattureBindingSource.Current != null)
            {
                IdFattura = ((FatturaReadOnly)fattureBindingSource.Current).Id;
                Close();
            }
        }
    }
}
