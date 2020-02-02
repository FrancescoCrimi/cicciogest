namespace CiccioGest.Presentation.Gtk.AppGtk.Contracts.Presenter
{
    public interface IFatturaPresenter : IPresenter
    {
        void AggiungiDettaglio();
        void AprFattura();
        void EliminaFattura();
        void NuovaFattura();
        void NuovoDattaglio();
        void RimuoviDettaglio();
        void SalvaFattura();
    }
}
