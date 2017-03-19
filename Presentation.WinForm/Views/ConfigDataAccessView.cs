using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CiccioGest.Infrastructure;
using Castle.Core.Logging;
using CiccioGest.Infrastructure.Conf;

namespace CiccioGest.Presentation.WinForm.Views
{
    public partial class ConfigDataAccessView : Form
    {
        private Container container;
        //private ILogger logger;
        //private IConf conf = null;

        public ConfigDataAccessView()
        {
            InitializeComponent();
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            uIComboBox.DataSource = Enum.GetValues(typeof(UI));

            container = new Container(UI.Form);
            setImpostazioni(container.Resolve<IConf>());
            container.Install(new Installer());
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
            IConf gestConf = getImpostazioni();
            container = new Container(gestConf);
            container.Install(new Installer());
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
