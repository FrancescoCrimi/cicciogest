// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class MainView : Form, IMainView
    {
        private readonly ILogger _logger;
        public event EventHandler? NuovaFatturaRequested;
        public event EventHandler? ApriFatturaRequested;
        public event EventHandler? ClientiRequested;
        public event EventHandler? FornitoriRequested;
        public event EventHandler? ArticoliRequested;
        public event EventHandler? CategorieRequested;
        public event EventHandler? OpzioniRequested;

        public MainView(ILogger<MainView> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogDebug("HashCode: " + GetHashCode().ToString() + " Created");
        }

        #region Event Handlers

        private void NuovaFattura_Click(object sender, EventArgs e)
        {
            NuovaFatturaRequested?.Invoke(sender, e);
        }

        private void ApriFattura_Click(object sender, EventArgs e)
        {
            ApriFatturaRequested?.Invoke(sender, e);
        }

        private void Clienti_Click(object sender, EventArgs e)
        {
            ClientiRequested?.Invoke(sender, e);
        }

        private void Fornitori_Click(object sender, EventArgs e)
        {
            FornitoriRequested?.Invoke(sender, e);
        }

        private void Articoli_Click(object sender, EventArgs e)
        {
            ArticoliRequested?.Invoke(sender, e);
        }

        private void Categorie_Click(object sender, EventArgs e)
        {
            CategorieRequested?.Invoke(sender, e);
        }

        private void Opzioni_Click(object sender, EventArgs e)
        {
            OpzioniRequested?.Invoke(sender, e);
        }

        private void Informazionisu_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        #endregion
    }
}
