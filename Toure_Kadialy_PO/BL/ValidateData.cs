using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toure_Kadialy_P0.BL
{
    public class ValidateData
    {
        /// <summary>
        /// Valid user input for steing data type
        /// </summary>
        /// <param name="str"></param>
        /// <returns>valid string</returns>
        public static string ValidateString(string str)
        {
            while (str.Length <= 0)
            {
                Console.WriteLine("Invalid string enter valid string");
                str = Console.ReadLine();
            }
            return str;
        }
        /// <summary>
        /// Validate user input for integer
        /// Ask constantly for valid integer
        /// Untill correct input is not giveen.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>valid integer</returns>
        public static int ValidateInteger(string str)
        {
            int number;
            while (!int.TryParse(str,out number))
            {
                Console.WriteLine("Invalid input enter valid integer");
                str = Console.ReadLine();
            }
            return number;
        }
        public static decimal ValidateDecimal(string str)
        {
            decimal number;
            while (!decimal.TryParse(str, out number))
            {
                Console.WriteLine("Invalid input enter valid decimal number");
                str = Console.ReadLine();
            }
            return number;
        }

    }
}
