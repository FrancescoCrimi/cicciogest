using Castle.Core.Logging;
using CiccioGest.Application;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Windows.Forms;

namespace CiccioGest.Presentation.AppForm.Views
{
    public partial class SelectArticoloView : Form, ICazzo
    {
        public int IdProdotto { get; private set; }
        private readonly IMagazinoService service;
        private readonly ILogger logger;

        public SelectArticoloView(ILogger logger, IMagazinoService service)
        {
            InitializeComponent();
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.service = service;
        }

        private void View_Load(object sender, EventArgs e)
        {
            articoliBindingSource.DataSource = service.GetArticoli();
        }

        private void ArticoliDataGridView_DoubleClick(object sender, EventArgs e)
        {
            IdProdotto = ((ArticoloReadOnly)articoliBindingSource.Current).Id;
            Close();
        }
    }
}
