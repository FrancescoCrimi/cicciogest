using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Ciccio1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciccio1.Presentation.WinForm
{
    static class ViewResolver
    {
        private static IWindsorContainer windsor;
        private static Dictionary<int, IDisposable> dict = new Dictionary<int, IDisposable>();

        static ViewResolver()
        {
            Container container = new Container();
            container.Install(new Installer());
            windsor = container.Windsor;
        }

        internal static TForm Resolve<TForm>() where TForm : DummyForm
        {
            IDisposable disp = windsor.BeginScope();
            TForm form = windsor.Resolve<TForm>();
            dict.Add(form.GetHashCode(), disp);
            return form;
        }

        internal static TForm Resolve<TForm>(object argumentsAsAnonymousType) where TForm : DummyForm
        {
            IDisposable disp = windsor.BeginScope();
            TForm form = windsor.Resolve<TForm>(argumentsAsAnonymousType);
            dict.Add(form.GetHashCode(), disp);
            return form;
        }

        internal static void Release(DummyForm form)
        {
            IDisposable disp = null;
            if (dict.TryGetValue(form.GetHashCode(), out disp))
            {
                disp.Dispose();
            }
            dict.Remove(form.GetHashCode());
            windsor.Release(form);            
        }
    }
}
