using Windows.UI.Xaml;

namespace CiccioGest.Presentation.UwpMenu.Helpers
{
    public class TypeDependencyObject : DependencyObject
    {
        public static readonly DependencyProperty LabelProperty
            = DependencyProperty.Register("Label",
                                          typeof(string),
                                          typeof(TypeDependencyObject),
                                          new PropertyMetadata(null));
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
    }
}
