// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure
{
    public static class InitialDataReader
    {
        // Configurazione opzioni (opzionale)
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,                               // Formatta il JSON con rientri (leggibile)
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase   // Converte Nome -> nome
        };

        public static async Task<IEnumerable<NazioneSeed>> LoadNazioniAsync()
        {
            using FileStream openStream = File.OpenRead("Nazioni.json");
            var nazioni = await JsonSerializer.DeserializeAsync<List<NazioneSeed>>(openStream, options);
            return nazioni ??= [];
        }

        public static async Task<IEnumerable<ComuneSeed>> LoadComuni()
        {
            using FileStream openStream = File.OpenRead("Comuni.json");
            var comuni = await JsonSerializer.DeserializeAsync<List<ComuneSeed>>(openStream, options);
            return comuni ??= [];
        }
    }

    public record ComuneSeed(
        int Id,
        string Nome,
        string Provincia,
        List<string> Caps,
        int IdNazione);

    public record NazioneSeed(
        int Id,
        string Nome,
        string Sigla);
}
