using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Arrays
{
    //https://codility.com/programmers/lessons/2-arrays/cyclic_rotation/
    public class CyclicRotation
    {
        // Rotates to right K times for array A.
        public int[] solution(int[] A, int K)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A == null || A.Length == 0)
            {
                return new int[] { };
            }

            var length = A.Length;
            K = K % length;

            if (K == 0 || A.Length < 2)
            {
                return A;
            }

            var result = new int[length];

            for (var i = 0; i < length; i++)
            {
                var j = i + K;

                if (j >= length)
                {
                    j -= length;
                }

                result[j] = A[i];
            }

            return result;
        }
    }
}
