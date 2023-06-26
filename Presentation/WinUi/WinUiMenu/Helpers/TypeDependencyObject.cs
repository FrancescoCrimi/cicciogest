using Microsoft.UI.Xaml;
using System;

namespace CiccioGest.Presentation.WinUiMenu.Helpers
{
    public class TypeDependencyObject : DependencyObject
    {
        public static readonly DependencyProperty LabelProperty
            = DependencyProperty.Register("Label",
                                          typeof(Type),
                                          typeof(TypeDependencyObject),
                                          new PropertyMetadata(null));
        public Type Label
        {
            get { return (Type)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
    }
}
