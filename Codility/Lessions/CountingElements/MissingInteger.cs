using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.CountingElements
{
    //https://codility.com/programmers/lessons/4-counting_elements/missing_integer/
    public class MissingInteger
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 1;
            }

            var set = new System.Collections.Generic.HashSet<int>();

            for (var i = 0; i < A.Length; i++)
            {
                set.Add(A[i]);
            }

            for (var i = 0; i < A.Length; i++)
            {
                if (!set.Contains(i + 1))
                {
                    return i + 1;
                }
            }

            return A.Length + 1;
        }
    }
}
