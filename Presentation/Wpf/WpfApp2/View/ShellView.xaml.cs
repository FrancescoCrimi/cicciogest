using CiccioGest.Presentation.WpfApp2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class ShellView : Window
    {
        public ShellView(INavigationService navigationService)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
        }
    }
}
