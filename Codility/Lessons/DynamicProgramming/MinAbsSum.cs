using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.DynamicProgramming
{
    //https://codility.com/programmers/lessons/17-dynamic_programming/min_abs_sum/
    public class MinAbsSum
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            if (A.Length == 1)
            {
                return A[0] >= 0 ? A[0] : -A[0];
            }

            var n = A.Length;
            var sum = 0;
            var max = int.MinValue;

            // Updates element to ABS and gets max and total sum.
            for (int i = 0; i < n; i++)
            {
                if (A[i] < 0)
                {
                    A[i] = -A[i];
                }

                sum += A[i];
                max = A[i] > max ? A[i] : max;
            }

            // Sine the range of element is much smaller than the number of element, we use a small array to represent input A.
            var valueCounts = new int[max + 1];

            for (int i = 0; i < n; i++)
            {
                valueCounts[A[i]]++;
            }

            // All possible sums (include 1 to n elements) will be marked >= 0. We need find the largest sum that <= half of the sum of entire array A.
            var possibleSums = new int[sum + 1];

            for (int i = 1; i < possibleSums.Length; i++)
            {
                possibleSums[i] = -1;
            }

            // Uses valueCounts to populuate possible-sum flag.
            // For each value, add to sum and make it >= 0.
            for (int i = 1; i < valueCounts.Length; i++)
            {
                if (valueCounts[i] == 0)
                {
                    continue;
                }

                // Updates flags of possible-sum by the remaining count of the element value "i".
                for (int j = 0; j < possibleSums.Length; j++)
                {
                    if (possibleSums[j] >= 0)
                    {
                        // "j" is already a possible sum before the addition of any "i". So we put all count of "i" here.
                        possibleSums[j] = valueCounts[i];
                    }
                    else if(j - i >= 0 && possibleSums[j - i] > 0)
                    {
                        // Marks a new possible sum, and update it as the remaining count of "i".
                        possibleSums[j] = possibleSums[j - i] - 1;
                    }
                }
            }

            // Simply find the smallest diff.
            var result = sum;

            for (int i = 0; i < (possibleSums.Length / 2) + 1; i++)
            {
                if (possibleSums[i] < 0)
                {
                    continue;
                }

                // Another = sum - i; diff = another - i;
                var diff = sum - i - i;
                diff = diff < 0 ? -diff : diff;

                if (diff < result)
                {
                    result = diff;
                }
            }

            return result;
        }
    }

    public class MinAbsSum_Tests
    {
        [Theory]
        [InlineData(new[] { 1, 5, 2, -2 }, 0)]
        public void MinAbsSum_Test(int[] a, int expected)
        {
            Assert.Equal(expected, MinAbsSum.solution(a));
        }
    }
}
