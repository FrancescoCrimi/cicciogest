using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoloView : Window
    {
        public ArticoloView(ArticoloViewModel articoloViewModel)
        {
            InitializeComponent();
            DataContext = articoloViewModel;
        }
    }
}
