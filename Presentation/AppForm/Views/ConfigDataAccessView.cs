using Castle.Core.Logging;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class ConfigDataAccessView : Form
    {
        private IUnitOfWorkFactory container;
        private IWindsorContainer windsor;
        //private ILogger logger;
        //private IConf conf = null;

        public ConfigDataAccessView()
        {
            InitializeComponent();
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            uIComboBox.DataSource = Enum.GetValues(typeof(UI));

            windsor = Bootstrap.Windsor;
            container = windsor.Resolve<IUnitOfWorkFactory>();
            setImpostazioni(windsor.Resolve<IConf>());
            //windsor.Install(new Installer());
        }

        private void setImpostazioni(IConf impoConf)
        {
            uIComboBox.SelectedItem = impoConf.UserInterface;
            databaseComboBox.SelectedItem = impoConf.Database;
            dataAccessComboBox.SelectedItem = impoConf.DataAccess;
            connectionStringTextBox.Text = impoConf.CS;
        }

        private IConf getImpostazioni()
        {
            DummyConf newConf = new DummyConf();
            newConf.UserInterface = (UI)uIComboBox.SelectedValue;
            newConf.Database = (Databases)databaseComboBox.SelectedValue;
            newConf.DataAccess = (Storage)dataAccessComboBox.SelectedValue;
            newConf.CS = connectionStringTextBox.Text;
            return newConf;
        }

        private void getGestConf()
        {
            //IConf gestConf = getImpostazioni();
            //container = new Bootstrap(gestConf);
            //windsor = container.Windsor;
            //windsor.Install(new Installer());
        }

        private void verificaButton_Click(object sender, EventArgs e)
        {
            try
            {
                getGestConf();
                container.VerifyDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void creaButton_Click(object sender, EventArgs e)
        {
            try
            {
                getGestConf();
                container.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
        }
    }
}
