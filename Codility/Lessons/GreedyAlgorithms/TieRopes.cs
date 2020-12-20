using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.GreedyAlgorithms
{
    //https://codility.com/programmers/lessons/16-greedy_algorithms/tie_ropes/
    public class TieRopes
    {
        public static int solution(int K, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var result = 0;
            long len = 0;

            for (int i = 0; i < A.Length; i++)
            {
                len += A[i];

                if (len >= K)
                {
                    result++;
                    len = 0;
                }
            }

            return result;
        }
    }
}
