using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Sorting
{
    //https://codility.com/programmers/lessons/6-sorting/max_product_of_three/
    public class MaxProductOfThree
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            Array.Sort(A);
            var len = A.Length;

            var left = A[0] * A[1] * A[len - 1]; // We need take care 2 negative numbers, they result a positive by multiply.
            var right = A[len - 3] * A[len - 2] * A[len - 1];

            return left > right ? left : right;
        }
    }
}
