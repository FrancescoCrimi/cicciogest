using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class FornitoreView : Page
    {
        public FornitoreView(FornitoreViewModel fornitoreViewModel)
        {
            InitializeComponent();
            DataContext = fornitoreViewModel;
        }
    }
}
