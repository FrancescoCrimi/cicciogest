using CiccioGest.Presentation.WpfBackend.ViewModel;
using CiccioGest.Presentation.WpfMetroApp.Services;
using MahApps.Metro.Controls;

namespace CiccioGest.Presentation.WpfMetroApp.View
{
    public partial class MainView : MetroWindow
    {
        public MainView(MainViewModel viewModel, NavigationService navigationService)
        {
            InitializeComponent();
            DataContext = viewModel;
            navigationService.Initialize(shellFrame);
        }
    }
}
