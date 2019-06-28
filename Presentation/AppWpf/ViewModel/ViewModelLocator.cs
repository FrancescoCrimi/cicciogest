using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CiccioGest.Application;
using CiccioGest.Infrastructure;
using CiccioGest.Presentation.AppWpf.Design;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace CiccioGest.Presentation.AppWpf.ViewModel
{
    public class ViewModelLocator
    {
        static readonly IWindsorContainer windsor;

        static ViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                windsor = new WindsorContainer();
                windsor.AddFacility<LoggingFacility>();
                windsor.Register(
                    Component.For<IFatturaService>().ImplementedBy<DesignFatturaService>(),
                    Component.For<IMagazinoService>().ImplementedBy<DesignMagazinoService>(),
                    Component.For<IClientiFornitoriService>().ImplementedBy<DesignClientiFornitoriService>());
            }
            else
            {
                windsor = Bootstrap.Windsor;
                windsor.Install(new CiccioGest.Presentation.Client.Installer());
            }
            windsor.Register(
                Component.For<MainViewModel>(),
                Component.For<SelezionaFatturaViewModel>().LifestyleTransient(),
                Component.For<SelezionaProdottoViewModel>().LifestyleTransient(),
                Component.For<CategoriaViewModel>().LifestyleTransient(),
                Component.For<FatturaViewModel>().LifestyleTransient(),
                Component.For<ProdottoViewModel>().LifestyleTransient());
        }

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

        public static void Cleanup()
        {
        }
    }
}