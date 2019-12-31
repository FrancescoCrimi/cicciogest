using System.Collections.Generic;
using System.ServiceModel.Description;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.Uwp.Client.Wcf
{
    internal partial class FatturaServiceClient
    {
        static partial void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials)
        {
            foreach (OperationDescription od in serviceEndpoint.Contract.Operations)
            {
                DCSWithSurrogatesOperationBehavior newBehavior = null;
                var oldBehavior = od.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (null != oldBehavior)
                {
                    newBehavior = new DCSWithSurrogatesOperationBehavior(oldBehavior);
                    od.OperationBehaviors.Remove(oldBehavior);
                }
                else
                {
                    newBehavior = new DCSWithSurrogatesOperationBehavior();
                }
                newBehavior.SerializationSurrogateProvider = new MySerializationSurrogateProvider();
                od.OperationBehaviors.Add(newBehavior);
            }
        }
    }

    internal class FatturaService : FatturaServiceClient, Application.IFatturaService
    {
        public Task DeleteFattura(int id)
        {
            return DeleteFatturaAsync(id);
        }

        public Task<Domain.Magazino.Articolo> GetArticolo(int id)
        {
            return GetArticoloAsync(id);
        }

        public Task<Domain.ClientiFornitori.Cliente> GetCliente(int idCliente)
        {
            return GetClienteAsync(idCliente);
        }

        public Task<Domain.Documenti.Fattura> GetFattura(int id)
        {
            return GetFatturaAsync(id);
        }

        public Task<IList<Domain.Documenti.FatturaReadOnly>> GetFatture()
        {
            return Task.Run(async () =>
            {
                var lst = await GetFattureAsync();
                return (IList<Domain.Documenti.FatturaReadOnly>)lst;
            });
        }

        public Task<Domain.Documenti.Fattura> SaveFattura(Domain.Documenti.Fattura fattura)
        {
            return SaveFatturaAsync(fattura);
        }
    }
}


//using AutoMapper;
//using CiccioSoft.Collections.Generic;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace CiccioGest.Presentation.Uwp.App1.Wcf
//{
//    class FatturaService : FatturaServiceClient, Application.IFatturaService
//    {
//        private readonly Mapper mapper;
//        public FatturaService()
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<FatturaReadOnly, Domain.Documenti.FatturaReadOnly>();
//                cfg.CreateMap<Articolo, Domain.Magazino.Articolo>();
//                cfg.CreateMap<Categoria, Domain.Magazino.Categoria>();
//                cfg.CreateMap<Dettaglio, Domain.Documenti.Dettaglio>();
//                cfg.CreateMap<Fattura, Domain.Documenti.Fattura>()
//                    .ForMember(dest => dest.Dettagli, opt => opt.AddTransform(lst => new CiccioList<Domain.Documenti.Dettaglio>(lst)));

//                cfg.CreateMap<Domain.Documenti.FatturaReadOnly, FatturaReadOnly>();
//                cfg.CreateMap<Domain.Magazino.Articolo, Articolo>();
//                cfg.CreateMap<Domain.Magazino.Categoria, Categoria>();
//                cfg.CreateMap<Domain.Documenti.Dettaglio, Dettaglio>();
//                cfg.CreateMap<Domain.Documenti.Fattura, Fattura>();
//            });
//            config.AssertConfigurationIsValid();
//            mapper = new Mapper(config);
//        }

//        public Task DeleteFattura(int id)
//        {
//            return DeleteFatturaAsync(id);
//        }

//        public Task<Domain.Magazino.Articolo> GetArticolo(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Domain.ClientiFornitori.Cliente> GetCliente(int idCliente)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Domain.Documenti.Fattura> GetFattura(int id)
//        {
//            //return Asaa(id);
//            return Task.Run(async () =>
//            {
//                Fattura asdf = await GetFatturaAsync(id);
//                return mapper.Map<Fattura, Domain.Documenti.Fattura>(asdf);
//            });
//        }

//        //private async Task<Domain.Documenti.Fattura> Asaa(int id)
//        //{
//        //    Fattura asdf = await GetFatturaAsync(id);
//        //    return mapper.Map<Fattura, Domain.Documenti.Fattura>(asdf);
//        //}

//        public Task<IEnumerable<Domain.Documenti.FatturaReadOnly>> GetFatture()
//        {
//            return Task.Run(async () =>
//            {
//                var lst = await GetFattureAsync();
//                return mapper.Map<IEnumerable<FatturaReadOnly>, IEnumerable<Domain.Documenti.FatturaReadOnly>>(lst);
//            });
//        }

//        public Task<Domain.Documenti.Fattura> SaveFattura(Domain.Documenti.Fattura fattura)
//        {
//            return Task.Run(async () =>
//            {
//                Fattura fattura1 = mapper.Map<Domain.Documenti.Fattura, Fattura>(fattura);
//                Fattura asasa = await SaveFatturaAsync(fattura1);
//                return mapper.Map<Fattura, Domain.Documenti.Fattura>(asasa);
//            });
//        }
//    }
//}

