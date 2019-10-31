using CiccioGest.Presentation.AppUwp2.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.AppUwp2.View
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            ((MainViewModel)DataContext).Initialize(ContentFrame);
        }
    }
}
