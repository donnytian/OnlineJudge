using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    // https://www.hackerrank.com/challenges/solve-me-first
    public class SolveMeFirst
    {
        public static int solveMeFirst(int a, int b)
        {
            return a + b;
        }

        /*
        static void Main(String[] args)
        {
            int val1 = Convert.ToInt32(Console.ReadLine());
            int val2 = Convert.ToInt32(Console.ReadLine());
            int sum = solveMeFirst(val1, val2);
            Console.WriteLine(sum);
        }
        */
    }

    public class SolveMeFirst_Tests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(4, 6)]
        public void SolveMeFirstTest(int a, int b)
        {
            Assert.Equal(a + b, SolveMeFirst.solveMeFirst(a, b));
        }
    }
}
