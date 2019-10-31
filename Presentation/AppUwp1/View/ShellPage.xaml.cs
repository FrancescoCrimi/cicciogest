using CiccioGest.Presentation.AppUwp1.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.AppUwp1.View
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            ((ShellViewModel)DataContext).Initialization(shellFrame);
        }
    }
}
