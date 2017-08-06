using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.PrimeAndCompositeNumbers
{
    //https://codility.com/programmers/lessons/10-prime_and_composite_numbers/count_factors/
    public class CountFactors
    {
        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (N < 1)
            {
                return 0;
            }

            if (N < 3)
            {
                return N;
            }

            var root = Math.Sqrt(N);
            var result = 0;

            for (int i = 1; i <= root; i++)
            {
                if (N % i == 0)
                {
                    var f = N / i;
                    result++;

                    if (f > i)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }

    public class CountFactors_Tests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(4, 3)]
        [InlineData(6, 4)]
        [InlineData(24, 8)]
        public void CountFactors_Test(int n, int expected)
        {
            Assert.Equal(expected, CountFactors.solution(n));
        }
    }
}
