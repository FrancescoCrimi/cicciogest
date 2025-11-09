// Copyright (c) 2016 - 2025 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace CiccioGest.Presentation.WinUiMenu.Helpers
{
    public static class FrameExtensions
    {
        public static object? GetDataContext(this Frame frame)
        {
            if (frame.Content is FrameworkElement frameworkElement)
            {
                return frameworkElement.DataContext;
            }
            return null;
        }
    }
}
