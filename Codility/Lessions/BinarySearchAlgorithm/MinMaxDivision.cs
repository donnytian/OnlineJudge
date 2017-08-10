using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.BinarySearchAlgorithm
{
    //https://codility.com/programmers/lessons/14-binary_search_algorithm/min_max_division/
    public class MinMaxDivision
    {
        //The idea is that find a slice that its sum stands between maximum single number and the total array sum.
        public int solution(int K, int M, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var min = 0; // The possible min slice sum is the max single number.
            var max = 0; // The possible max slice sum is the total sum of array.

            for (int i = 0; i < A.Length; i++)
            {
                var a = A[i];

                if (a > min)
                {
                    min = a;
                }

                max += a;
            }

            // Binary search a slice that its sum stands between maximum single number and the total array sum.

            while (min < max)
            {
                var mid = (min + max) / 2;

                var k = 0;
                var sum = 0;

                for (int i = 0; i < A.Length && k < K; i++)
                {
                    sum += A[i];

                    if (sum > mid)
                    {
                        sum = A[i];
                        k++;
                    }
                }

                if (k == K)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid;
                }
            }

            return min;
        }
    }
}
