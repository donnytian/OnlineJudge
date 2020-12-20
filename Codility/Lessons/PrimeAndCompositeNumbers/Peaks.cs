using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.PrimeAndCompositeNumbers
{
    //https://codility.com/programmers/lessons/10-prime_and_composite_numbers/peaks/
    public class Peaks
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            var result = 0;
            var pIndices = new System.Collections.Generic.List<int>();

            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    pIndices.Add(i);
                }
            }

            var count = pIndices.Count;
            if (count <= 1)
            {
                return count;
            }

            var indices = pIndices.ToArray();

            for (int i = count; i >= 2; i--)
            {
                if (A.Length % i != 0)
                {
                    continue;
                }

                var n = A.Length / i;
                var l = 0;
                var r = l + n;
                var noPeak = false;

                while (r <= A.Length)
                {
                    if (Array.BinarySearch(indices, l) >= 0)
                    {
                        l = r;
                        r = l + n;
                        continue;
                    }

                    l++;

                    if (r == l)
                    {
                        noPeak = true;
                        break;
                    }
                }

                if (!noPeak)
                {
                    return i;
                }
            }

            return 1;
        }
    }

    public class Peaks_Tests
    {
        [Theory]
        [InlineData(new []{ 1, 2, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 }, 3)]
        public void Peaks_Test(int[] a, int expectted)
        {
            Assert.Equal(expectted, Peaks.solution(a));
        }
    }
}
