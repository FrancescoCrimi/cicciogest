using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CiccioGest.Presentation.Forms.App1.Views
{
    public partial class ListaArticoliView : Form, ICazzo
    {
        private readonly ILogger logger;
        private readonly IMagazinoService magazinoService;

        public ListaArticoliView(ILogger logger, IMagazinoService magazinoService)
        {
            InitializeComponent();
            this.logger = logger;
            this.magazinoService = magazinoService;
            this.logger.Debug("HashCode: " + GetHashCode().ToString(CultureInfo.InvariantCulture) + " Created");
        }

        public int IdProdotto { get; private set; }

        private async void View_Load(object sender, EventArgs e)
        {
            articoliBindingSource.DataSource = await magazinoService.GetArticoli();
        }

        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
        {
            IdProdotto = ((ArticoloReadOnly)articoliBindingSource.Current).Id;
            Close();
        }
    }
}
