using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            printer.PutMoney(5);
            printer.SelectDevice(Device.FlashCard);
            printer.SelectDocument("1.txt");
            printer.Print();
            printer.PutMoney(3);
            printer.SelectDevice(Device.WiFiDevice);
            printer.SelectDocument("2.txt");
            printer.Print();
            printer.SelectDocument("3.txt");
            printer.ReturnMoney();
            printer.SelectDocument("3.txt");
            printer.PutMoney(1);
            printer.SelectDevice(Device.WiFiDevice);
            printer.SelectDocument("3.txt");
            printer.ReturnMoney();
            Console.Read();
        }
    }
}
