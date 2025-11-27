using CiccioGest.Domain.Magazzino;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CiccioGest.Presentation.WpfApp.Test
{
        public class CategoriaViewModel : INotifyPropertyChanged
        {
            // Stato UI
            private bool _isBusy;
            private string? _statusMessage;
            private Categoria? _categoriaCorrente;
            private Categoria? _selectedCategoria;

            public ObservableCollection<Categoria> Categorie { get; } = new();

            public Categoria? CategoriaCorrente
            {
                get => _categoriaCorrente;
                set { _categoriaCorrente = value; OnPropertyChanged(); }
            }

            public Categoria? SelectedCategoria
            {
                get => _selectedCategoria;
                set { _selectedCategoria = value; OnPropertyChanged(); }
            }

            public bool IsBusy
            {
                get => _isBusy;
                set { _isBusy = value; OnPropertyChanged(); }
            }

            public string? StatusMessage
            {
                get => _statusMessage;
                set { _statusMessage = value; OnPropertyChanged(); }
            }

            // Comandi
            public ICommand NuovaCategoriaCommand { get; }
            public ICommand SalvaCategoriaCommand { get; }
            public ICommand EliminaCategoriaCommand { get; }

            public CategoriaViewModel()
            {
                NuovaCategoriaCommand = new RelayCommand(NuovaCategoria);
                SalvaCategoriaCommand = new RelayCommand(SalvaCategoria, () => CategoriaCorrente != null);
                EliminaCategoriaCommand = new RelayCommand(EliminaCategoria, () => SelectedCategoria != null);

                // Dummy iniziale
                CategoriaCorrente = new Categoria {  Nome = string.Empty };
            }

            private void NuovaCategoria()
            {
                CategoriaCorrente = new Categoria {  Nome = string.Empty };
                StatusMessage = "Nuova categoria pronta per l'inserimento.";
            }

            private void SalvaCategoria()
            {
                if (CategoriaCorrente == null) return;

                if (CategoriaCorrente.Id == 0)
                {
                    // Simula ID autoincrement
                    //CategoriaCorrente.Id = Categorie.Count + 1;
                    Categorie.Add(CategoriaCorrente);
                    StatusMessage = $"Categoria '{CategoriaCorrente.Nome}' aggiunta.";
                }
                else
                {
                    // Aggiorna categoria esistente
                    var existing = SelectedCategoria;
                    if (existing != null)
                    {
                        existing.Nome = CategoriaCorrente.Nome;
                        StatusMessage = $"Categoria '{existing.Nome}' aggiornata.";
                    }
                }

                // Reset corrente
                CategoriaCorrente = new Categoria {  Nome = string.Empty };
            }

            private void EliminaCategoria()
            {
                if (SelectedCategoria == null) return;
                Categorie.Remove(SelectedCategoria);
                StatusMessage = $"Categoria '{SelectedCategoria.Nome}' eliminata.";
                SelectedCategoria = null;
            }

            // INotifyPropertyChanged
            public event PropertyChangedEventHandler? PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] string? name = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
}
