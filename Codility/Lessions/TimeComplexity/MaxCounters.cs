using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.TimeComplexity
{
    //https://codility.com/programmers/lessons/4-counting_elements/max_counters/
    public class MaxCounters
    {
        public static int[] solution(int N, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (N < 1 || A == null)
            {
                return new int[] { };
            }

            var result = new int[N];
            var max = 0;
            var appliedMax = 0;

            for (var i = 0; i < A.Length; i++)
            {
                var x = A[i];
                if (x > 0 && x <= N)
                {
                    result[x - 1] = result[x - 1] < appliedMax ? appliedMax : result[x - 1];
                    result[x - 1]++;
                    max = result[x - 1] > max ? result[x - 1] : max;
                }
                else if (x == N + 1)
                {
                    appliedMax = max;
                }
            }

            for (var i = 0; i < N; i++)
            {
                result[i] = result[i] < appliedMax ? appliedMax : result[i];
            }

            return result;
        }
    }
}
