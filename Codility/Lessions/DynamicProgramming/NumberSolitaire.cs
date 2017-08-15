using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.DynamicProgramming
{
    //https://codility.com/programmers/lessons/17-dynamic_programming/number_solitaire/
    public class NumberSolitaire
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var n = A.Length;
            var maxOfN = new int[n];

            maxOfN[0] = A[0];

            for (int i = 1; i < n; i++)
            {
                var max = int.MinValue;

                for (int j = 1; j < 7; j++)
                {
                    var k = i - j;
                    if (k >= 0 && maxOfN[k] + A[i] > max)
                    {
                        max = maxOfN[k] + A[i];
                    }
                }

                maxOfN[i] = max;
            }

            return maxOfN[n - 1];
        }
    }
}
