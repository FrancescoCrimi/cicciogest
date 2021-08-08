using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoliView : Window
    {
        public ArticoliView(ArticoliViewModel listaArticoliViewModel)
        {
            InitializeComponent();
            DataContext = listaArticoliViewModel;
        }
    }
}
