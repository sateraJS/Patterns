using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancomat = new Bancomat();
            Console.WriteLine("***** 160 рублей ******");
            bancomat.Validate("160 рублей");
            Console.WriteLine();
            Console.WriteLine("***** 1050 рублей ******");
            bancomat.Validate("1050 рублей");
            Console.WriteLine();
            Console.WriteLine("***** 550 долларов ******");
            bancomat.Validate("550 долларов");
            Console.WriteLine();
            Console.WriteLine("***** 1501 долларов ******");
            bancomat.Validate("1501 долларов");
            Console.WriteLine();
            Console.Read();
        }
    }
}
