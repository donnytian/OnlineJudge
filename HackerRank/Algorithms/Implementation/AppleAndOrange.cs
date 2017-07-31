using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Implementation
{
    //https://www.hackerrank.com/challenges/apple-and-orange/problem
    public class AppleAndOrange
    {
        // a < s < t < b
        public static int[] resolve(int s, int t, int a, int b, int[] apple, int[] orange)
        {
            var m = 0;
            var n = 0;

            var diff = s - a;
            foreach (var i in apple)
            {
                if (i >= s - a && i <= t - a)
                {
                    m++;
                }
            }

            foreach (var i in orange)
            {
                if (i >= s - b && i <= t - b)
                {
                    n++;
                }
            }

            return new[] { m, n };
        }

        /*
        static void Main(String[] args)
        {
            string[] tokens_s = Console.ReadLine().Split(' ');
            int s = Convert.ToInt32(tokens_s[0]);
            int t = Convert.ToInt32(tokens_s[1]);
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] apple_temp = Console.ReadLine().Split(' ');
            int[] apple = Array.ConvertAll(apple_temp, Int32.Parse);
            string[] orange_temp = Console.ReadLine().Split(' ');
            int[] orange = Array.ConvertAll(orange_temp, Int32.Parse);
        }
        */
    }
}
