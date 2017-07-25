using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/a-very-big-sum
    public class VeryBigSum
    {
        public static long aVeryBigSum(int n, long[] ar)
        {
            // Complete this function
            long sum = 0;

            if (n <= 0 || ar == null || ar.Length < n)
            {
                return sum;
            }

            for (var i = 0; i < n; i++)
            {
                sum += ar[i];
            }

            return sum;
        }

        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            long[] ar = Array.ConvertAll(ar_temp, Int64.Parse);
            long result = aVeryBigSum(n, ar);
            Console.WriteLine(result);
        }
        */
    }
}
