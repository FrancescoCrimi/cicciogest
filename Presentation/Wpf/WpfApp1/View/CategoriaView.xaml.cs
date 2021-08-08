using CiccioGest.Presentation.WpfApp.Contracts;
using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class CategoriaView : Window
    {
        public CategoriaView(CategoriaViewModel categoriaViewModel)
        {
            InitializeComponent();
            DataContext = categoriaViewModel;
        }
    }
}
