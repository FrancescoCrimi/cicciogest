﻿using CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter;
using System;

namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.View
{
    public interface IMainView : IView
    {
        //void SetPresenter(IMainPresenter mainPresenter);

        event EventHandler LoadEvent;
        event EventHandler FattureEvent;
        event EventHandler ClientiEvent;
        event EventHandler FornitoriEvent;
        event EventHandler ArticoliEvent;
        event EventHandler CategorieEvent;
        //event EventHandler InformazioniEvent;
        event EventHandler OpzioniEvent;
    }
}