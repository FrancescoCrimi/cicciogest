using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FattureView : Window
    {
        public FattureView(FattureViewModel listaFattureViewModel)
        {
            InitializeComponent();
            DataContext = listaFattureViewModel;
        }
    }
}
