using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CiccioGest.Presentation.WpfApp
{
    public class ViewPresenter : ContentPresenter
    {
        private FrameworkElement? _currentView;

        //protected override void OnContentChanged(object oldContent, object newContent)
        //{
        //    // 1. Scollega il DataContext dalla view precedente
        //    if (_currentView != null)
        //        _currentView.DataContext = null;

        //    base.OnContentChanged(oldContent, newContent);

        //    // 2. Crea la nuova view dal template
        //    if (newContent != null)
        //    {
        //        ContentTemplate = new DataTemplate(() =>
        //        {
        //            var view = (FrameworkElement)Activator.CreateInstance(
        //                ViewLocator.ResolveViewType(newContent.GetType())
        //            )!;
        //            view.DataContext = newContent;
        //            _currentView = view;
        //            return view;
        //        });
        //    }
        //}
    }

}
