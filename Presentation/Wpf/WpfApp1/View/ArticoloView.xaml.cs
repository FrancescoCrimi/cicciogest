using CiccioGest.Presentation.WpfApp1.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp1.View
{
    public partial class ArticoloView : Window, IView
    {
        public ArticoloView()
        {
            InitializeComponent();
        }

        public WindowKey WindowKey => WindowKey.Articolo;
    }
}
