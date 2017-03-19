using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using CiccioGest.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CiccioGest.Presentation.WinForm
{
    static class ViewResolver
    {
        private static IWindsorContainer windsor;
        private static Dictionary<Form, IDisposable> dict;

        static ViewResolver()
        {
            Container container = new Container(UI.Form);
            container.Install(new Installer());
            windsor = container.Windsor;
            dict = new Dictionary<Form, IDisposable>();
        }

        internal static TForm Resolve<TForm>() where TForm : Form
        {
            IDisposable disp = windsor.BeginScope();
            TForm form = windsor.Resolve<TForm>();
            form.FormClosed += view_FormClosed;
            dict.Add(form, disp);
            return form;
        }

        internal static TForm Resolve<TForm>(object argumentsAsAnonymousType) where TForm : Form
        {
            IDisposable disp = windsor.BeginScope();
            TForm form = windsor.Resolve<TForm>(argumentsAsAnonymousType);
            form.FormClosed += view_FormClosed;
            dict.Add(form, disp);
            return form;
        }

        private static void view_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form view = sender as Form;
            if (view != null)
            {
                IDisposable disp = null;
                if (dict.TryGetValue(view, out disp))
                {
                    dict.Remove(view);
                    windsor.Release(view);
                    disp.Dispose();
                }
            }
        }
    }
}
