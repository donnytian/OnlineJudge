using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.TimeComplexity
{
    //https://codility.com/programmers/lessons/3-time_complexity/perm_missing_elem/
    public class PermMissingElem
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 1;
            }

            var result = 0;

            var n = A.Length;

            for (var i = 0; i < n; i++)
            {
                result ^= (i + 1) ^ A[i];
            }

            result ^= n + 1;

            return result;
        }
    }
}
