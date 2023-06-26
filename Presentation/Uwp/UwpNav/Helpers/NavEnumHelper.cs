using CiccioGest.Presentation.UwpBackend.Contracts;
using Windows.UI.Xaml;

namespace CiccioGest.Presentation.UwpNav.Helpers
{
    public class NavEnumHelper
    {
        // This helper class allows to specify the page from an enum named Views on a UIElement
        //
        // Usage in xaml:
        // <winui:NavigationViewItem helpers:NavEnumHelper.NavigateTo="Fatture" />
        // Fatture is enum value
        //
        // Usage in code:
        // NavEnumHelper.SetNavigateTo(UIElement, Views.Fatture);
        public static ViewEnum GetNavigateTo(UIElement item)
        {
            return (ViewEnum)item.GetValue(NavigateToProperty);
        }

        public static void SetNavigateTo(UIElement item, ViewEnum value)
        {
            item.SetValue(NavigateToProperty, value);
        }

        public static readonly DependencyProperty NavigateToProperty =
            DependencyProperty.RegisterAttached("NavigateTo",
                                                typeof(ViewEnum),
                                                typeof(NavEnumHelper),
                                                new PropertyMetadata(null));
    }
}
