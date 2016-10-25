using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        static void Main()
        {
            var bmwFactory = new BMWFactory();
            PrintMenu(bmwFactory, "BMW");

            var audiFactory = new AUDIFactory();
            PrintMenu(audiFactory, "AUDI");

             Console.ReadKey();
        }

        public static void PrintMenu(ICarFactory factory, string name)
        {
            Console.WriteLine(string.Format("****** Фабрика {0} ******", name));
            var bode = factory.CreateBody();
            Console.WriteLine(bode.Name + '\n');

            var engine = factory.CreatEngine();
            Console.WriteLine(engine.Name + '\n');

            var vehicle = factory.CreateVehicle();
            Console.WriteLine(vehicle.Name + '\n');
        }
    }
}
