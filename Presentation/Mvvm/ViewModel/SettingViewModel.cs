// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CiccioGest.Presentation.Mvvm.ViewModel
{
    public sealed partial class SettingViewModel : ObservableObject, IViewModel, IDisposable
    {
        [ObservableProperty]
        private string _title;

        public SettingViewModel()
        {
            Title = "Setting View";
        }

        public void Initialize(object? parameter)
        {
        }

        private void LoadSampleData()
        {

        }

        private void VerifyDb()
        {

        }

        private void WriteDb()
        {

        }

        private void WriteConf()
        {

        }


        public void Dispose()
        {
        }
    }
}
