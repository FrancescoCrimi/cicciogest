// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.Mvvm.Services
{
    public interface IPageService
    {
        Type GetPageType(Type viewModelType);
    }
}