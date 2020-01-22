using Castle.Core.Logging;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class SettingView : Form
    {
        private readonly ILogger logger;
        private ConfigurationManager confmgr;

        public SettingView(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            confmgr = new ConfigurationManager();
            CaricaConf();
        }

        private void CaricaConf()
        {
            var asdf = confmgr.GetAll();
            appConfsBindingSource.DataSource = asdf;
            var assa = confmgr.GetCurrent();
            appConfBindingSource.DataSource = assa;
        }

        private void LoadSampleButton_Click(object sender, EventArgs e)
        {
            confmgr.LoadSample();
            CaricaConf();
        }

        private void VerifyDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Bootstrap.Restart(conf);
                //Bootstrap.Windsor.Install(new CiccioGest.Application.Installer());
                //uowf = Bootstrap.Windsor.Resolve<IUnitOfWorkFactory>();
                //uowf.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                //uowf.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RimuoviButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                confmgr.Remove(cnf);
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = confmgr.GetAll();
            }
        }


        private void AggiungiButton_Click(object sender, EventArgs e)
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

        private void SetDefaultButton_Click(object sender, EventArgs e)
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

        private void AppConfDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                //appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = cnf;
            }
        }

        private void NuovoButton_Click(object sender, EventArgs e)
        {
            appConfBindingSource.DataSource = null;
            appConfBindingSource.DataSource = new AppConf();
        }

        private void SalvaButton_Click(object sender, EventArgs e)
        {
            confmgr.Save();
            CaricaConf();
        }
    }
}
