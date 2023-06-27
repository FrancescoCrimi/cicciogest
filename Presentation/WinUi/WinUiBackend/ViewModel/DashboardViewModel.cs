// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;

namespace CiccioGest.Presentation.WinUiBackend.ViewModel;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private string _text;

    public DashboardViewModel()
    {
        _text = "Dashboard";
    }

    //public string Text
    //{
    //    get => _text;
    //    set => SetProperty(ref _text, value);
    //}
}

