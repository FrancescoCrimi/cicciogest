using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppWpf.Messages
{
    class ChangePage
    {
        public Type ViewType { get; private set; }
        public ChangePage(Type viewType)
        {
            ViewType = viewType;
        }
    }
}
