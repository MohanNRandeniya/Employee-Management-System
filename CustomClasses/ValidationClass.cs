using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeM
{
    public class ValidationClass
    {
        public static bool checkEmail(String email)
        {
            bool isValid = false;
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(r.IsMatch(email))
            {
                return isValid = true;
            }

            return isValid;
        }

        public static bool checkTele(String teleNo)
        {
            bool isValid = false;
            Regex r = new Regex(@"(?<!\d)\d{10}(?!\d)");
            if (r.IsMatch(teleNo))
            {
                return isValid = true;
            }

            return isValid;
        }

        public static bool checkFname(String firstname)
        {
            bool isValid = false;
            Regex r = new Regex(@"^[A-Z][a-zA-Z]*$");
            if(r.IsMatch(firstname))
            {
                return isValid = true;
            }

            return isValid;
        }

        public static bool checkLname(String lastname)
        {
            bool isValid = false;
            Regex r = new Regex(@"^[A-Z][a-zA-Z]*$");
            if (r.IsMatch(lastname))
            {
                return isValid = true;
            }

            return isValid;
        }


        public static bool checkNIC(String nic)
        {
            bool isValid = false;
            Regex r = new Regex(@"/^[0-9]{9}[vVxX]$/");
            if (r.IsMatch(nic))
            {
                return isValid = true;
            }

            return isValid;

        }
        

    }
}
