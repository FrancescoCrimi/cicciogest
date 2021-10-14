using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISettingView : IView
    {
        event EventHandler VerificaDatabaseEvent;
        event EventHandler CreaDatabaseEvent;
        event EventHandler PopolaDatabaseEvent;
    }
}
