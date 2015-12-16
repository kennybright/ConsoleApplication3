using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxRangeConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            // read investment days data into array
            int[] investmentDays= new int[args.Length];
            int temp;
            // read and parse only valid console values
            for (int i = 0; i < args.Length; i++)
            {
                if (Int32.TryParse(args[i], out temp))
                {
                    investmentDays[i] = temp;
                }
                else
                {
                    investmentDays[i] = 0;
                }
            }

            Console.WriteLine(String.Format("Enter entering day and exit day separated by comma or 'N' to exit"));
            string inputString = Console.ReadLine();
            // continue processing until user enters N
           
            do
            {
                if (string.Compare(inputString, "N", true) == 0)
                    break;
              
                    string[] days = inputString.Split(' ');
                    int inDay;
                    int exitDay;
                  //  int.TryParse(days[0], out inDay);
                //    int.TryParse(days[1], out outDay);
                    if (int.TryParse(days[0], out inDay) && int.TryParse(days[1], out exitDay))
                    {
                        var s = IndexRange(investmentDays, inDay, exitDay);
                        Console.WriteLine(" Gain/Loss : {0}", s.Sum(x => x));

                    }
                    else
                    {
                        Console.WriteLine("Error, could not parse entering and exit!");
                    }

                    Console.WriteLine(String.Format("Enter entering day and exit day separated by comma or 'N' to exit"));
                    inputString = Console.ReadLine();
               
            } while (inputString != "N");
        }

        /// <summary>
        /// For larger lists, a separate extension method could be more appropriate for performance.
        /// Because Linq (to objects) implementation relies on iterating the list, so for large lists this could be (pointlessly) expensive
        /// Hence, i decide to use extension method
        /// </summary>
        /// <typeparam name="TSource"> array or list</typeparam>
        /// <param name="source">array or list</param>
        /// <param name="fromIndex">entering day</param>
        /// <param name="toIndex">exit day</param>
        /// <returns>range from entering day to exit day</returns>
        public static IEnumerable<TSource> IndexRange<TSource>(this IList<TSource> source, int fromIndex, int toIndex)
        {
            int currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source[currIndex];
                currIndex++;
            }
        }
    }

   
}
