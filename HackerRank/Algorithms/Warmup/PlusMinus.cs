using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/plus-minus
    public class PlusMinus
    {
        public static float[] resolve(int[] a)
        {
            var positives = 0f;
            var negatives = 0f;
            var zeros = 0f;

            if (a == null)
            {
                return new float[] { };
            }

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    positives++;
                }
                else if (a[i] < 0)
                {
                    negatives++;
                }
                else
                {
                    zeros++;
                }
            }

            var n = a.Length;
            return new[] { positives / n, negatives / n, zeros / n };
        }

        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            foreach (var f in resolve(arr))
            {
                Console.WriteLine(f);
            }
        }
        */
    }
}
