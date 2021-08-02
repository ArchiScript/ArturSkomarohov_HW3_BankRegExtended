using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;


namespace BankRegExtended
{
    public class Client 
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PassNumber { get; set; }
        //public Account AccData;
        //public decimal AccSum { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Client))
            {
                return false;
            }
            Client result = (Client)obj;
            return result.Name == Name &&
                result.DateOfBirth == DateOfBirth &&
                result.PassNumber == PassNumber;
                //&&
                //result.AccData == AccData;
                //&&
                //result.AccSum == AccSum;
        }
        public static bool operator ==(Client first, Client second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(Client first, Client second)
        {
            return !first.Equals(second);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + DateOfBirth.GetHashCode() +
                PassNumber.GetHashCode();
                //+ AccData.GetHashCode();
                //+
               // AccSum.GetHashCode();
        }

    }
}
