// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.UwpBackend.Services
{
    public enum Views
    {
        Dashboard,
        Articoli,
        Articolo,
        Categoria,
        Cliente,
        Clienti,
        Fattura,
        Fatture,
        Fornitore,
        Fornitori,
        ListaArticoli,
        ListaClienti,
        ListaFatture,
        ListaFornitori
    }

    public interface INavigationService
    {
        bool CanGoBack { get; }
        bool CanGoForward { get; }

        void GoBack();
        void GoForward();
        bool Navigate(Type pageType, object parameter = null, bool clearNavigation = false);
        bool Navigate(Views key, object parameter = null, bool clearNavigation = false);
        //bool Navigate<T>(object parameter = null, bool clearNavigation = false) where T : Page;
    }
}