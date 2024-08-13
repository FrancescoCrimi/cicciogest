// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Application.FakeImpl;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    internal class SettingService : ISettingService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IFatturaService _fatturaService;
        private readonly IMagazzinoService _magazzinoService;
        private readonly IClientiFornitoriService _clientiFornitoriService;

        public SettingService(IUnitOfWorkFactory unitOfWorkFactory,
                              IFatturaService fatturaService,
                              IMagazzinoService magazzinoService,
                              IClientiFornitoriService clientiFornitoriService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _fatturaService = fatturaService;
            _magazzinoService = magazzinoService;
            _clientiFornitoriService = clientiFornitoriService;
        }

        public void CreateDataAccess()
        {
            _unitOfWorkFactory.CreateDataAccess();
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
            _unitOfWorkFactory.VerifyDataAccess();
        }



        private async Task CreaCategorie()
        {
            foreach (var item in FakeSampleData.Categorie)
            {
                await _magazzinoService.SaveCategoria(item);
            }
        }

        private async Task CreaClienti()
        {
            foreach (var item in FakeSampleData.Clienti)
            {
                await _clientiFornitoriService.SaveCliente(item);
            }
        }
                                                                                      
        private async Task CreaFornitori()
        {
            foreach (var item in FakeSampleData.Fornitori)
            {
                await _clientiFornitoriService.SaveFornitore(item);
            }
        }

        private async Task CreaArticoli()
        {

            for (int p = 1; p <= FakeSampleData.Articoli.Count; p++)
            {
                Articolo articolo = FakeSampleData.Articoli[p -1];
                Categoria categoria = await _magazzinoService.GetCategoria(p);
                articolo.AddCategoria(categoria);
                articolo.Fornitore = await _magazzinoService.GetFornitore(p);
                await _magazzinoService.SaveArticolo(articolo);
            }
        }

        private async Task CreaFatture()
        {
            for (int i = 1; i < 6; i++)
            {
                var clie = await _fatturaService.GetCliente(i);
                Fattura fatt = new Fattura(clie);
                for (int o = 1; o < (i + 1); o++)
                {

                    var articolo = await _magazzinoService.GetArticolo(o);
                    Dettaglio dett = new Dettaglio(articolo, o);
                    fatt.AddDettaglio(dett);
                }
                await _fatturaService.SaveFattura(fatt);
            }
        }

    }
}
