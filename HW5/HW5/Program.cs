using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            IChat chat = new Chat();
            Console.WriteLine("Обычный чат");
            chat.SendMessage(new Message { author = "aaa1", destination = "bb2", text = "Hi" });
            chat.SendMessage(new Message { author = "bb2", destination = "aaa1", text = "Hi!=)" });
            var messages = chat.GetMessages();
            foreach (var m in messages)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine();

            IChat chat2 = new Chat();
            chat2 = new DecoratorBuilder(chat2).ChatWithConcealmentUser().Build();
            Console.WriteLine("Чат с шифрованием имен");
            chat2.SendMessage(new Message { author = "aaa1", destination = "bb2", text = "Hi" });
            chat2.SendMessage(new Message { author = "bb2", destination = "aaa1", text = "Hi!=)" });
            var messages2 = chat2.GetMessages();
            foreach (var m in messages2)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine();

            IChat chat3 = new Chat();
            chat3 = new DecoratorBuilder(chat3).ChatWithMessagesEncrypted().Build();
            Console.WriteLine("Чат с кодированием сообщений");
            chat3.SendMessage(new Message { author = "aaa1", destination = "bb2", text = "Hi" });
            chat3.SendMessage(new Message { author = "bb2", destination = "aaa1", text = "Hi!=)" });
            var messages3= chat3.GetMessages();
            foreach (var m in messages3)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine();

            IChat chat4 = new Chat();
            chat4 = new DecoratorBuilder(chat4).ChatWithMessagesEncrypted().ChatWithConcealmentUser().Build();
            Console.WriteLine("Чат с шифрованием имен и кодированием сообщений");
            chat4.SendMessage(new Message { author = "aaa1", destination = "bb2", text = "Hi" });
            chat4.SendMessage(new Message { author = "bb2", destination = "aaa1", text = "Hi!=)" });
            var messages4 = chat4.GetMessages();
            foreach (var m in messages4)
            {
                Console.WriteLine(m.ToString());
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
