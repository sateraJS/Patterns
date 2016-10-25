using System;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email().Create().To("qqqq@ryty.ur").Body("Привет").Build();
            print(email);
            Email email2 = new Email().Create().To("qqqq@ryty.ur").Body("Привет").CC("cwdcwty@ywedvw.ee").Build();
            print(email2);
            Email email3 = new Email().Create().To("qqqq@ryty.ur").Body("Привет").CC("cwdcwty@ywedvw.ee").Subject("123").Build();
            print(email3);
            //Console.Read();
        }
        static void print(Email email)
        {
            Console.WriteLine(email.ToString());
            Console.WriteLine();
        }
    }
}
