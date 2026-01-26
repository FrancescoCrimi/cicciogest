// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiBackend.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIEx;

namespace CiccioGest.Presentation.WinUiNav.Views
{
    public sealed partial class MainView : WindowEx
    {
        private MainViewModel ViewModel { get; }

        public MainView(NavigationService navigationService,
                        MainViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            ViewModel = mainViewModel;
        }

        private async void WindowEx_Activated(object sender, WindowActivatedEventArgs args)
        {
            await ViewModel.LoadedCommand.ExecuteAsync(null);
        }

        private void WindowEx_Closed(object sender, WindowEventArgs args)
        {
            ViewModel.UnloadedCommand.Execute(null);
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
                }
            }
        }
    }
}
