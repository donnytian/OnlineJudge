using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.MaximumSliceProblem
{
    //https://codility.com/programmers/lessons/9-maximum_slice_problem/max_double_slice_sum/
    public class MaxDoubleSliceSum
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length <= 3)
            {
                return 0;
            }

            var result = 0;
            var lSums = new int[A.Length];
            var rSums = new int[A.Length];

            for (int i = 2, j = A.Length - 3; i < A.Length - 1; i++, j--)
            {
                var sum = lSums[i - 1] + A[i - 1];
                lSums[i] = sum > 0 ? sum : 0;

                sum = rSums[j + 1] + A[j + 1];
                rSums[j] = sum > 0 ? sum : 0;
            }

            for (int i = 1; i < A.Length - 1; i++)
            {
                var sum = lSums[i] + rSums[i];

                if (sum > result)
                {
                    result = sum;
                }
            }

            return result;
        }
    }
}
