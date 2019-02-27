﻿using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class SelectFattureView : Form, ICazzo
    {
        public int IdFattura { get; private set; }
        private ILogger logger;
        private IFatturaService service;

        public SelectFattureView(ILogger logger, IFatturaService service)
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
        }

        private void Fatture_Load(object sender, EventArgs e)
        {
            IEnumerable<FatturaReadOnly> fatt = service.GetFatture();
            fattureBindingSource.DataSource = fatt;
            fattureDataGridView.ClearSelection();
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