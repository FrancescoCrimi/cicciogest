using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class MainView : Window
    {
        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}
