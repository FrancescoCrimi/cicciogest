using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Constraints;
using Db4objects.Db4o.Events;
using CiccioGest.Domain;
using CiccioGest.Infrastructure.Conf;
using CiccioGest.Infrastructure.DomainBase;
using Castle.Core.Logging;
using System.IO;

namespace CiccioGest.Infrastructure.Persistence.Db4o
{
    //class DataAccess //: IDataAccess
    //{
    //    private IEmbeddedObjectContainer embeddedObjectContainer;
    //    private IConf conf;
    //    private ILogger logger;

    //    //public DataAccess(ILogger logger, IConf conf)
    //    //{
    //    //    this.logger = logger;
    //    //    this.conf = conf;
    //    //    startDb4o();
    //    //    logger.Debug("DataAccess Creata " + this.GetHashCode().ToString());
    //    //}


    //    //#region Metodi Privati

    //    //private void startDb4o()
    //    //{
    //    //    if (embeddedObjectContainer == null || embeddedObjectContainer.Ext().IsClosed())
    //    //    {
    //    //        IEmbeddedConfiguration db4oConf = getDb4oConf();
    //    //        embeddedObjectContainer = Db4oEmbedded.OpenFile(db4oConf, conf.CS);
    //    //        registerEventOnContainer(embeddedObjectContainer);
    //    //    }
    //    //}

    //    //private void stopDb4o()
    //    //{
    //    //    embeddedObjectContainer.Close();
    //    //    embeddedObjectContainer.Dispose();
    //    //    embeddedObjectContainer = null;
    //    //}

    //    //private IEmbeddedConfiguration getDb4oConf()
    //    //{
    //    //    // crea nuova Configurazione
    //    //    IEmbeddedConfiguration configuration = Db4oEmbedded.NewConfiguration();

    //    //    // indice Id Entity
    //    //    configuration.Common.ObjectClass(typeof(Entity<,>)).ObjectField("id").Indexed(true);
    //    //    //configuration.Common.ObjectClass(typeof(DomainEntity<>)).ObjectField("Id").Indexed(true);
    //    //    configuration.Common.ObjectClass(typeof(ValueObject<>)).ObjectField("id").Indexed(true);
    //    //    //configuration.Common.ObjectClass(typeof(Fattura)).ObjectField("id").Indexed(true);
    //    //    //configuration.Common.ObjectClass(typeof(Categoria)).ObjectField("id").Indexed(true);
    //    //    //configuration.Common.ObjectClass(typeof(Prodotto)).ObjectField("id").Indexed(true);

    //    //    // Unique Constraints
    //    //    configuration.Common.Add(new UniqueFieldValueConstraint(typeof(DomainEntity<>), "Id"));
    //    //    //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(ValueObject<>), "id"));
    //    //    //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Fattura), "idFattura"));
    //    //    //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Categoria), "idCategoria"));
    //    //    //configuration.Common.Add(new UniqueFieldValueConstraint(typeof(Prodotto), "idProdotto"));

    //    //    // Diagnostica a console visual studio
    //    //    configuration.Common.Diagnostic.AddListener(new Db4objects.Db4o.Diagnostic.DiagnosticToConsole());

    //    //    //
    //    //    configuration.Common.ObjectClass(typeof(Fattura)).CascadeOnUpdate(true);
    //    //    configuration.Common.ObjectClass(typeof(Prodotto)).CascadeOnDelete(true);

    //    //    //
    //    //    configuration.Common.ExceptionsOnNotStorable = false;

    //    //    return configuration;
    //    //}

    //    //private void registerEventOnContainer(IObjectContainer container)
    //    //{
    //    //    IEventRegistry events = EventRegistryFactory.ForObjectContainer(container);

    //    //    // eventi autoincrement
    //    //    AutoIncrement increment = new AutoIncrement(container);
    //    //    events.Creating += (s, e) =>
    //    //    {
    //    //        // e.Object type is Generic and is DomainEntity<> or ValueObject<>
    //    //        if (e.Object.GetType().BaseType.IsGenericType && (
    //    //            e.Object.GetType().BaseType.GetGenericTypeDefinition() == typeof(DomainEntity<>) ||
    //    //            e.Object.GetType().BaseType.GetGenericTypeDefinition() == typeof(ValueObject<>)))
    //    //        {
    //    //            e.Object.GetType().GetProperty("Id").SetValue(e.Object, increment.GetNextID(e.Object.GetType()));
    //    //        }
    //    //    };

    //    //    events.Committing += (s, e) =>
    //    //    {
    //    //        increment.StoreState();
    //    //    };

    //    //    //// eventi Validating
    //    //    //events.Creating += ValidateEntity;
    //    //    //events.Updating += ValidateEntity;
    //    //}

    //    //#endregion Metodi Privati

    //    //internal IObjectContainer ObjectContainer
    //    //{
    //    //    get
    //    //    {
    //    //        return embeddedObjectContainer;
    //    //    }
    //    //}

    //    #region Metodi Publici

    //    //public void CreateDataAccess()
    //    //{
    //    //    string basepath = AppDomain.CurrentDomain.BaseDirectory;
    //    //    string suca = basepath + conf.CS;
    //    //    stopDb4o();
    //    //    File.Delete(suca);
    //    //    startDb4o();
    //    //}

    //    //public void VerifyDataAccess()
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void Begin()
    //    //{
    //    //    //throw new NotImplementedException();
    //    //}

    //    //public void Commit()
    //    //{
    //    //    try
    //    //    {
    //    //        embeddedObjectContainer.Commit();
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        embeddedObjectContainer.Rollback();
    //    //        throw ex;
    //    //    }
    //    //}

    //    //public void Rollback()
    //    //{
    //    //    embeddedObjectContainer.Rollback();
    //    //}

    //    #endregion Metodi Publici

    //    //public void Dispose()
    //    //{
    //    //    stopDb4o();
    //    //    logger.Debug("DataAccess Dispose " + this.GetHashCode().ToString());
    //    //}

    //}
}
