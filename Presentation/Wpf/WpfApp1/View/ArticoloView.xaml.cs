using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
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
