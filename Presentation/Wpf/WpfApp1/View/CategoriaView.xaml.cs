using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class CategoriaView : Window, IView
    {
        public CategoriaView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.Categoria;
    }
}
