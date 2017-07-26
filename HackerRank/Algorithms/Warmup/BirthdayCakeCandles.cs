using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/birthday-cake-candles/problem
    public class BirthdayCakeCandles
    {
        public static int birthdayCakeCandles(int n, int[] ar)
        {
            // Complete this function
            if (ar == null || ar.Length == 0)
            {
                return 0;
            }

            n = ar.Length;
            var max = 0;
            var count = 0;

            for (var i = 0; i < n; i++)
            {
                if (ar[i] > max)
                {
                    max = ar[i];
                    count = 1;
                }
                else if (ar[i] == max)
                {
                    count++;
                }
            }

            return count;
        }

        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);
            int result = birthdayCakeCandles(n, ar);
            Console.WriteLine(result);
        }
        */
    }
}
