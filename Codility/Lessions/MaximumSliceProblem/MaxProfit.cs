using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.MaximumSliceProblem
{
    //https://codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/
    public class MaxProfit
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length <= 1)
            {
                return 0;
            }

            var result = 0;
            var minIndex = 0;

            for (int i = 1; i < A.Length; i++)
            {
                var a = A[i];
                var min = A[minIndex];
                var p = a - min;

                if (p > result)
                {
                    result = p;
                }

                if (a < min)
                {
                    minIndex = i;
                }
            }

            return result;
        }
    }
}
