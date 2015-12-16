using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to evaluate or N to quit.");
            string stringValue = Console.ReadLine();
            do{

                int result;
                int.TryParse(stringValue, out result);

                string ret = NumberToWords(result);
                Console.WriteLine(string.Format("{0}{1}", ret, "Dollars"));
                Console.WriteLine("Enter a number to evaluate or N to quit.");
                 stringValue = Console.ReadLine();
             } while (stringValue != "No");
        }



        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";
         
            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + "Million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + "Thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "Hundred";
                number %= 100;
            }

            if (number > 0)
            {
              
                var unitsMap = new[] { "zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += unitsMap[number % 10];
                }
            }

            return words;
        }


    }
}
