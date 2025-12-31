// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Domain.Anagrafica;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Infrastructure.Conf;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Nhb
{
    public class PersistenceInitializer(ILogger<PersistenceInitializer> logger,
                                          ISessionFactory sessionFactory,
                                          NHibernate.Cfg.Configuration configuration,
                                          CiccioGestConf conf)
        : IPersistenceInitializer
    {
        public async Task InitializeAsync(bool includeTestData = false,
                                    CancellationToken ct = default)
        {
            logger.LogInformation("Inizio inizializzazione database...");

            // Script diversi per database creazione db etc..
            switch (conf.Database)
            {
                case Databases.MySql:
                    //InitMySql();
                    break;
                case Databases.SQLite:
                    InitSQLite();
                    break;
                case Databases.MsSql:
                    break;
                case Databases.PgSql:
                    break;
            }

            // FASE 1: Creazione Schema (DDL)
            SchemaExport SE = new(configuration);
            //SE.Execute(false, true, false);
            SE.Drop(true, true);
            SE.Create(true, true);

            // FASE 2: Dati Statici (Master Data - Nazioni, Comuni, aliquote)
            await SeedMasterDataAsync(ct);

            // FASE 3: Dati di Test (Opzionali)
            if (includeTestData)
            {
                await SeedTestDataAsync(ct);
            }

            logger.LogInformation("Inizializzazione completata con successo.");
        }

        public Task VerifyDataAccess()
        {
            SchemaValidator sv = new(configuration);
            return sv.ValidateAsync();
        }

        private async Task SeedMasterDataAsync(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            //if (await session.Query<Nazione>().AnyAsync(ct)) return;
            logger.LogInformation("Caricamento Master Data: Nazioni e Comuni...");

            using (var tx = session.BeginTransaction())
            {
                var nazioni = await InitialDataReader.LoadNazioniAsync();
                try
                {
                    foreach (var nazione in nazioni)
                    {
                        Nazione nazioneEntity = new(nazione.Nome, nazione.Sigla);
                        await session.SaveAsync(nazioneEntity, ct);
                    }
                    await tx.CommitAsync(ct);
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync(ct);
                    logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                    throw;
                }
            }

            using (var tx = session.BeginTransaction())
            {
                var comuni = await InitialDataReader.LoadComuni();
                try
                {
                    foreach (var comune in comuni)
                    {
                        var nazioneEntity = await session.GetAsync<Nazione>(comune.IdNazione, ct);
                        Comune comuneEntity = new(comune.Nome, comune.Provincia, [.. comune.Caps], nazioneEntity);
                        await session.SaveAsync(comuneEntity, ct);
                    }
                    await tx.CommitAsync(ct);
                }
                catch (Exception ex)
                {
                    await tx.RollbackAsync(ct);
                    logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                    throw;
                }
            }
        }

        private async Task SeedTestDataAsync(CancellationToken ct)
        {
            await CreaClienti(ct);
            await CreaFornitori(ct);
            await CreaCategorie(ct);
            await CreaArticoli(ct);
            await CreaFatture(ct);
        }

        private async Task CreaClienti(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            try
            {
                foreach (var cliente in TestDataGenerator.GeneraClienti())
                {
                    Comune comune = await session.GetAsync<Comune>(Random.Shared.Next(1, 7896), ct);
                    Cliente clie = new()
                    {
                        Nome = cliente.NomeCompleto,
                        Email = cliente.Email,
                        Telefono = cliente.Telefono,
                        Indirizzo = new Indirizzo(cliente.Via, cliente.Civico, comune),
                        PartitaIva = cliente.PartitaIva,
                        CodiceFiscale = cliente.CodiceFiscale
                    };
                    await session.SaveAsync(clie, ct);
                }
                await transaction.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                throw;
            }
        }

        private async Task CreaFornitori(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            try
            {
                foreach (var fornitore in TestDataGenerator.GeneraFornitori())
                {
                    Comune comune = await session.GetAsync<Comune>(Random.Shared.Next(1, 7896), ct);
                    Fornitore forn = new()
                    {
                        Nome = fornitore.NomeCompleto,
                        Email = fornitore.Email,
                        Telefono = fornitore.Telefono,
                        Indirizzo = new Indirizzo(fornitore.Via, fornitore.Civico, comune),
                        PartitaIva = fornitore.PartitaIva,
                        CodiceFiscale = fornitore.CodiceFiscale
                    };
                    await session.SaveAsync(forn, ct);
                }
                await transaction.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                throw;
            }
        }

        private async Task CreaCategorie(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            try
            {
                foreach (var categoria in TestDataGenerator.GeneraCategorie())
                {
                    Categoria cat = new()
                    {
                        Nome = categoria.Nome
                    };
                    await session.SaveAsync(cat, ct);
                }
                await transaction.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                throw;
            }
        }

        private async Task CreaArticoli(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            try
            {
                foreach (var articolo in TestDataGenerator.GeneraArticoli())
                {
                    var fornitore = await session.GetAsync<Fornitore>(articolo.FornitoreId, ct);
                    Articolo articolo1 = new()
                    {
                        Nome = articolo.NomeArticolo,
                        Prezzo = (int)(articolo.Prezzo * 100),
                        Fornitore = fornitore
                    };
                    foreach (var catId in articolo.CategorieIds)
                    {
                        Categoria categoria = await session.GetAsync<Categoria>(catId, ct);
                        articolo1.AddCategoria(categoria);
                    }
                    await session.SaveAsync(articolo1, ct);
                }
                await transaction.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                throw;
            }
        }

        private async Task CreaFatture(CancellationToken ct)
        {
            using var session = sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();
            try
            {
                for (int i = 1; i < 6; i++)
                {
                    var clie = await session.GetAsync<Cliente>(Random.Shared.Next(1, 50), ct);
                    Fattura fatt = new(clie);
                    var numberDetails = Random.Shared.Next(1, 5);
                    for (int o = 1; o < numberDetails; o++)
                    {
                        var articolo = await session.GetAsync<Articolo>(Random.Shared.Next(1, 50), ct);
                        Dettaglio dett = new(articolo, Random.Shared.Next(1, 10));
                        fatt.AddDettaglio(dett);
                    }
                    await session.SaveAsync(fatt, ct);
                }
                await transaction.CommitAsync(ct);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(ct);
                logger.LogCritical(ex, "Fallimento critico durante il seeding del database.");
                throw;
            }
        }



        private bool InitMySql()
        {
            MySqlConnection conn = new MySqlConnection(conf.CS);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "drop database CiccioGestNhb";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "create database if not exists CiccioGestNhb";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return true;
        }

        private bool InitSQLite()
        {
            string dbFile = conf.CS.Split(new char[] { '=' })[1].Trim();
            if (!File.Exists(dbFile))
            {
                SQLiteConnection conn = new SQLiteConnection(conf.CS);
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            return true;
        }
    }
}
