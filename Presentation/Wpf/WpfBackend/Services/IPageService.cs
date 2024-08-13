﻿// Copyright (c) 2016 - 2024 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;

namespace CiccioGest.Presentation.WpfBackend.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}