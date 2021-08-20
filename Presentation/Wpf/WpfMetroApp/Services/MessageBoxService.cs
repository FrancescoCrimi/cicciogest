using CiccioGest.Presentation.WpfBackend.Services;
using System.Windows;

namespace CiccioGest.Presentation.WpfMetroApp.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void Show(string messageBoxText)
        {
            MessageBox.Show(messageBoxText);
        }
    }
}
