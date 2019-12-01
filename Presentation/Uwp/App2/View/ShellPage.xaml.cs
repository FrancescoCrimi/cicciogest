using CiccioGest.Presentation.Uwp.App2.ViewModel;
using Windows.UI.Xaml.Controls;

namespace CiccioGest.Presentation.Uwp.App2.View
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();
            ((ShellViewModel)DataContext).Initialize(ContentFrame);
        }
    }
}
