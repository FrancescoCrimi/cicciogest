using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class ArticoloView : Page
    {
        public ArticoloView(ArticoloViewModel articoloViewModel)
        {
            InitializeComponent();
            DataContext = articoloViewModel;
        }
    }
}
