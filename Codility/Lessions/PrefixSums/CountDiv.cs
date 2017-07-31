using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.PrefixSums
{
    //https://codility.com/programmers/lessons/5-prefix_sums/count_div/
    public class CountDiv
    {
        //count { i : A ≤ i ≤ B, i mod K = 0 }
        public static int solution(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A > B || K <= 0)
            {
                return 0;
            }

            var count = (B - A) / K;
            var modA = A % K;
            var modB = B % K;

            // Shifts A-B to right to make A is the first number that can be divided by K.
            // If (K - modA) + modB < K then we need count++, simplied as modB < modA.
            if (modA == 0 || modB < modA)
            {
                count++;
            }

            return count;
        }

        // A conciser solution.
        public static int solution2(int A, int B, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A > B || K <= 0)
            {
                return 0;
            }

            return B / K - A / K + (A % K == 0 ? 1 : 0);
        }
    }

    public class CountDiv_Tests
    {
        [Theory]
        [InlineData(11, 14, 2, 2)]
        [InlineData(11, 345, 17, 20)]
        [InlineData(5, 345, 17, 20)]
        [InlineData(18, 352, 17, 19)]
        public void CountDiv_Test(int A, int B, int K, int expected)
        {
            Assert.Equal(expected, CountDiv.solution(A, B, K));
            Assert.Equal(expected, CountDiv.solution2(A, B, K));
        }
    }
}
