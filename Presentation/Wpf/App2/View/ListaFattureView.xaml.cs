using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
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
