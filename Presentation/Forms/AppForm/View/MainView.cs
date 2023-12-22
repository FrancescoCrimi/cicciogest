// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class MainView : Form, IMainView
    {
        private readonly ILogger logger;
        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler? FattureEvent;
        public event EventHandler? ClientiEvent;
        public event EventHandler? FornitoriEvent;
        public event EventHandler? ArticoliEvent;
        public event EventHandler? CategorieEvent;
        public event EventHandler? OpzioniEvent;

        public MainView(ILogger<MainView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            LoadEvent?.Invoke(sender, e);
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent?.Invoke(sender, e);
        }

        private void FattureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FattureEvent?.Invoke(sender, e);
        }

        private void ClientiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientiEvent?.Invoke(sender, e);
        }

        private void FornitoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FornitoriEvent?.Invoke(sender, e);
        }

        private void ArticoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArticoliEvent?.Invoke(sender, e);
        }

        private void CategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategorieEvent?.Invoke(sender, e);
        }

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpzioniEvent?.Invoke(sender, e);
        }

        private void InformazionisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
