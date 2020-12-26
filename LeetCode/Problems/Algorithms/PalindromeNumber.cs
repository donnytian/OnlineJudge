using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/palindrome-number/
    public class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            if (x < 10)
            {
                return true;
            }

            const int maxDivisor = 1000000000;
            const int minDivisor = 10;
            var leftDivisor = maxDivisor;
            var rightDivisor = minDivisor;

            while (true)
            {
                var result = x / leftDivisor;
                if (result > 0)
                {
                    break;
                }

                leftDivisor /= 10;
            }

            var tempLeft = x;
            var tempRight = x;
            while (leftDivisor >= rightDivisor)
            {
                var left = tempLeft / leftDivisor;
                var right = tempRight % 10;
                if (left != right)
                {
                    return false;
                }

                tempLeft %= leftDivisor;
                leftDivisor /= 10;

                rightDivisor *= 10;
                tempRight /= 10;
            }

            return true;
        }
    }

    public class PalindromeNumberTests
    {
        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(-101, false)]
        [InlineData(1001, true)]
        public void StringToInteger(int x, bool expected)
        {
            var result = new PalindromeNumber().IsPalindrome(x);

            Assert.Equal(expected, result);
        }
    }
}
