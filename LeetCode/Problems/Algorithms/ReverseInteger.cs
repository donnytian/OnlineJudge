using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/reverse-integer
    public class ReverseInteger
    {
        public static int Reverse(int x)
        {
            var negative = x < 0;

            if (negative)
            {
                x = -x;
            }

            var s = x.ToString();
            s = new string(s.Reverse().ToArray());

            long l = 0;
            long.TryParse(s, out l);

            if (l > int.MaxValue || l < int.MinValue)
            {
                l = 0;
            }

            return negative ? (int) -l : (int) l;
        }
    }

    public class ReverseInteger_Tests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 1)]
        [InlineData(321, 123)]
        [InlineData(-123, -321)]
        [InlineData(1000000003, 0)] // overflow
        public void ReverseInteger_Test(int x, int expected)
        {
            Assert.Equal(expected, ReverseInteger.Reverse(x));
        }
    }
}
