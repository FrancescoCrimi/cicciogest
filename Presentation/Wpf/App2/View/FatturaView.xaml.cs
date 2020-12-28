using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
{
    public partial class FatturaView : Window, IView
    {
        public FatturaView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.Fattura;
    }
}
