using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public enum Device
    {
        FlashCard,
        WiFiDevice
    }
    public class Printer
    {
        public IState State { get; set; }
        public int Money;
        public Device Device;
        public string Document;
        public int Cost = 2;

        public Printer()
        {
            State = new InitState();
        }

        public void PutMoney(int money)
        {
            State.PutMoney(this, money);
        }

        public void SelectDevice(Device device)
        {
            State.SelectDevice(this, device);
        }

        public void SelectDocument(string documentName)
        {
            State.SelectDocument(this, documentName);
        }

        public void Print()
        {
            State.Print(this);
        }

        public void ReturnMoney()
        {
            State.ReturnMoney(this);
        }

    }
}
