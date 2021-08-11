using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class MainView : Window
    {
        private readonly MainViewModel mainViewModel;

        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
            this.mainViewModel = mainViewModel;
            mainViewModel.OnRequestClose += MainViewModel_OnRequestClose;
        }

        private void MainViewModel_OnRequestClose(object sender, System.EventArgs e)
        {
            mainViewModel.OnRequestClose -= MainViewModel_OnRequestClose;
            Close();
        }
    }
}
