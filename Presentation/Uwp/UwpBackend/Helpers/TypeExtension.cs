// Copyright (c) 2023 Francesco Crimi
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using Windows.UI.Xaml.Markup;

namespace CiccioGest.Presentation.UwpBackend.Helpers
{
    // This helper class allows to send an Type Object via CommandParameter
    //
    // Usage:
    // CommandParameter="{helpers:Type Type=local:CategoriaView}"
    [MarkupExtensionReturnType(ReturnType = typeof(Type))]
    public sealed class TypeExtension : MarkupExtension
    {
        public Type Type { get; set; }

        /// <inheritdoc/>
        protected override object ProvideValue()
        {
            return Type;
        }
    }
}
