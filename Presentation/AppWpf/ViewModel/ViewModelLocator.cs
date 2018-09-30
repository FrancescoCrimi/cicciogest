/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:AppMvvmLight.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf.Design;
using CiccioGest.Presentation.AppWpf.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static IWindsorContainer windsor;

        static ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                //windsor = Bootstrap.DesignWindsor;
                windsor.Register(
                    Component.For<IDataService>().ImplementedBy<DesignDataService>(),
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>());
            }
            else
            {
                windsor = Bootstrap.Windsor;
                windsor.Register(Component.For<IDataService>().ImplementedBy<DataService>());
                windsor.Install(new CiccioGest.Presentation.Client.Installer());
            }
            windsor.Register(
                Component.For<MainViewModel>(),
                Component.For<SelezionaFatturaViewModel>(),
                Component.For<SelezionaProdottoViewModel>(),
                Component.For<CategoriaViewModel>(),
                Component.For<FatturaViewModel>(),
                Component.For<ProdottoViewModel>());
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return windsor.Resolve<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the SelezionaFattura property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SelezionaFatturaViewModel SelezionaFattura
        {
            get
            {
                return windsor.Resolve<SelezionaFatturaViewModel>();
            }
        }

        /// <summary>
        /// Gets the SelezionaProdotto property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SelezionaProdottoViewModel SelezionaProdotto
        {
            get
            {
                return windsor.Resolve<SelezionaProdottoViewModel>();
            }
        }

        /// <summary>
        /// Gets the SelezionaProdotto property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CategoriaViewModel Categoria
        {
            get
            {
                return windsor.Resolve<CategoriaViewModel>();
            }
        }

        /// <summary>
        /// Gets the SelezionaProdotto property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public FatturaViewModel Fattura
        {
            get
            {
                return windsor.Resolve<FatturaViewModel>();
            }
        }

        /// <summary>
        /// Gets the SelezionaProdotto property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ProdottoViewModel Prodotto
        {
            get
            {
                return windsor.Resolve<ProdottoViewModel>();
            }
        }


        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}