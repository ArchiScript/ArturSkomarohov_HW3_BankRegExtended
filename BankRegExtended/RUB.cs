using System;
using System.Collections.Generic;
using System.Text;

namespace BankRegExtended
{
    public class RUB : Currency
    {
        public RUB()
        {
            Rate = 16.3m;
            Sign = "RUB";
        }
    }
}
