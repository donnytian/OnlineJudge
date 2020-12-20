using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.CaterpillarMethod
{
    //https://codility.com/programmers/lessons/15-caterpillar_method/abs_distinct/
    public class AbsDistinct
    {
        public static int solution(int[] A)
        {
            // Of course, we can add all abs into a Set and count the Set.
            // Insteadly we use caterpillar method here.

            var n = A.Length;
            var i = 0;
            var j = A.Length - 1;

            while (i < j)
            {
                while (Math.Abs((long)A[i]) > Math.Abs((long)A[j]))
                {
                    if (Math.Abs((long)A[i]) == Math.Abs((long)A[i + 1]))
                    {
                        n--;
                    }

                    i++;
                }

                if (i == j)
                {
                    break;
                }

                if (Math.Abs((long)A[j]) == Math.Abs((long)A[j - 1]) || Math.Abs((long)A[i]) == Math.Abs((long)A[j]))
                {
                    n--;
                }

                j--;
            }

            return n;
        }
    }
}
