using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ListaFattureView : Window, IView
    {
        public ListaFattureView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.ListaFatture;
    }
}
