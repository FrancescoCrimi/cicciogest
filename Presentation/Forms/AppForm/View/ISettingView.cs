// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.AppForm.View
{
    public interface ISettingView : IView
    {
        event EventHandler VerificaDatabaseRequested;
        event EventHandler CreaDatabaseRequested;
        event EventHandler PopolaDatabaseRequested;
    }
}
