using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual bool Validate(string banknote)
        {
            var str = banknote.Split(' ');
            if (_nextHandler == null && Convert.ToInt32(str[0]) != 0)
            {
                Console.WriteLine("Не валидная сумма {0}", banknote);
            }       
            return _nextHandler != null && _nextHandler.Validate(banknote);
        }

    }
}
