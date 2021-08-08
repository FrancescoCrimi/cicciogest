using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FatturaView : Page
    {
        public FatturaView(FatturaViewModel fatturaViewModel)
        {
            InitializeComponent();
            DataContext = fatturaViewModel;
        }
    }
}
