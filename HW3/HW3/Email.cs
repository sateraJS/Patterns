using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class Email
    {
        #region Email
        private string _to;
        private string _body;
        private string _subject;
        //public Email() { }
        private Email To(string to)
        {
            this._to = string.Format("Получатели: {0}", to);
            return this;
        }
        private Email Subject(string subject)
        {
            _subject = string.Format("Тема: {0}", subject);
            return this;
        }
        private Email Body(string body)
        {
            _body = string.Format("Сообщение: {0}", body);
            return this;
        }
        private Email CC(string cc)
        {
            _to += string.Format(", {0}", cc);
            return this;
        }
        public string ToString()
        {
            var result = string.Empty;
            result += _to +'\n';
            result += _body + '\n';
            result += _subject;
            return result;
        }

        public IOneEmailBuilder Create()
        {
            return new OneEmailBuilder(new Email());
        }
        #endregion
        //конечное состояние можем выполнить построение или задать дополнительные поля
        #region EmailBuilder
        public class EmailBuilder: IEmailBuilder
        {    
            private readonly Email _email = new Email();
            public EmailBuilder(Email email)    
            {        
                _email = email;    
            }
            public IEmailBuilder CC(string address)
            {
                _email.CC(address);
                return new EmailBuilder(_email);
            }
            public IEmailBuilder Subject(string text)
            {
                _email.Subject(text);
                return new EmailBuilder(_email);
            }
            public Email Build()
            {
                return _email;
            } 
        }
        #endregion
        //первое состояние можем задать только получаетеля
        #region OneEmailBuilder
        public class OneEmailBuilder : IOneEmailBuilder
        {    
            private readonly Email _email;
            public OneEmailBuilder(Email email) 
            {
                _email = email; 
            }
            public ITwoEmailBuilder To(string address)
            {
                _email.To(address);
                return new TwoEmailBuilder(_email);
            }
        }
        #endregion
        //второе состояние можно задать сообщение
        #region TwoEmailBuilder
        public class TwoEmailBuilder : ITwoEmailBuilder
        {
            private readonly Email _email;
            public TwoEmailBuilder(Email email)
            {
                _email = email;
            }
            public IEmailBuilder Body(string text)
            {
                _email.Body(text);
                return new EmailBuilder(_email);
            }
        }
        #endregion
    }
    #region Interfaces
    public interface IEmailBuilder
    {
        IEmailBuilder CC(string address);
        IEmailBuilder Subject(string text);
        Email Build();

    }
    public interface IOneEmailBuilder
    {
        ITwoEmailBuilder To(string address);
    }

    public interface ITwoEmailBuilder
    {
        IEmailBuilder Body(string text);
    }
    #endregion
}
