using CiccioGest.Presentation.WpfApp.ViewModel;
using System;
using System.Windows;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class CategoriaView : Window
    {
        private readonly CategoriaViewModel categoriaViewModel;

        public CategoriaView(CategoriaViewModel categoriaViewModel)
        {
            InitializeComponent();
            DataContext = categoriaViewModel;
            this.categoriaViewModel = categoriaViewModel;
            categoriaViewModel.OnRequestClose += CategoriaViewModel_OnRequestClose;
        }

        private void CategoriaViewModel_OnRequestClose(object sender, EventArgs e)
        {
            categoriaViewModel.OnRequestClose -= CategoriaViewModel_OnRequestClose;
            Close();
        }
    }
}
