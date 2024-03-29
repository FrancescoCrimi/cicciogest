﻿using CiccioGest.Application.FakeImpl;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    internal class SettingService : ISettingService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IFatturaService fatturaService;
        private readonly IMagazinoService magazinoService;
        private readonly IClientiFornitoriService clientiFornitoriService;

        public SettingService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IFatturaService fatturaService,
            IMagazinoService magazinoService,
            IClientiFornitoriService clientiFornitoriService)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.fatturaService = fatturaService;
            this.magazinoService = magazinoService;
            this.clientiFornitoriService = clientiFornitoriService;
        }

        public void CreateDataAccess()
        {
            unitOfWorkFactory.CreateDataAccess();
        }

        public async Task LoadSampleData()
        {
            await CreaCategorie();
            await CreaClienti();
            await CreaFornitori();
            await CreaArticoli();
            await CreaFatture();
        }

        public void SaveConf()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            unitOfWorkFactory.VerifyDataAccess();
        }



        private async Task CreaCategorie()
        {
            foreach (var item in FakeSampleData.Categorie)
            {
                await magazinoService.SaveCategoria(item);
            }
        }

        private async Task CreaClienti()
        {
            foreach (var item in FakeSampleData.Clienti)
            {
                await clientiFornitoriService.SaveCliente(item);
            }
        }
                                                                                      
        private async Task CreaFornitori()
        {
            foreach (var item in FakeSampleData.Fornitori)
            {
                await clientiFornitoriService.SaveFornitore(item);
            }
        }

        private async Task CreaArticoli()
        {

            for (int p = 1; p <= FakeSampleData.Articoli.Count; p++)
            {
                Articolo articolo = FakeSampleData.Articoli[p -1];
                Categoria categoria = await magazinoService.GetCategoria(p);
                articolo.AddCategoria(categoria);
                articolo.Fornitore = await magazinoService.GetFornitore(p);
                await magazinoService.SaveArticolo(articolo);
            }
        }

        private async Task CreaFatture()
        {
            for (int i = 1; i < 6; i++)
            {
                var clie = await fatturaService.GetCliente(i);
                Fattura fatt = new Fattura(clie);
                for (int o = 1; o < (i + 1); o++)
                {

                    var articolo = await magazinoService.GetArticolo(o);
                    Dettaglio dett = new Dettaglio(articolo, o);
                    fatt.AddDettaglio(dett);
                }
                await fatturaService.SaveFattura(fatt);
            }
        }

    }
}
