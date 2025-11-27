using CiccioGest.Application;
using CiccioGest.Domain.Magazzino;
using CiccioGest.Presentation.Mvvm.Services;
using CiccioGest.Presentation.Mvvm.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WpfApp.Test
{


    //public sealed partial class ArticoliListViewModel : ObservableObject
    //{
    //    private readonly INavigationService _navigation;
    //    private readonly IMagazzinoService _magazzinoService; // CRUD/filter
    //    //private readonly ArticoliListOptions _options;

    //    private readonly TaskCompletionSource<int?>? _tcsResult; // solo in selection mode

    //    // Stato
    //    [ObservableProperty] private bool _isBusy;
    //    [ObservableProperty] private string? _statusMessage;

    //    [ObservableProperty]
    //    [NotifyCanExecuteChangedFor(nameof(ConfermaSelezioneCommand))]
    //    private Articolo? _articoloSelezionato;

    //    [ObservableProperty] private string? _filtro;

    //    // Dati
    //    public ObservableCollection<Articolo> Articoli { get; } = new();
    //    public ICollectionView ViewArticoli { get; }

    //    public ArticoliListViewModel(INavigationService navigation,
    //                                 IMagazzinoService magazzinoService,
    //                                 ArticoliListOptions options)
    //    {
    //        _navigation = navigation;
    //        _magazzinoService = magazzinoService;
    //        //_options = options;

    //        // Risultato (solo selection mode)
    //        if (options.SelectionMode) _tcsResult = new TaskCompletionSource<int?>();

    //        // CollectionView per filtro
    //        ViewArticoli = System.Windows.Data.CollectionViewSource.GetDefaultView(Articoli);
    //        ViewArticoli.Filter = FilterArticoli;

    //        // Caricamento iniziale
    //        _ = LoadAsync();
    //    }

    //    public Task<int?> ShowForResultAsync() => _tcsResult?.Task ?? Task.FromResult<int?>(null);

    //    private bool FilterArticoli(object obj)
    //    {
    //        if (obj is not Articolo a) return false;
    //        if (string.IsNullOrWhiteSpace(Filtro)) return true;
    //        var f = Filtro.Trim();
    //        return (a.Nome?.Contains(f, System.StringComparison.OrdinalIgnoreCase) ?? false)
    //            || (a.Descrizione?.Contains(f, System.StringComparison.OrdinalIgnoreCase) ?? false);
    //    }

    //    [RelayCommand]
    //    private void AggiornaFiltro()
    //    {
    //        ViewArticoli.Refresh();
    //    }

    //    partial void OnFiltroChanged(string? value)
    //    {
    //        AggiornaFiltro();
    //    }

    //    [RelayCommand]
    //    private async Task LoadAsync()
    //    {
    //        try
    //        {
    //            IsBusy = true;
    //            Articoli.Clear();
    //            foreach (var a in await _magazzinoService.GetArticoli())
    //                Articoli.Add(a);
    //            StatusMessage = $"Caricati {Articoli.Count} articoli.";
    //            ViewArticoli.Refresh();
    //        }
    //        catch (System.Exception ex)
    //        {
    //            StatusMessage = "Errore caricamento: " + ex.Message;
    //        }
    //        finally
    //        {
    //            IsBusy = false;
    //        }
    //    }

    //    // Conferma selezione (solo in selection mode)
    //    [RelayCommand(CanExecute = nameof(CanConfermaSelezione))]
    //    private void ConfermaSelezione()
    //    {
    //        if (!_options.SelectionMode) return; // non rilevante in nav mode
    //        _tcsResult?.TrySetResult(ArticoloSelezionato?.Id);
    //        StatusMessage = ArticoloSelezionato is null
    //            ? "Nessun articolo selezionato."
    //            : $"Selezionato articolo ID={ArticoloSelezionato.Id}.";
    //    }
    //    private bool CanConfermaSelezione() => ArticoloSelezionato is not null;

    //    // Navigazione al dettaglio (nav mode)
    //    [RelayCommand]
    //    private async Task ApriDettaglioAsync()
    //    {
    //        if (ArticoloSelezionato is null) return;

    //        // Preferisci hook custom se presente
    //        if (_options.NavigateToDetailAsync is not null)
    //        {
    //            await _options.NavigateToDetailAsync(ArticoloSelezionato);
    //            return;
    //        }

    //        // Altrimenti usa il tuo navigation service standard
    //        await _navigation.NavigateForResult<ArticoliViewModel, bool?>(ArticoloSelezionato);
    //    }

    //    // Back/Close
    //    [RelayCommand]
    //    private void Chiudi()
    //    {
    //        // In selection mode: rimanda indietro null se non confermato
    //        _tcsResult?.TrySetResult(null);
    //        // In nav mode: usa la tua strategia (es. Navigate<PreviousVM>)
    //        _navigation.Navigate<DashboardViewModel>();
    //    }
    //}

    // DTO di esempio
    //public sealed class ArticoloDto
    //{
    //    public int Id { get; set; }
    //    public string? Codice { get; set; }
    //    public string? Nome { get; set; }
    //}
}