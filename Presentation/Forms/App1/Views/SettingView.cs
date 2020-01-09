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
        private IUnitOfWorkFactory uowf;
        private IAppConf conf;
        //private IWindsorContainer windsor;
        private ConfigurationManager confmgr;

        public SettingView(ILogger logger, IUnitOfWorkFactory uowf)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.uowf = uowf ?? throw new ArgumentNullException(nameof(uowf));
            InitializeComponent();
            dataAccessComboBox1.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox1.DataSource = Enum.GetValues(typeof(Databases));
            CaricaConf();
            //SetImpostazioni(conf);
        }

        private void CaricaConf()
        {
            confmgr = new ConfigurationManager();
            //confmgr.SampleConf();
            //confmgr.WriteConfiguration();
            confmgr.ReadConfiguration();
            conf = confmgr.GetCurrent();
            appConfBindingSource.DataSource = confmgr.GetCurrent();
            appConfsBindingSource.DataSource = confmgr.GetAllConfs();            
        }


        //private void SetImpostazioni(IAppConf impoConf)
        //{
        //    databaseComboBox1.SelectedItem = impoConf.Database;
        //    dataAccessComboBox1.SelectedItem = impoConf.DataAccess;
        //    cSTextBox.Text = impoConf.CS;
        //}

        private void GetImpostazioni()
        {
            AppConf newConf = new AppConf();
            newConf.Database = (Databases)databaseComboBox1.SelectedValue;
            newConf.DataAccess = (Storage)dataAccessComboBox1.SelectedValue;
            newConf.CS = cSTextBox.Text;
            conf = newConf;
        }

        private void LoadSampleButton_Click(object sender, EventArgs e)
        {

        }

        private void VerifyDbButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetImpostazioni();
                //Bootstrap.Restart(conf);
                //Bootstrap.Windsor.Install(new CiccioGest.Application.Installer());
                //uowf = Bootstrap.Windsor.Resolve<IUnitOfWorkFactory>();
                uowf.VerifyDataAccess();
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
                uowf.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteConfButton_Click(object sender, EventArgs e)
        {
            try
            {
                confmgr.WriteConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadConfButton_Click(object sender, EventArgs e)
        {
            try
            {
                CaricaConf();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rimuoviButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                confmgr.Remove(cnf);
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = confmgr.GetAllConfs();
            }
        }

        private void nuovaButton_Click(object sender, EventArgs e)
        {
            appConfBindingSource.DataSource = null;
            appConfBindingSource.DataSource = new AppConf();
        }

        private void aggiungiButton_Click(object sender, EventArgs e)
        {
            if(appConfBindingSource.DataSource != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                confmgr.Add(cnf);
                appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = new AppConf();
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = confmgr.GetAllConfs();
            }
        }

        private void modificaButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                AppConf cnf = (AppConf)appConfsBindingSource.Current;
                //appConfBindingSource.DataSource = null;
                appConfBindingSource.DataSource = cnf;
            }
        }

        private void setDefaultButton_Click(object sender, EventArgs e)
        {
            if(appConfBindingSource != null)
            {
                AppConf asdf = (AppConf)appConfBindingSource.Current;
                if (confmgr.GetAllConfs().Contains(asdf))
                {
                    confmgr.SetCurrent(asdf);
                }
                else
                    MessageBox.Show("Prima aggiungi la conf");
            }
        }
    }
}
