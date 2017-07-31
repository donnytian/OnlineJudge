using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.CountingElements
{
    //https://codility.com/programmers/lessons/4-counting_elements/perm_check/
    public class PermCheck
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var set = new System.Collections.Generic.HashSet<int>(System.Linq.Enumerable.Range(1, A.Length));

            for (var i = 0; i < A.Length; i++)
            {
                if (set.Contains(A[i]))
                {
                    set.Remove(A[i]);
                }
                else
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}
