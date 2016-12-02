using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Constraints;
using Db4objects.Db4o.Events;
using Ciccio1.Domain;
using Ciccio1.Infrastructure.Conf;
using Ciccio1.Infrastructure.DomainBase;
using Castle.Core.Logging;

namespace Ciccio1.Infrastructure.Persistence.Db4o
{
    class DataAccess : IDataAccess
    {
        private static IEmbeddedObjectContainer embeddedObjectContainer;
        private IConf conf;
        private ILogger logger;
        private IObjectContainer objectContainer;

        public DataAccess(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
            if (embeddedObjectContainer == null || embeddedObjectContainer.Ext().IsClosed())
            {
                IEmbeddedConfiguration db4oConf = getDb4oConf();
                embeddedObjectContainer = Db4oEmbedded.OpenFile(db4oConf, conf.ConnectionString);
                registerEventOnContainer(embeddedObjectContainer);
            }
        }


        #region Metodi Privati

        private IEmbeddedConfiguration getDb4oConf()
        {
            // crea nuova Configurazione
            IEmbeddedConfiguration configuration = Db4oEmbedded.NewConfiguration();

            // indice Id Entity
            ////configuration.Common.ObjectClass(typeof(IEntity<int>)).ObjectField("Id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(Entity<>)).ObjectField("id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(ValueObject<>)).ObjectField("id").Indexed(true);
            configuration.Common.ObjectClass(typeof(Fattura)).ObjectField("idFattura").Indexed(true);
            configuration.Common.ObjectClass(typeof(Categoria)).ObjectField("idCategoria").Indexed(true);
            configuration.Common.ObjectClass(typeof(Prodotto)).ObjectField("idProdotto").Indexed(true);

            // Unique Constraints
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Entity<>), "id"));
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(ValueObject<>), "id"));
            configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Fattura), "idFattura"));
            configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Categoria), "idCategoria"));
            configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Prodotto), "idProdotto"));

            // Diagnostica a console visual studio
            configuration.Common.Diagnostic.AddListener(new Db4objects.Db4o.Diagnostic.DiagnosticToConsole());

            //
            configuration.Common.ObjectClass(typeof(Fattura)).CascadeOnUpdate(true);
            configuration.Common.ObjectClass(typeof(Prodotto)).CascadeOnDelete(true);

            //
            configuration.Common.ExceptionsOnNotStorable = false;

            return configuration;
        }

        private void registerEventOnContainer(IObjectContainer container)
        {
            IEventRegistry events = EventRegistryFactory.ForObjectContainer(container);

            // eventi autoincrement
            AutoIncrement increment = new AutoIncrement(container);
            events.Creating += (s, e) =>
            {
                if (e.Object is Entity<int>)
                {
                    e.GetType().GetProperty("Id").SetValue(e, increment.GetNextID(e.GetType()));
                }
            };

            events.Committing += (s, e) =>
            {
                increment.StoreState();
            };

            //// eventi Validating
            //events.Creating += ValidateEntity;
            //events.Updating += ValidateEntity;
        }

        #endregion Metodi Privati

        internal IObjectContainer ObjectContainer
        {
            get
            {
                if (objectContainer != null)
                    return objectContainer;
                else
                {
                    Begin();
                    return objectContainer;
                }
            }
        }


        public void CreateDataAccess()
        {
            throw new NotImplementedException();
        }

        public void VerifyDataAccess()
        {
            throw new NotImplementedException();
        }

        public void Begin()
        {
            disposeObjectContainer();
            objectContainer = embeddedObjectContainer.Ext().OpenSession();
        }

        public void Commit()
        {
            try
            {
                objectContainer.Commit();
            }
            catch (Exception ex)
            {
                objectContainer.Rollback();
            }
        }

        public void Rollback()
        {
            objectContainer.Rollback();
        }

        private void disposeObjectContainer()
        {
            objectContainer.Rollback();
            objectContainer.Close();
            objectContainer.Dispose();
        }

        public void Dispose()
        {
            disposeObjectContainer();
        }

    }
}
