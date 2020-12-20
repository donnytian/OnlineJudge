using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.TimeComplexity
{
    //https://codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
    public class TapeEquilibrium
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length <= 1)
            {
                return -1;
            }

            var n = A.Length;
            var l = new int[n];
            var r = new int[n];
            var result = int.MaxValue;

            for (int i = 0, j = n - 1; i < n; i++, j--)
            {
                l[i] = i > 0 ? l[i - 1] + A[i] : A[i];
                r[j] = j < n - 1 ? r[j + 1] + A[j] : A[j];
            }

            for (var i = 0; i < n - 1; i++)
            {
                var diff = l[i] - r[i + 1];
                diff = diff < 0 ? -diff : diff;
                result = diff < result ? diff : result;
            }

            return result;
        }
    }
}
