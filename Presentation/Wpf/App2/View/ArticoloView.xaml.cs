using CiccioGest.Presentation.Wpf.App2.Contracts;
using System.Windows;

namespace CiccioGest.Presentation.Wpf.App2.View
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
