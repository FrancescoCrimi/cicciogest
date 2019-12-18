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
        private IConf conf;
        //private IWindsorContainer windsor;

        public SettingView(ILogger logger, IConf conf, IUnitOfWorkFactory uowf)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.conf = conf ?? throw new ArgumentNullException(nameof(conf));
            this.uowf = uowf ?? throw new ArgumentNullException(nameof(uowf));
            InitializeComponent();
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            uIComboBox.DataSource = Enum.GetValues(typeof(UI));
            SetImpostazioni(conf);
        }

        public SettingView()
        { 
            InitializeComponent();
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            uIComboBox.DataSource = Enum.GetValues(typeof(UI));



            //windsor = Bootstrap.Windsor;
            

            //windsor.Install(new Installer());
        }

        private void SetImpostazioni(IConf impoConf)
        {
            uIComboBox.SelectedItem = impoConf.UserInterface;
            databaseComboBox.SelectedItem = impoConf.Database;
            dataAccessComboBox.SelectedItem = impoConf.DataAccess;
            connectionStringTextBox.Text = impoConf.CS;
        }

        private void GetImpostazioni()
        {
            DummyConf newConf = new DummyConf();
            newConf.UserInterface = (UI)uIComboBox.SelectedValue;
            newConf.Database = (Databases)databaseComboBox.SelectedValue;
            newConf.DataAccess = (Storage)dataAccessComboBox.SelectedValue;
            newConf.CS = connectionStringTextBox.Text;
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
                Bootstrap.Restart(conf);
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

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadConfButton_Click(object sender, EventArgs e)
        {
            try
            {
                Bootstrap.Start();
                //SetImpostazioni(Bootstrap.Windsor.Resolve<IConf>());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
