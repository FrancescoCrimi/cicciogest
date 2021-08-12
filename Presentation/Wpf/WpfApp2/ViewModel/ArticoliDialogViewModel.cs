﻿using CiccioGest.Application;
using CiccioGest.Presentation.WpfApp.Contracts;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ArticoliDialogViewModel : ArticoliViewModel
    {
        private readonly INavigationService navigationService;

        public ArticoliDialogViewModel(ILogger<ArticoliViewModel> logger,
                                       IMagazinoService magazinoService,
                                       INavigationService navigationService)
            : base(logger, magazinoService, navigationService)
        {
            this.navigationService = navigationService;
        }

        protected override void ApriArticolo()
        {
            if (ArticoloSelezionato != null)
            {
                Messenger.Send(new ArticoloIdMessage(ArticoloSelezionato.Id));
                navigationService.GoBack();
            }
        }
    }
}