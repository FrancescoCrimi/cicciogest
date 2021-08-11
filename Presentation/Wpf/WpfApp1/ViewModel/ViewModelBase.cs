using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class ViewModelBase : ObservableRecipient
    {
        public ViewModelBase()
        {
        }

        public event EventHandler OnRequestClose;


        protected void CloseWindow()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }
    }
}
