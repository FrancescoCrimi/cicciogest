using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ListaClientiView : Window, IView
    {
        public ListaClientiView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.ListaClienti;
    }
}
