using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    //https://www.hackerrank.com/challenges/absolute-permutation/problem
    public class AbsolutePermutation
    {
        public static int[] Resolve(int n, int k)
        {
            if (n <= 0 
                || k < 0 
                || k >= n 
                || (k != 0 && n % (2 * k)  != 0))
            {
                return new[] { -1 };
            }

            if (k == 0)
            {
                return Enumerable.Range(1, n).ToArray();
            }

            var plus = true;
            var result = new int[n];

            for (int i = 1, span = k; i <= n; i++, span--)
            {
                if (span == 0) // Resets span.
                {
                    span = k;
                    plus = !plus;
                }

                var e = i + (plus ? k : -k);
                result[i - 1] = e;
            }

            return result;
        }

        /*
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                Console.WriteLine(string.Join(" ", Resolve(n, k)));
            }
        }
        */
    }

    public class AbsolutePermutation_Tests
    {
        [Theory]
        [InlineData(2, 1, new[] { 2, 1 })]
        [InlineData(3, 0, new[] { 1, 2, 3 })]
        [InlineData(4, 2, new[] { 3, 4, 1, 2 })]
        [InlineData(66, 60, new[] { -1 })]
        [InlineData(95, 22, new[] { -1 })]
        public void AbsolutePermutation_Test(int n, int k, int[] expected)
        {
            var result = AbsolutePermutation.Resolve(n, k);

            for (var i = 0; i < result.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}
