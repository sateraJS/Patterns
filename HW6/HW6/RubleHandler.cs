using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public abstract class RubleHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            var str = banknote.Split(' ');
            if (str[1].Equals("рублей"))
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

        protected RubleHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }

    public class FiveHundredRubleHandler : RubleHandlerBase
    {
        protected override int Value => 500;

        public FiveHundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class HundredRubleHandler : RubleHandlerBase
    {
        protected override int Value => 100;

        public HundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiftyRubleHandler : RubleHandlerBase
    {
        protected override int Value => 50;

        public FiftyRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
   
}

