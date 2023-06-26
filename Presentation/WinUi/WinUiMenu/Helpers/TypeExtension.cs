using Microsoft.UI.Xaml.Markup;
using System;

namespace CiccioGest.Presentation.WinUiMenu.Helpers
{
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
