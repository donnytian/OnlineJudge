using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/diagonal-difference
    public class DiagonalDifference
    {
        public static int resolve(int[][] a)
        {
            var sum1 = 0;
            var sum2 = 0;

            if (a == null || a.Length <= 1)
            {
                return 0;
            }

            for (var i = 0; i < a.Length; i++)
            {
                sum1 += a[i][i];
                sum2 += a[i][a.Length - i - 1];
            }

            return sum1 > sum2 ? sum1 - sum2 : sum2 - sum1;
        }

        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] a = new int[n][];
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }
        }
        */
    }
}
