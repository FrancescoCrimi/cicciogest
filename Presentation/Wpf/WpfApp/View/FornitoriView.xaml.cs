using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FornitoriView : Page
    {
        public FornitoriView(FornitoriViewModel fornitoriViewModel)
        {
            InitializeComponent();
            DataContext = fornitoriViewModel;
        }
    }
}
