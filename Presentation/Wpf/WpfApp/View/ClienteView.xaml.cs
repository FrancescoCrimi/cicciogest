﻿using CiccioGest.Presentation.WpfBackend.ViewModel;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp.View
{
    public partial class ClienteView : Page
    {
        public ClienteView(ClienteViewModel clienteViewModel)
        {
            InitializeComponent();
            DataContext = clienteViewModel;
        }
    }
}
