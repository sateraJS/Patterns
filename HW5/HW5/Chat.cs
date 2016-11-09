using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    public interface IChat
    {
        void SendMessage(Message m);
        List<Message> GetMessages();
    }
    public class Chat : IChat
    {
        private List<Message> messages;
        public Chat()
        {
            this.messages = new List<Message>();
        }
        public void SendMessage(Message m)
        {
            messages.Add(m);
        }
        public List<Message> GetMessages()
        {
            return messages;
        }
    }
    public class ChatDecorator : IChat
    {
        protected readonly IChat Decorate;
        protected ChatDecorator(IChat c)
        {
            this.Decorate = c;
        }
        public virtual void SendMessage(Message m)
        {
            Decorate.SendMessage(m);
        }
        public virtual List<Message> GetMessages()
        {
            var result = Decorate.GetMessages();
            return result;
        }
    }
    class ChatWithConcealmentUser: ChatDecorator
    {
        public ChatWithConcealmentUser(IChat c)  : base (c)
        {}

        public override void SendMessage(Message m)
        {
            m.author = m.author.GetHashCode().ToString();
            m.destination = m.destination.GetHashCode().ToString();
            base.SendMessage(m);
        }
        public override  List<Message> GetMessages()
        {
            return base.GetMessages();
        }
    }
    class ChatWithMessagesEncrypted : ChatDecorator
    {
        private readonly List<Message> messages;
        public ChatWithMessagesEncrypted(IChat c): base(c)
        {}

        public override void SendMessage(Message m)
        {
            m.text = "Зашифрован: " + m.text;
            base.SendMessage(m);
        }
        public override List<Message> GetMessages()
        {
            var getMessages = base.GetMessages();
            for (int i = 0; i < getMessages.Count; i++ )
            {
                var text = getMessages[i].text.Substring(12);
                getMessages[i].text = "Расшифровано: " + text;
            }
            return getMessages;
        }
    }
    public class DecoratorBuilder
    {
        private IChat _chat;

        public DecoratorBuilder(IChat c)
        {
            _chat = c;
        }

        public DecoratorBuilder ChatWithConcealmentUser()
        {
            _chat = new ChatWithConcealmentUser(_chat);
            return this;
        }

        public DecoratorBuilder ChatWithMessagesEncrypted()
        {
            _chat = new ChatWithMessagesEncrypted(_chat);
            return this;
        }

        public IChat Build()
        {
            return _chat;
        }

    }
}
