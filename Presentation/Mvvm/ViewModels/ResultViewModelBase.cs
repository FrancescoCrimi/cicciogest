// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using CiccioGest.Presentation.Mvvm.Services;
using System;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public abstract class ResultViewModelBase<TResult> : ViewModelBase
    {
        public Action<DialogResult<TResult>>? CloseRequested { get; set; }

        protected void Close(TResult result)
        {
            CloseRequested?.Invoke(new DialogResult<TResult>(DialogResultType.Ok, result));
        }

        protected void Cancel()
        {
            CloseRequested?.Invoke(new DialogResult<TResult>(DialogResultType.Cancel, default!));
        }
    }
}
