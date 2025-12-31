// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CiccioGest.Application.Impl
{
    internal class SettingService : ISettingService
    {
        private readonly ILogger<SettingService> _logger;
        private readonly IPersistenceInitializer _persistenceInitializer;
        private readonly IFatturaService _fatturaService;
        private readonly IMagazzinoService _magazzinoService;
        private readonly IAnagraficaService _anagraficaService;

        public SettingService(ILogger<SettingService> logger,
                              IPersistenceInitializer persistenceInitializer,
                              IFatturaService fatturaService,
                              IMagazzinoService magazzinoService,
                              IAnagraficaService anagraficaService)
        {
            _logger = logger;
            _persistenceInitializer = persistenceInitializer;
            _fatturaService = fatturaService;
            _magazzinoService = magazzinoService;
            _anagraficaService = anagraficaService;
            _logger.LogDebug("Created: {HashCode}", GetHashCode().ToString());
        }

        public async Task CreateDataAccess()
        {
            await _persistenceInitializer.InitializeAsync();
        }

        public async Task LoadSampleData()
        {
            await _persistenceInitializer.InitializeAsync(includeTestData: true);
        }

        public void SaveConf()
        {
            throw new NotImplementedException();
        }

        public Task VerifyDataAccess()
        {
            return _persistenceInitializer.VerifyDataAccess();
        }


        public void Dispose()
        {
            _fatturaService.Dispose();
            _magazzinoService.Dispose();
            _anagraficaService.Dispose();
            _logger.LogDebug("Disposed: {HashCode}", GetHashCode().ToString());
        }
    }
}
