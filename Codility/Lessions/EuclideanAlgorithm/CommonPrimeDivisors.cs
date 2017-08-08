using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Codility.Lessions.EuclideanAlgorithm
{
    //https://codility.com/programmers/lessons/12-euclidean_algorithm/common_prime_divisors/
    public class CommonPrimeDivisors
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var result = 0;

            for (int i = 0; i < A.Length; i++)
            {
                var a = A[i];
                var b = B[i];

                // All common factors should be also factors of gcd.
                // Then all common prime factors are also be factor of gcd.
                // So we just need verify the divisor of a and b by gcd, see if the divisor have any other prime factors.
                var g = gcd(a, b);

                // So we detect any else prime by divide the original gcd (which contains all common prime factors).
                var d1 = a / g;

                var c = 0;

                while (c != 1)
                {
                    c = gcd(d1, g);
                    d1 /= c;
                }

                var d2 = b / g;
                c = 0;

                while (c != 1)
                {
                    c = gcd(d2, g);
                    d2 /= c;
                }

                if (d1 == 1 && d2 == 1)
                {
                    result++;
                }
            }

            return result;
        }

        public static int gcd(int a, int b)
        {
            if (a % b == 0)
            {
                return b;
            }

            return gcd(b, a % b);
        }

        // Binary Euclidean algorithm
        // Worst case (very big number) time complexity: O((log n)^2)
        public static int gcd(int a, int b, int res)
        {
            if (a == b)
            {
                return a * res;
            }

            if (a % 2 == 0 && b % 2 == 0)
            {
                return gcd(a / 2, b / 2, 2 * res);
            }

            if (a % 2 == 0)
            {
                return gcd(a / 2, b, res);
            }

            if (b % 2 == 0)
            {
                return gcd(a, b / 2, res);
            }

            if (a > b)
            {
                return gcd(a - b, b, res);
            }

            return gcd(a, b - a, res);
        }
    }
}
