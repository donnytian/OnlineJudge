using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.EuclideanAlgorithm
{
    //https://codility.com/programmers/lessons/12-euclidean_algorithm/chocolates_by_numbers/
    public class ChocolatesByNumbers
    {
        public static int solution(int N, int M)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return N / gcd(N, M);
        }

        public static int gcd(int a, int b)
        {
            if (a % b == 0)
            {
                return b;
            }

            return gcd(b, a % b);
        }
    }
}
