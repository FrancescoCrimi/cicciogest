﻿using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Documenti;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class ListaFattureView : Form, ICazzo
    {
        public int IdFattura { get; private set; }
        private ILogger logger;
        private IFatturaService service;

        public ListaFattureView(ILogger logger, IFatturaService service)
        {
            InitializeComponent();
            this.logger = logger;
            this.service = service;
        }

        private async void Fatture_Load(object sender, EventArgs e)
        {
            fattureBindingSource.DataSource = await service.GetFatture();
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