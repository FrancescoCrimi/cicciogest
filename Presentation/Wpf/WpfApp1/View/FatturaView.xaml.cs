using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class FatturaView : Window
    {
        public FatturaView(FatturaViewModel fatturaViewModel )
        {
            InitializeComponent();
            DataContext = fatturaViewModel;
        }
    }
}
