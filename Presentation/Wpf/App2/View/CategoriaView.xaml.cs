using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
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
