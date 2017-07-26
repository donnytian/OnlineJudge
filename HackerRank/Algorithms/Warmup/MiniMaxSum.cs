using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/mini-max-sum/problem
    public class MiniMaxSum
    {
        public static long[] Resolve(int[] arr)
        {
            var min = 0L;
            var max = 0L;

            if (arr == null || arr.Length != 5)
            {
                return new[] { min, max };
            }

            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                }
            }

            for (var i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    Swap(arr, i, i - 1);
                }
            }

            // Converts to long then perform sum to avoid overflow.
            min = (long) arr[0] + arr[1] + arr[2] + arr[3];
            max = (long) arr[1] + arr[2] + arr[3] + arr[4];

            return new[] { min, max };
        }

        private static void Swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        /*
        static void Main(String[] args)
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
        }
        */
    }

    public class MinMaxSum_Tests
    {
        [Theory]
        [InlineData(new[]{ 256741038, 623958417, 467905213, 714532089, 938071625 }, new[]{ 2063136757L, 2744467344 })]
        public void MinMaxSum_Test(int[] arr, long[] expected)
        {
            var result = MiniMaxSum.Resolve(arr);

            Assert.Equal(expected[0], result[0]);
            Assert.Equal(expected[1], result[1]);
        }
    }
}
