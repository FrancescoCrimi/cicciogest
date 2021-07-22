using CiccioGest.Presentation.WpfApp2.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp2.View
{
    public partial class CategoriaView : Page
    {
        public CategoriaView(CategoriaViewModel categoriaViewModel)
        {
            InitializeComponent();
            DataContext = categoriaViewModel;
        }
    }
}
