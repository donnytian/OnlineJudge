using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/simple-array-sum
    public class SimpleArraySum
    {
        public static int simpleArraySum(int n, int[] ar)
        {
            if (n <= 0 || ar == null || ar.Length < n)
            {
                return 0;
            }

            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += ar[i];
            }

            return sum;
        }

        /*
        static void Main(String[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] ar_temp = Console.ReadLine().Split(' ');
            int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
            int result = simpleArraySum(n, ar);
            Console.WriteLine(result);
        }
         */
    }

    public class SimpleArraySum_Tests
    {
        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new[] { 5 })]
        [InlineData(2, new[] { 2, 5 })]
        [InlineData(3, new[] { 3, 5, 7 })]
        [InlineData(4, new[] { 2, 6, -3, -1 })]
        public void SimpleArraySumTest(int n, int[] ar)
        {
            Assert.Equal(ar.Sum(), SimpleArraySum.simpleArraySum(n, ar));
        }
    }
}
