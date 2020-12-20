using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.GreedyAlgorithms
{
    //https://codility.com/programmers/lessons/16-greedy_algorithms/max_nonoverlapping_segments/
    public class MaxNonoverlappingSegments
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var result = A.Length;
            var lastB = B[0];

            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] <= lastB)
                {
                    result--;
                }
                else
                {
                    lastB = B[i];
                }
            }

            return result;
        }
    }
}
