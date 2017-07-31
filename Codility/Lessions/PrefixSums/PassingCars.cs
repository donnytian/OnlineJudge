using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.PrefixSums
{
    //https://codility.com/programmers/lessons/5-prefix_sums/passing_cars/
    public class PassingCars
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
            {
                return 0;
            }

            long result = 0;
            var zeroCount = 0;

            for (var i = 0; i < A.Length; i++)
            {
                var e = A[i];
                zeroCount = e == 0 ? zeroCount + 1 : zeroCount;

                if (e == 1)
                {
                    result += zeroCount;
                }
            }

            if (result > 1000000000)
            {
                result = -1;
            }

            return (int) result;
        }
    }
}
