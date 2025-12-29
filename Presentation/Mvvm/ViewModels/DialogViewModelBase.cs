// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.Mvvm.ViewModels
{
    public abstract class DialogViewModelBase<TResult> : ViewModelBase
    {
        public event EventHandler<TResult>? CloseDialogEvent;
        protected void CloseDialog(TResult result)
        {
            CloseDialogEvent?.Invoke(this, result);
        }
    }
}
