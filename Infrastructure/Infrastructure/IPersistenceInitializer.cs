// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure
{
    public interface IPersistenceInitializer
    {
        // Esegue la creazione dello schema e il seeding in ordine gerarchico
        Task InitializeAsync(bool includeTestData = false, CancellationToken ct = default);

        Task VerifyDataAccess();
    }
}
