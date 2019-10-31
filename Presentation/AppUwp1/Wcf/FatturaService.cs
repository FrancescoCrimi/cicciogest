using AutoMapper;
using CiccioSoft.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppUwp1.Wcf
{
    class FatturaService : FatturaServiceClient, Application.IFatturaService
    {
        private readonly Mapper mapper;
        public FatturaService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FatturaReadOnly, Domain.Documenti.FatturaReadOnly>();
                cfg.CreateMap<Articolo, Domain.Magazino.Articolo>();
                cfg.CreateMap<Categoria, Domain.Magazino.Categoria>();
                cfg.CreateMap<Dettaglio, Domain.Documenti.Dettaglio>();
                cfg.CreateMap<Fattura, Domain.Documenti.Fattura>()
                    .ForMember(dest => dest.Dettagli, opt => opt.AddTransform(lst => new CiccioList<Domain.Documenti.Dettaglio>(lst)));

                cfg.CreateMap<Domain.Documenti.FatturaReadOnly, FatturaReadOnly>();
                cfg.CreateMap<Domain.Magazino.Articolo, Articolo>();
                cfg.CreateMap<Domain.Magazino.Categoria, Categoria>();
                cfg.CreateMap<Domain.Documenti.Dettaglio, Dettaglio>();
                cfg.CreateMap<Domain.Documenti.Fattura, Fattura>();
            });
            config.AssertConfigurationIsValid();
            mapper = new Mapper(config);
        }

        public Task DeleteFattura(int id)
        {
            return DeleteFatturaAsync(id);
        }

        public Task<Domain.Magazino.Articolo> GetArticolo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ClientiFornitori.Cliente> GetCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Documenti.Fattura> GetFattura(int id)
        {
            //return Asaa(id);
            return Task.Run(async () =>
            {
                Fattura asdf = await GetFatturaAsync(id);
                return mapper.Map<Fattura, Domain.Documenti.Fattura>(asdf);
            });
        }

        //private async Task<Domain.Documenti.Fattura> Asaa(int id)
        //{
        //    Fattura asdf = await GetFatturaAsync(id);
        //    return mapper.Map<Fattura, Domain.Documenti.Fattura>(asdf);
        //}

        public Task<IEnumerable<Domain.Documenti.FatturaReadOnly>> GetFatture()
        {
            return Task.Run(async () =>
            {
                var lst = await GetFattureAsync();
                return mapper.Map<IEnumerable<FatturaReadOnly>, IEnumerable<Domain.Documenti.FatturaReadOnly>>(lst);
            });
        }

        public Task<Domain.Documenti.Fattura> SaveFattura(Domain.Documenti.Fattura fattura)
        {
            return Task.Run(async () =>
            {
                Fattura fattura1 = mapper.Map<Domain.Documenti.Fattura, Fattura>(fattura);
                Fattura asasa = await SaveFatturaAsync(fattura1);
                return mapper.Map<Fattura, Domain.Documenti.Fattura>(asasa);
            });
        }
    }
}
