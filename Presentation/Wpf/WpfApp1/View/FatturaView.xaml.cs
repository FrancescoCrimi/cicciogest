using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
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
