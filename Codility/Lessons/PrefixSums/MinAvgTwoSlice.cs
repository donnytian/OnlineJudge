using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.PrefixSums
{
    //https://codility.com/programmers/lessons/5-prefix_sums/min_avg_two_slice/
    public class MinAvgTwoSlice
    {
        //Find the minimal average of any slice containing at least two elements.

        //The trick to this problem is that the min average slice also cannot be longer than 3.
        //So we only have to calculate the avg of the slices of length 2 and 3.
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
            {
                return -1;
            }

            var result = 0;
            double min = int.MaxValue;

            for (int i = 0; i < A.Length - 1; i++)
            {
                var sumOf2 = (double) A[i] + A[i + 1];
                var avgOf2 = sumOf2 / 2;
                var sumOf3 = i + 2 < A.Length ? sumOf2 + A[i + 2] : sumOf2 + int.MaxValue;
                var avgOf3 = sumOf3 / 3;

                if (avgOf2 < min || avgOf3 < min)
                {
                    result = i;
                    min = avgOf2 < avgOf3 ? avgOf2 : avgOf3;
                }
            }

            return result;
        }
    }
}
