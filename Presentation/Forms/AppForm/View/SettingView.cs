// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SettingView : Form, ISettingView
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public event EventHandler? LoadEvent;
        public event EventHandler? CloseEvent;
        public event EventHandler? VerificaDatabaseEvent;
        public event EventHandler? CreaDatabaseEvent;
        public event EventHandler? PopolaDatabaseEvent;

        public SettingView(ILogger<SettingView> logger,
                           IServiceProvider serviceProvider,
                           IServiceScopeFactory serviceScopeFactory)
        {
            InitializeComponent();
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.serviceScopeFactory = serviceScopeFactory;

            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));

            CaricaConf();
        }

        private void SettingView_FormClosing(object sender, FormClosingEventArgs e)
            => LoadEvent?.Invoke(sender, e);

        private void SettingView_Load(object sender, EventArgs e)
            => CloseEvent?.Invoke(sender, e);

        private void VerificaDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
            => VerificaDatabaseEvent?.Invoke(sender, e);

        private void CreaDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
            => CreaDatabaseEvent?.Invoke(sender, e);

        private void PopolaDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
            => PopolaDatabaseEvent?.Invoke(sender, e);













        private void CaricaConf()
        {
            var asdf = CiccioGestConfMgr.GetAll();
            appConfsBindingSource.DataSource = asdf;
            var assa = CiccioGestConfMgr.GetCurrent();
            appConfBindingSource.DataSource = assa;
        }




        private void AppConfDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                CiccioGestConf cnf = (CiccioGestConf)appConfsBindingSource.Current;
                appConfBindingSource.DataSource = cnf;
            }
        }



        private void NuovoToolStripButton_Click(object sender, EventArgs e)
        {
            appConfBindingSource.DataSource = null;
            appConfBindingSource.DataSource = new CiccioGestConf();
        }

        private void SalvaToolStripButton_Click(object sender, EventArgs e)
        {
            CiccioGestConfMgr.Save();
            CaricaConf();
        }

        private void AggiungiToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfBindingSource.DataSource != null)
            {
                CiccioGestConf cnf = (CiccioGestConf)appConfsBindingSource.Current;
                CiccioGestConfMgr.Add(cnf);
                appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = new CiccioGestConf();
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = CiccioGestConfMgr.GetAll();
            }
        }

        private void RimuoviToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                CiccioGestConf cnf = (CiccioGestConf)appConfsBindingSource.Current;
                CiccioGestConfMgr.Remove(cnf);
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = CiccioGestConfMgr.GetAll();
            }
        }

        private void DefaultToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource != null)
            {
                CiccioGestConf asdf = (CiccioGestConf)appConfsBindingSource.Current;
                if (CiccioGestConfMgr.GetAll().Contains(asdf))
                {
                    CiccioGestConfMgr.SetCurrent(asdf);
                }
                else
                    MessageBox.Show("Prima aggiungi la conf");
            }
        }

        private void CaricaDefaultToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                CiccioGestConfMgr.LoadSample();
                CaricaConf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
