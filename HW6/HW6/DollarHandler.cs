using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public abstract class DollarHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            var str = banknote.Split(' ');
            if (str[1].Equals("долларов"))
            {
                var sum = Convert.ToInt32(str[0]);
                if (sum - Value >= 0)
                {
                    var i = 0;
                    while (sum - Value >= 0)
                    {
                        i++;
                        //Console.WriteLine("{0} {1}", Value, str[1]);
                        sum -= Value;
                    }
                    Console.WriteLine("{0} {1} x{2}", Value, str[1], i);
                    return base.Validate(string.Format("{0} {1}", sum, str[1]));
                }
            }
            return base.Validate(banknote);
        }

        protected abstract int Value { get; }

        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class HundredDollarHandler : DollarHandlerBase
    {
        protected override int Value => 100;

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiftyDollarHandler : DollarHandlerBase
    {
        protected override int Value => 50;

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenDollarHandler : DollarHandlerBase
    {
        protected override int Value => 10;

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
