using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F03
{
    public class Age
    {
        public bool CheckIfAgeIsValid(int age)
        {
            if (age < 1 || age >= 100) return false;
            return true;
        }

        public bool CheckIfYearOfBirth(int year)
        {
            if (year < 1900 || year > 2011) return false;
            return true;
        }
    }
}
