using CommunityToolkit.Mvvm.Messaging.Messages;

namespace CiccioGest.Presentation.WpfApp.ViewModel
{
    public class FatturaIdMessage : ValueChangedMessage<int>
    {
        public FatturaIdMessage(int value) : base(value)
        {
        }
    }

    public class ArticoloIdMessage : ValueChangedMessage<int>
    {
        public ArticoloIdMessage(int value) : base(value)
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
