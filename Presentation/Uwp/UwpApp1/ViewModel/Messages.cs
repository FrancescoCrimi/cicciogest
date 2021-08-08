using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace CiccioGest.Presentation.UwpApp.ViewModel
{
    public class FatturaIdMessage : ValueChangedMessage<int>
    {
        public FatturaIdMessage(int value) : base(value)
        {
        }
    }

    public class DettaglioIdMessage : ValueChangedMessage<int>
    {
        public DettaglioIdMessage(int value) : base(value)
        {
        }
    }

    public class ClienteIdMessage : ValueChangedMessage<int>
    {
        public ClienteIdMessage(int value) : base(value)
        {
        }
    }
}
