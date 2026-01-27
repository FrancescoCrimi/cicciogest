// Copyright (c) 2016 - 2026 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiMenu
{
    public class ViewPresenter : ContentControl
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            // 1. Scollega il DataContext dalla view precedente
            if (oldContent != null && oldContent is FrameworkElement frameworkElement)
                frameworkElement.DataContext = null;
        }
    }
}
