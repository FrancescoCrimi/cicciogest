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
    private string _title;

    public DashboardViewModel()
    {
        Title = "Dashboard";
    }
}

