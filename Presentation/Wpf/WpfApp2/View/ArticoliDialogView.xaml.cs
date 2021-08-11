using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoliDialogView : Page
    {
        public ArticoliDialogView(ArticoliDialogViewModel articoliDialogViewModel)
        {
            InitializeComponent();
            DataContext = articoliDialogViewModel;
        }
    }
}
