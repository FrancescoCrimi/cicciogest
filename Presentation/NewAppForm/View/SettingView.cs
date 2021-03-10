using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Infrastructure.Conf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.View
{
    public partial class SettingView : Form
    {
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IServiceScopeFactory serviceScopeFactory;

        //private readonly IKernel kernel;
        //private readonly IUnitOfWorkFactory unitOfWorkFactory;
        //private CiccioGestConfMgr confmgr;

        public SettingView(ILogger<SettingView> logger,
            IServiceProvider serviceProvider,
            IServiceScopeFactory serviceScopeFactory
                           //IKernel kernel
                           //IUnitOfWorkFactory unitOfWorkFactory
            )
        {
            InitializeComponent();
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.serviceScopeFactory = serviceScopeFactory;
            //this.kernel = kernel;
            //this.unitOfWorkFactory = unitOfWorkFactory;
            dataAccessComboBox.DataSource = Enum.GetValues(typeof(Storage));
            databaseComboBox.DataSource = Enum.GetValues(typeof(Databases));
            //confmgr = new CiccioGestConfMgr();
            CaricaConf();
        }

        private void verificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var uowf = serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf.VerifyDataAccess();
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
                var uowf = serviceProvider.GetService<IUnitOfWorkFactory>();
                uowf.CreateDataAccess();
                MessageBox.Show("Eseguito con successo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void popolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var sett = scope.ServiceProvider.GetService<ISettingService>();
                await sett.LoadSampleData();
                MessageBox.Show("Eseguito con successo");
            }
        }



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

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            appConfBindingSource.DataSource = null;
            appConfBindingSource.DataSource = new CiccioGestConf();
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            CiccioGestConfMgr.Save();
            CaricaConf();
        }

        private void aggiungiToolStripButton_Click(object sender, EventArgs e)
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

        private void rimuoviToolStripButton_Click(object sender, EventArgs e)
        {
            if (appConfsBindingSource.Current != null)
            {
                CiccioGestConf cnf = (CiccioGestConf)appConfsBindingSource.Current;
                CiccioGestConfMgr.Remove(cnf);
                appConfsBindingSource.DataSource = null;
                appConfsBindingSource.DataSource = CiccioGestConfMgr.GetAll();
            }
        }

        private void defaultToolStripButton_Click(object sender, EventArgs e)
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

        private void caricaDefaultToolStripButton1_Click(object sender, EventArgs e)
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
