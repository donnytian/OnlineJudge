using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.PrimeAndCompositeNumbers
{
    //https://codility.com/programmers/lessons/10-prime_and_composite_numbers/min_perimeter_rectangle/
    public class MinPerimeterRectangle
    {
        public static int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (N < 0 || N > 1000000000)
            {
                return 0;
            }

            var root = Math.Sqrt(N);
            var perimeter = N + 1;

            for (int i = 2; i <= root; i++)
            {
                if (N % i == 0)
                {
                    var p = i + N / i;

                    if (p < perimeter)
                    {
                        perimeter = p;
                    }
                }
            }

            return perimeter * 2;
        }
    }
}
