using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppWpf.Messages
{
    public enum TypeOfSearch
    {
        Fattura = 1,
        Prodotto,
    }
    class OpenSelectWindow
    {
        public bool GoToPage { get; private set; }
        public TypeOfSearch TypeOfSearch { get; private set; }
        public OpenSelectWindow(TypeOfSearch type, bool goToPage)
        {
            TypeOfSearch = type;
            GoToPage = goToPage;
        }
    }
}
