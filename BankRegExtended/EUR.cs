using System;
using System.Collections.Generic;
using System.Text;

namespace BankRegExtended
{
   public class EUR:Currency
    {
        public EUR()
        {
            Rate = 0.84m;
            Sign = "EUR";
        }
    }
}
