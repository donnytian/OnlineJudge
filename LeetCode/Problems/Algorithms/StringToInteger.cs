using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/string-to-integer-atoi/
    public class StringToInteger
    {
        public int Convert(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            s = s.TrimStart();
            var index = 0;
            bool? negative = null;
            var result = 0;
            long positiveMaxAbs = int.MaxValue;
            long negativeMaxAbs = (long)int.MaxValue + 1;
            long maxAbs = positiveMaxAbs;

            for (; index < s.Length; index++)
            {
                var c = s[index];

                if (c == '+')
                {
                    if (!negative.HasValue)
                    {
                        negative = false;
                        continue;
                    }

                    break;
                }

                if (c == '-')
                {
                    if (!negative.HasValue)
                    {
                        negative = true;
                        maxAbs = negativeMaxAbs;
                        continue;
                    }

                    break;
                }

                negative ??= false;

                if (!char.IsDigit(c))
                {
                    break;
                }

                var delta = c - '0';
                long temp = (long)result * 10 + delta;

                if (temp > maxAbs)
                {
                    result = negative == true ? int.MinValue : int.MaxValue;
                    return result;
                }

                result = (int)temp;
            }

            if (negative == true)
            {
                result = -result;
            }

            return result;
        }
    }

    public class StringToIntegerTests
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("00000-42a1234", 0)]
        [InlineData("20000000000000000000", 2147483647)]
        [InlineData("-20000000000000000000", -2147483648)]
        public void StringToInteger(string s, int expected)
        {
            var result = new StringToInteger().Convert(s);

            Assert.Equal(expected, result);
        }
    }
}
