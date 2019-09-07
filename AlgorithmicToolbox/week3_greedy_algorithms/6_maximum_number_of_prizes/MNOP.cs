using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumNumberOfPrizes
{
    class Program
    {
        static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            var result = CountPrizes(number, 1);
            Console.WriteLine(result.Count());       
            var prizes = string.Empty;
            foreach(var prize in result)
            {
                Console.Write(prize);
                Console.Write(' ');
            }   
        }

        static List<long> CountPrizes(long remainingCandys, long counter)
        {
            var result = new List<long>();
            var newPrize = counter;
            while(remainingCandys - counter >= counter + 1)
            {
                newPrize = counter;
                result.Add(newPrize);
                remainingCandys -= newPrize;
                counter++;
            }
            if (remainingCandys != 0)
            {
                result.Add(remainingCandys);
            }
            return result;
        }

        //Stackoverflow for input 100000000
        static List<long> CountPrizes2(long remainingCandys, long counter)
        {
            var result = new List<long>();
            if (remainingCandys == 0)
            {
                return result;
            }
            var newPrize = counter;
            if (remainingCandys - newPrize < counter + 1)
            {
                newPrize = remainingCandys;
                result.Add(newPrize);
            }
            else
            {
                result.Add(newPrize);
                result.AddRange(CountPrizes(remainingCandys - newPrize, counter + 1));
            }
            return result;
        }
    }
}