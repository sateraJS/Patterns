using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public interface IState
    {
        void PutMoney(Printer printer, int money);
        void SelectDevice(Printer printer, Device device);
        void SelectDocument(Printer printer, string documentName);
        void Print(Printer printer);
        void ReturnMoney(Printer printer);
    }

    public abstract class StateBase : IState
    {
        public abstract void PutMoney(Printer printer, int money);
        public abstract void SelectDevice(Printer printer, Device device);
        public abstract void SelectDocument(Printer printer, string documentName);
        public abstract void Print(Printer printer);
        public abstract void ReturnMoney(Printer printer);
    }

    public class InitState : StateBase
    {
        public override void PutMoney(Printer printer, int money)
        {
            printer.Money += money;
            Console.WriteLine($"Полученно денег: {printer.Money}");
            printer.State = new SelectDeviceState();
        }

        public override void SelectDevice(Printer printer, Device device)
        {
            Console.WriteLine("Не внесены деньги");
        }

        public override void SelectDocument(Printer printer, string documentName)
        {
            Console.WriteLine("Не внесены деньги");
        }

        public override void Print(Printer printer)
        {
            Console.WriteLine("Не внесены деньги");
        }

        public override void ReturnMoney(Printer printer)
        {
            Console.WriteLine("Не внесены деньги");
        }
    }

    public class SelectDeviceState : StateBase
    {
        public override void PutMoney(Printer printer, int money)
        {
            printer.Money += money;
            Console.WriteLine($"Полученно денег: {printer.Money}");
        }

        public override void SelectDevice(Printer printer, Device device)
        {
            printer.Device = device;
            Console.WriteLine($"Выбрано устройство {printer.Device}");
            printer.State = new SelectDocumentState();
        }

        public override void SelectDocument(Printer printer, string documentName)
        {
            Console.WriteLine("Не выбрано устройство");
        }

        public override void Print(Printer printer)
        {
            Console.WriteLine("Не выбрано устройство");
        }

        public override void ReturnMoney(Printer printer)
        {
            Console.WriteLine($"Возвращены деньги {printer.Money}");
            printer.Money = 0;
            printer.State = new InitState();
        }
    }

    public class SelectDocumentState : StateBase
    {
        public override void PutMoney(Printer printer, int money)
        {
            printer.Money += money;
            Console.WriteLine($"Полученно денег: {printer.Money}");
        }

        public override void SelectDevice(Printer printer, Device device)
        {
            Console.WriteLine("Устройство уже выбрано");
        }

        public override void SelectDocument(Printer printer, string documentName)
        {
            if (printer.Money < printer.Cost)
            {
                Console.WriteLine($"Недостаточно средств, стоимость печати документа = {printer.Cost}");
            }
            else
            {
                printer.Document = documentName;
                Console.WriteLine($"Выбран документ {printer.Document}");
                printer.State = new PrintState();
            }
        }

        public override void Print(Printer printer)
        {
            Console.WriteLine("Не выбран документ");
        }

        public override void ReturnMoney(Printer printer)
        {
            Console.WriteLine($"Возвращены деньги {printer.Money}");
            printer.Money = 0;
            printer.State = new InitState();
        }
    }

    public class PrintState : StateBase
    {
        public override void PutMoney(Printer printer, int money)
        {
            printer.Money += money;
            Console.WriteLine($"Полученно денег: {printer.Money}");
        }

        public override void SelectDevice(Printer printer, Device device)
        {
            Console.WriteLine("Устройство уже выбрано");
        }

        public override void SelectDocument(Printer printer, string documentName)
        {
            Console.WriteLine("Документ уже выбран");
        }

        public override void Print(Printer printer)
        {
            Console.WriteLine($"Печатается документ: {printer.Document}");
            printer.Money -= printer.Cost;
            printer.State = new ReturnMoneyState();
        }

        public override void ReturnMoney(Printer printer)
        {
            Console.WriteLine($"Возвращены деньги {printer.Money}");
            printer.Money = 0;
            printer.State = new InitState();
        }
    }

    public class ReturnMoneyState : StateBase
    {
        public override void PutMoney(Printer printer, int money)
        {
            printer.Money += money;
            Console.WriteLine($"Полученно денег: {printer.Money}");
        }

        public override void SelectDevice(Printer printer, Device device)
        {
            Console.WriteLine("Устройство уже выбрано");
        }

        public override void SelectDocument(Printer printer, string documentName)
        {
            printer.State = new SelectDocumentState();
            printer.State.SelectDocument(printer, documentName);
        }

        public override void Print(Printer printer)
        {
            Console.WriteLine("Документ уже напечатан");
        }

        public override void ReturnMoney(Printer printer)
        {
            Console.WriteLine($"Возвращены деньги {printer.Money}");
            printer.Money = 0;
            printer.State = new InitState();
        }
    }
}
