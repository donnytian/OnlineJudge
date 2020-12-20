using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.CaterpillarMethod
{
    //https://codility.com/programmers/lessons/15-caterpillar_method/count_triangles/
    public class CountTriangles
    {
        // O(n^2)
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            Array.Sort(A);

            var result = 0;

            // The time complexity of the algorithm is O(n2), because for every stick x the values of
            // y and z increase O(n) number of times.
            for (int i = 0; i < A.Length - 2; i++)
            {
                var k = i + 2;

                for (int j = i + 1; j < A.Length - 1; j++)
                {
                    while (k < A.Length && A[i] + A[j] > A[k])
                    {
                        k++;
                    }

                    result += k - j - 1;
                }
            }

            return result;
        }
    }
}
