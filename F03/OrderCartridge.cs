using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F03
{
    public class OrderCartridge
    {
        public int HowMuchDiscountWillThisAmountGiveMe(int amount)
        {
            if (amount < 5) return -1;
            if (amount >= 5 && amount<100) return 0;
            if (amount >= 100) return 20;
            return -1;
        }
    }
}
