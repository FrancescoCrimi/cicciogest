﻿using Castle.Core.Logging;
using CiccioGest.Domain.Common;
using CiccioGest.Domain.Documenti;
using CiccioGest.Domain.Magazino;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.DomainBase;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Constraints;
using Db4objects.Db4o.Events;
using Db4objects.Db4o.Ext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Infrastructure.Persistence.Db4o
{
    class UnitOfWorkFactoryDb4o : IUnitOfWorkFactory
    {
        private IConf conf;
        private ILogger logger;
        private IExtObjectContainer extObjectContainer;

        public UnitOfWorkFactoryDb4o(IConf conf, ILogger logger)
        {
            this.conf = conf;
            this.logger = logger;
            startDb4o();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Created");
        }



        #region Metodi Privati

        private void startDb4o()
        {
            if (extObjectContainer == null || extObjectContainer.IsClosed())
            {
                IEmbeddedConfiguration db4oConf = getDb4oConf();
                IEmbeddedObjectContainer embeddedObjectContainer = Db4oEmbedded.OpenFile(db4oConf, conf.CS);
                registerEventOnContainer(embeddedObjectContainer);
                extObjectContainer = extObjectContainer.Ext();
            }
        }

        private void stopDb4o()
        {
            extObjectContainer.Close();
            extObjectContainer.Dispose();
            extObjectContainer = null;
        }

        private IEmbeddedConfiguration getDb4oConf()
        {
            // crea nuova Configurazione
            IEmbeddedConfiguration configuration = Db4oEmbedded.NewConfiguration();

            // indice Id Entity
            configuration.Common.ObjectClass(typeof(Entity<>)).ObjectField("id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(DomainEntity<>)).ObjectField("Id").Indexed(true);
            configuration.Common.ObjectClass(typeof(ValueObject<>)).ObjectField("id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(Fattura)).ObjectField("id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(Categoria)).ObjectField("id").Indexed(true);
            //configuration.Common.ObjectClass(typeof(Prodotto)).ObjectField("id").Indexed(true);

            // Unique Constraints
            configuration.Common.Add(new UniqueFieldValueConstraint(typeof(DomainEntity), "Id"));
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(ValueObject<>), "id"));
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Fattura), "idFattura"));
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Categoria), "idCategoria"));
            //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Prodotto), "idProdotto"));

            // Diagnostica a console visual studio
            configuration.Common.Diagnostic.AddListener(new Db4objects.Db4o.Diagnostic.DiagnosticToConsole());

            //
            configuration.Common.ObjectClass(typeof(Fattura)).CascadeOnUpdate(true);
            configuration.Common.ObjectClass(typeof(Articolo)).CascadeOnDelete(true);

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
                // e.Object type is Generic and is DomainEntity<> or ValueObject<>
                if (e.Object.GetType().BaseType.IsGenericType && (
                    e.Object.GetType().BaseType.GetGenericTypeDefinition() == typeof(DomainEntity) ||
                    e.Object.GetType().BaseType.GetGenericTypeDefinition() == typeof(ValueObject<>)))
                {
                    e.Object.GetType().GetProperty("Id").SetValue(e.Object, increment.GetNextID(e.Object.GetType()));
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



        internal IExtObjectContainer ObjectContainer
        {
            get
            {
                return extObjectContainer;
            }
        }


        public void CreateDataAccess()
        {
            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            string suca = basepath + conf.CS;
            stopDb4o();
            File.Delete(suca);
            startDb4o();
        }

        public void VerifyDataAccess()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            stopDb4o();
            logger.Debug("HashCode: " + GetHashCode().ToString() + " Disposed");
        }
    }
}