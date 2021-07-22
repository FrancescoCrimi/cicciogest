using CiccioGest.Infrastructure.Conf;
using System;

namespace CiccioGest.Presentation.AppForm
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Init();
        }

        private static void Init()
        {
            var conf = CiccioGestConfMgr.GetCurrent();
        }
    }
}
