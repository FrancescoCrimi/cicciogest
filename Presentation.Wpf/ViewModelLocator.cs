using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ciccio1.Infrastructure;
using Ciccio1.Presentation.Wpf.ViewModel;

namespace Ciccio1.Presentation.Wpf
{
    public class ViewModelLocator
    {
        private readonly static Container ioc;

        static ViewModelLocator()
        {
            ioc = new Container();
            ioc.Install(new Installer());
        }

        public FattureViewModel FattureViewModel
        {
            get { return ioc.Resolve<FattureViewModel>(); }
        }

        public FatturaViewModel FatturaViewModel
        {
            get { return ioc.Resolve<FatturaViewModel>(); }
        }

        public ProdottiViewModel ProdottiViewModel
        {
            get 
            {
                return ioc.Resolve<ProdottiViewModel>();
            }
        }

        public CategorieViewModel CategorieViewModel
        {
            get
            {
                return ioc.Resolve<CategorieViewModel>();
            }
        }

        public SelezionaProdottoViewModel SelezionaProdottoViewModel
        {
            get { return ioc.Resolve<SelezionaProdottoViewModel>(); }
        }
    }
}
