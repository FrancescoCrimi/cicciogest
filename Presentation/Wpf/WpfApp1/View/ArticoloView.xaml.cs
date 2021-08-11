using CiccioGest.Presentation.WpfApp.ViewModel;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ArticoloView : Window
    {
        private readonly ArticoloViewModel articoloViewModel;

        public ArticoloView(ArticoloViewModel articoloViewModel)
        {
            InitializeComponent();
            DataContext = articoloViewModel;
            this.articoloViewModel = articoloViewModel;
            articoloViewModel.OnRequestClose += ArticoloViewModel_OnRequestClose;
        }

        private void ArticoloViewModel_OnRequestClose(object sender, System.EventArgs e)
        {
            articoloViewModel.OnRequestClose -= ArticoloViewModel_OnRequestClose;
            Close();
        }
    }
}
