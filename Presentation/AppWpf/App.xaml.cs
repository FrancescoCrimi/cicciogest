using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace CiccioGest.Presentation.AppWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }

    public enum LoadType
    {
        Nuova = 1,
        Cerca,
        Carica
    }

    public class CaricaFattura
    {
        public LoadType What { get; set; }
        public int IdFattura { get; set; }
    }
    public class CaricaProdotto
    {
        public LoadType What { get; set; }
        public int IdProdotto { get; set; }
    }

    public class AggiornaSelezionaFattureView { }
    public class AggiornaSelezionaProdottoView { }
}
