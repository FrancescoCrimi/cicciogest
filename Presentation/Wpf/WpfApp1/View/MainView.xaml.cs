using CiccioGest.Presentation.WpfApp1.Contracts;
using CiccioGest.Presentation.WpfApp1.ViewModel;
using System.ComponentModel;
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

        private void Main_Closing(object sender, CancelEventArgs e)
        {
            //Messenger.Default.Unregister(this);
        }
    }
}
