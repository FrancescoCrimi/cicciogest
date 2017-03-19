using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CiccioGest.Presentation.Wpf.View
{
    /// <summary>
    /// Logica di interazione per HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void mostraFattureMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.Messenger.NotifyColleagues("ApriFatture");
        }

        private void nuovaFatturaMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void prodottiMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void categorieMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
