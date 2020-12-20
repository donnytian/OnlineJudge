using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.CountingElements
{
    //https://codility.com/programmers/lessons/4-counting_elements/frog_river_one/
    public class FrogRiverOne
    {
        public static int solution(int X, int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (X < 1 || A == null || A.Length == 0 || A.Length < X)
            {
                return -1;
            }

            var set = new System.Collections.Generic.HashSet<int>(System.Linq.Enumerable.Range(1, X));

            for (var i = 0; i < A.Length; i++)
            {
                if (set.Contains(A[i]))
                {
                    set.Remove(A[i]);
                }

                if (set.Count == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
