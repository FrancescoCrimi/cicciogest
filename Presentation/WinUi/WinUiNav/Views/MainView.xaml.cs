// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.ViewModels;
using CiccioGest.Presentation.WinUiBackend.Services;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiNav.Views
{
    public sealed partial class MainView : UserControl
    {
        public MainView(NavigationService navigationService,
                        MainViewModel mainViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = mainViewModel;
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer?.Tag is string tag)
            {
                // Chiamata al ViewModel (assumendo sia il tuo DataContext)
                if (DataContext is MainViewModel vm)
                {
                    switch (tag)
                    {
                        case "Dashboard":
                            vm.ApriDashboardCommand.Execute(null);
                            break;
                        case "Fatture":
                            vm.ApriFatturaCommand.Execute(null);
                            break;
                        case "Articoli":
                            vm.ApriArticoliCommand.Execute(null);
                            break;
                        case "Categorie":
                            vm.ApriCategorieCommand.Execute(null);
                            break;
                        case "Clienti":
                            vm.ApriClientiCommand.Execute(null);
                            break;
                        case "Fornitori":
                            vm.ApriFornitoriCommand.Execute(null);
                            break;
                    }
                }
            }
        }
    }
}
