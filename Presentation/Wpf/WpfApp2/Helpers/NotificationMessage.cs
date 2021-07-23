using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiccioGest.Presentation.WpfApp2.Helpers
{
    public class MessageBase
    {
        public MessageBase() { }

        public MessageBase(object sender)
        {
            Sender = sender;
        }

        public MessageBase(object sender, object target)
            : this(sender)
        {
            Target = target;
        }

        public object Sender { get; protected set; }

        public object Target { get; protected set; }
    }

    public class GenericMessage<T> : MessageBase
    {
        public GenericMessage(T content)
        {
            Content = content;
        }

        public GenericMessage(object sender, T content)
            : base(sender)
        {
            Content = content;
        }

        public GenericMessage(object sender, object target, T content)
            : base(sender, target)
        {
            Content = content;
        }

        public T Content { get; protected set; }
    }

    public class NotificationMessage<T> : GenericMessage<T>
    {
        public NotificationMessage(T content, string notification)
            : base(content)
        {
            Notification = notification;
        }

        public NotificationMessage(object sender, T content, string notification)
            : base(sender, content)
        {
            Notification = notification;
        }

        public NotificationMessage(object sender, object target, T content, string notification)
            : base(sender, target, content)
        {
            Notification = notification;
        }

        public string Notification { get; private set; }
    }
}
