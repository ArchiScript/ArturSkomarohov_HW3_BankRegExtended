﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankRegExtended
{
    public class USD : Currency
    {
        public USD()
        {
            Rate = 1.0m;
            Sign = "USD";
        }
    }
}
