using Gtk;
using System;
using System.Collections.Generic;
using System.Text;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter
{
    public interface IMainPresenter : IPresenter
    {
        void ApriArticoli();
        void ApriCategorie();
        void ApriFatture();
        Window View();
    }
}
