using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.MaximumSliceProblem
{
    //https://codility.com/programmers/lessons/9-maximum_slice_problem/max_slice_sum/
    public class MaxSliceSum
    {
        // Time O(n); Space O(n)
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 1)
            {
                return 0;
            }

            long result = long.MinValue;
            var lSums = new long[A.Length]; // Inclusive
            var rSums = new long[A.Length]; // Exclusive

            for (int i = 0, j = A.Length - 1; i < A.Length; i++, j--)
            {
                var sum = i > 0 ? lSums[i - 1] : 0;
                lSums[i] = sum > 0 ? sum + A[i] : A[i];

                sum = j < A.Length - 1 ? rSums[j + 1] + A[j + 1] : 0;
                rSums[j] = sum > 0 ? sum : 0;
            }

            for (int i = 0; i < A.Length; i++)
            {
                var sum = lSums[i] + rSums[i];
                if (sum > result)
                {
                    result = sum;
                }
            }

            return (int)result;
        }

        // Time O(n); Space O(1)
        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 1)
            {
                return 0;
            }

            long result = int.MinValue;
            long leftSum = int.MinValue;

            for (int i = 0; i < A.Length; i++)
            {
                leftSum = leftSum > 0 ? leftSum + A[i] : A[i];

                if (leftSum > result)
                {
                    result = leftSum;
                }
            }

            return (int)result;
        }
    }
}
