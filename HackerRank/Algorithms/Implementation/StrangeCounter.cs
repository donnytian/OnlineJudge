using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Implementation
{
    //https://www.hackerrank.com/challenges/strange-code/problem
    public class StrangeCounter
    {
        public static long Resolve(long t)
        {
            var timer = Stopwatch.StartNew();
            const int seed = 3;
            long time = seed;
            // [seed, 2 * seed, 2^2 * seed, 2^3 * seed...]

            while (time < t)
            {
                time = time * 2 + seed;
            }

            //Debug.WriteLine(timer.ElapsedMilliseconds);
            Console.WriteLine(timer.ElapsedMilliseconds);
            return time - t + 1;
        }

        /*
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
        }
        */
    }

    public class StrangeCounter_Tests
    {
        [Theory]
        [InlineData(4, 6)]
        [InlineData(1000000000000, 649267441662)]
        public void StrangeCounter_Test(long t, long value)
        {
            Assert.Equal(value, StrangeCounter.Resolve(t));
        }
    }
}
