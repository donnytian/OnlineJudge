using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility
{
    // Single swap for non-decreasing array.
    public class SingleSwap
    {
        public static bool solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A == null || A.Length == 0)
            {
                return false;
            }

            if (A.Length <= 2)
            {
                return true;
            }

            var swapCount = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    if (swapCount > 0)
                    {
                        return false;
                    }

                    // Search the smallest value A[k] where k > i and swap.
                    var j = i + 1;
                    var k = j;
                    var min = int.MaxValue;

                    while (j < A.Length)
                    {
                        if (A[j] <= min) // "<=" ensures we get the largest k to do the swap. Try [3, 1, 1].
                        {
                            min = A[j];
                            k = j;
                        }
                        j++;
                    }

                    // Found the smallest, but if it is even smaller than the left one, then we still need more swaps, so return false.
                    // Try [4, 5, 10, 1, 11]
                    if (i > 0 && A[i - 1] > A[k])
                    {
                        return false;
                    }

                    var temp = A[i];
                    A[i] = A[k];
                    A[k] = temp;
                    swapCount++;
                }
            }

            return true;
        }
    }

    public class SingleSwap_Tests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData(new int[] { }, false)]
        [InlineData(new [] { 1 }, true)]
        [InlineData(new[] { 1, 0 }, true)]
        [InlineData(new[] { 3, 1, 2 }, false)]
        [InlineData(new[] { 3, 1, 1 }, true)]
        [InlineData(new[] { 4, 5, 10, 1, 11 }, false)]
        [InlineData(new[] { 4, 5, 10, 6, 11 }, true)]
        [InlineData(new[] { 4, 5, 10, 6, 5 }, true)]
        public void SingleSwap_Test(int[] a, bool expected)
        {
            Assert.Equal(expected, SingleSwap.solution(a));
        }
    }
}
