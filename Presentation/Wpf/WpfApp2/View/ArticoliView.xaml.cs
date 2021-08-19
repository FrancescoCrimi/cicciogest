using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoliView : Page
    {
        public ArticoliView(ArticoliViewModel articoliViewModel)
        {
            InitializeComponent();
            DataContext = articoliViewModel;
        }
    }
}
