using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.CaterpillarMethod
{
    //https://codility.com/programmers/lessons/15-caterpillar_method/count_distinct_slices/
    public class CountDistinctSlices
    {
        public static int solution(int M, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var Max = 1000000000;
            var count = 0;
            var flags = new int[M + 1];
            var i = 0;
            var j = 0;

            while (i < A.Length && j < A.Length)
            {
                if (flags[A[j]] == 0)
                {
                    flags[A[j]] = 1;
                    count += j - i + 1;

                    if (count > Max)
                    {
                        return Max;
                    }

                    j++;
                }
                else
                {
                    flags[A[i]] = 0;
                    i++;
                }
            }

            return count;
        }
    }

    public class CountDistinctSlices_Tests
    {
        [Theory]
        [InlineData(6, new[] { 3, 4, 5, 5, 2 }, 9)]
        [InlineData(6, new[] { 3, 4, 5, 5 }, 7)]
        public void CountDistinctSlices_Test(int m, int[] a, int expected)
        {
            Assert.Equal(expected, CountDistinctSlices.solution(m, a));
        }
    }
}
