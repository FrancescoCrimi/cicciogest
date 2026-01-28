// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using Microsoft.UI.Xaml.Controls;
using WinUIEx;

namespace CiccioGest.Presentation.WinUiNav.Views
{
    public sealed partial class MainView : WindowEx
    {
        private MainViewModel ViewModel { get; }

        public MainView(INavigationService navigationService,
                        MainViewModel mainViewModel)
        {
            InitializeComponent();
            Root.DataContext = mainViewModel;
            ViewModel = mainViewModel;
            _ = navigationService.Navigate<DashboardViewModel>();
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {

        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer?.Tag is string tag)
            {
                switch (tag)
                {
                    case "Dashboard":
                        ViewModel.ApriDashboardCommand.Execute(null);
                        break;
                    case "Fatture":
                        ViewModel.ApriFatturaCommand.Execute(null);
                        break;
                    case "Articoli":
                        ViewModel.ApriArticoliCommand.Execute(null);
                        break;
                    case "Categorie":
                        ViewModel.ApriCategorieCommand.Execute(null);
                        break;
                    case "Clienti":
                        ViewModel.ApriClientiCommand.Execute(null);
                        break;
                    case "Fornitori":
                        ViewModel.ApriFornitoriCommand.Execute(null);
                        break;
                    case "Settings":
                        ViewModel.ApriSettingsCommand.Execute(null);
                        break;
                }
            }
        }
    }
}
