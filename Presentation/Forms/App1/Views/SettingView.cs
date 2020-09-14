using Castle.Core.Logging;
using Castle.MicroKernel;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class SettingView : Form
    {
        private readonly ILogger logger;
        private readonly IKernel kernel;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private ConfigurationManager confmgr;

        public SettingView(ILogger logger,
                           IKernel kernel,
                           IUnitOfWorkFactory unitOfWorkFactory)
        {
            InitializeComponent();
            this.logger = logger;
            this.kernel = kernel;
            this.unitOfWorkFactory = unitOfWorkFactory;
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            confmgr = new ConfigurationManager();
            CaricaConf();
        }

        private void verificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                unitOfWorkFactory.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                unitOfWorkFactory.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void popolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sett = kernel.Resolve<ISettingService>();
            await sett.LoadSampleData();
            MessageBox.Show("Eseguito con successo");
        }



        private void CaricaConf()
        {
            var asdf = confmgr.GetAll();
            appConfsBindingSource.DataSource = asdf;
            var assa = confmgr.GetCurrent();
            appConfBindingSource.DataSource = assa;
        }

        private void AppConfDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                //appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = cnf;
            }
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            appConfBindingSource.DataSource = null;
            appConfBindingSource.DataSource = new AppConf();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            confmgr.Save();
            CaricaConf();
        }

        private void aggiungiToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfBindingSource.DataSource != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                confmgr.Add(cnf);
                appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = new AppConf();
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = confmgr.GetAll();
            }
        }

        private void rimuoviToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                confmgr.Remove(cnf);
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = confmgr.GetAll();
            }
        }

        private void defaultToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource != null)
            {
                AppConf asdf = (AppConf)appConfsBindingSource.Current;
                if (confmgr.GetAll().Contains(asdf))
                {
                    confmgr.SetCurrent(asdf);
                }
                else
                    MessageBox.Show("Prima aggiungi la conf");
            }
        }

        private void caricaDefaultToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                confmgr.LoadSample();
                CaricaConf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
