﻿using Castle.Core.Logging;
using CiccioGest.Domain.Magazino;
using CiccioGest.Presentation.Mvp.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class ListaArticoliView : Form, IListaArticoliView
    {
        private readonly ILogger logger;

        public event EventHandler LoadEvent;
        public event EventHandler CloseEvent;
        public event EventHandler<int> SelectArticoloEvent;

        public ListaArticoliView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public void SetArticoli(IList<ArticoloReadOnly> articoli)
        {
            articoliBindingSource.DataSource = articoli;
        }

        void IView.ShowDialog() => ShowDialog();

        private void ListaArticoliView_FormClosed(object s, FormClosedEventArgs e) =>
            CloseEvent?.Invoke(s, e);

        private void ListaArticoliView_Load(object sender, EventArgs e) =>
            LoadEvent?.Invoke(sender, e);

        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (articoliBindingSource.Current is ArticoloReadOnly art)
            {
                SelectArticoloEvent?.Invoke(sender, art.Id);
                Close();
            }
        }
    }
}