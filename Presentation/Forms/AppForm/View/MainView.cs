﻿using CiccioGest.Presentation.Mvp.View;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class MainView : Form, IMainView
    {
        private readonly ILogger<MainView> logger;

        public event EventHandler LoadEvent;
        public event EventHandler ApriFatturaEvent;
        public event EventHandler NuovaFatturaEvent;
        public event EventHandler ApriClienteEvent;
        public event EventHandler NuovoClienteEvent;
        public event EventHandler ApriFornitoreEvent;
        public event EventHandler NuovoFornitoreEvent;
        public event EventHandler ApriArticoloEvent;
        public event EventHandler NuovoArticoloEvent;
        public event EventHandler CategorieEvent;
        public event EventHandler OpzioniEvent;
        public event EventHandler CloseEvent;

        public MainView(ILogger<MainView> logger)
        {
            InitializeComponent();
            this.logger = logger;
            this.logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        private void MainView_Load(object s, EventArgs e) =>
            LoadEvent?.Invoke(this, e);

        private void MainView_FormClosed(object s, FormClosedEventArgs e) =>
            CloseEvent?.Invoke(s, e);

        private void ApriFatturaToolStripMenuItem_Click(object sender, EventArgs e) =>
            ApriFatturaEvent?.Invoke(sender, e);

        private void NuovaFatturaToolStripMenuItem_Click(object sender, EventArgs e) =>
            NuovaFatturaEvent?.Invoke(sender, e);

        private void ApriClienteToolStripMenuItem_Click(object sender, EventArgs e) =>
            ApriClienteEvent?.Invoke(sender, e);

        private void NuovoClienteToolStripMenuItem_Click(object sender, EventArgs e) =>
            NuovoClienteEvent?.Invoke(sender, e);

        private void ApriFornitoreToolStripMenuItem_Click(object sender, EventArgs e) =>
            ApriFornitoreEvent?.Invoke(sender, e);

        private void NuovoFornitoreToolStripMenuItem_Click(object sender, EventArgs e) =>
            NuovoFornitoreEvent?.Invoke(sender, e);

        private void NuovoArticoloToolStripMenuItem_Click(object sender, EventArgs e) =>
            NuovoArticoloEvent?.Invoke(sender, e);

        private void ApriArticoloToolStripMenuItem_Click(object sender, EventArgs e) =>
            ApriArticoloEvent?.Invoke(sender, e);

        private void OpzioniToolStripMenuItem_Click(object sender, EventArgs e) =>
            OpzioniEvent?.Invoke(sender, e);

        private void EsciToolStripMenuItem_Click(object sender, EventArgs e) =>
            Close();

        private void InformazionisuToolStripMenuItem_Click(object sender, EventArgs e) =>
            new AboutBox().ShowDialog();

        private void CategorieToolStripMenuItem_Click(object sender, EventArgs e) =>
            CategorieEvent?.Invoke(this, e);

        public void ShowDialog(Object owner)
        {
            if (owner is IWin32Window window)
                Show(window);
        }
    }
}