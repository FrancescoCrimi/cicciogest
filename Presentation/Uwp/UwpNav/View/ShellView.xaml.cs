// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.UwpBackend.Contracts;
using CiccioGest.Presentation.UwpBackend.Helpers;
using CiccioGest.Presentation.UwpBackend.ViewModel;
using CiccioGest.Presentation.UwpNav.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.UwpNav.View
{
    public sealed partial class ShellView : Page
    {
        private readonly PageService _pageService;

        public ShellView(NavigationService navigationService,
                         PageService pageService,
                         ShellViewModel shellViewModel)
        {
            InitializeComponent();
            navigationService.Initialize(shellFrame);
            DataContext = shellViewModel;
            _pageService = pageService;
            shellFrame.Navigated += ShellFrame_Navigated;
        }

        #region NavigationView MenuItem Selected

        private void ShellFrame_Navigated(object sender,
                                          Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var selectedItem = GetSelectedItem(e.SourcePageType);
            if (selectedItem != null)
            {
                navigationView.SelectedItem = selectedItem;
            }
        }

        private WinUI.NavigationViewItem GetSelectedItem(Type pageType)
        {
            return GetSelectedItem(navigationView.MenuItems, pageType)
                ?? GetSelectedItem(navigationView.FooterMenuItems, pageType)
                ?? GetSelectedItem(new[] { navigationView.SettingsItem }, pageType);
        }

        private WinUI.NavigationViewItem GetSelectedItem(IEnumerable<object> menuItems, Type pageType)
        {
            foreach (var item in menuItems.OfType<WinUI.NavigationViewItem>())
            {
                if (IsMenuItemForPageType(item, pageType))
                {
                    return item;
                }

                var selectedChild = GetSelectedItem(item.MenuItems, pageType);
                if (selectedChild != null)
                {
                    return selectedChild;
                }
            }
            return null;
        }

        private bool IsMenuItemForPageType(WinUI.NavigationViewItem menuItem, Type sourcePageType)
        {
            if (menuItem.GetValue(NavEnumHelper.NavigateToProperty) is ViewEnum pageKey)
            {
                return _pageService.GetPageType(pageKey) == sourcePageType;
            }
            return false;
        }

        #endregion
    }
}
