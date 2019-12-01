using CiccioGest.Presentation.Uwp.App1.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Uwp.App1.View
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
