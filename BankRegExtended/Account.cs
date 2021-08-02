using System;
using System.Collections.Generic;
using System.Text;

namespace BankRegExtended
{
   public class Account
    {
        public Currency CurrencyType { get; set; }
        public decimal Ammount { get; set; }
        public ulong AccNumber { get; set; }
    }
}
