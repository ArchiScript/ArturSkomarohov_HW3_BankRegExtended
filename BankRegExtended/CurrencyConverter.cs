using System;
using System.Collections.Generic;
using System.Text;

namespace BankRegExtended
{
    public class CurrencyConverter
    {

        decimal calc;
        public decimal ConvertCur(decimal ammount, Currency convertFrom, Currency convertTo)
        {
            calc = 0;
            if (convertFrom.Sign == "USD")
            {
                calc = ammount * convertFrom.Rate;
            }
            else if (convertFrom.Sign != "USD" && convertTo.Sign != "USD")
            {
                calc = ammount / convertFrom.Rate * convertTo.Rate;
            }
            else
            {
                calc = ammount / convertFrom.Rate;
            }

            return Math.Round(calc,2);
        }
    }
}
