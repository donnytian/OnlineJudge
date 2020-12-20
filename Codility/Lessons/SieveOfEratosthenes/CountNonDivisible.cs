using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.SieveOfEratosthenes
{
    //https://codility.com/programmers/lessons/11-sieve_of_eratosthenes/count_non_divisible/
    public class CountNonDivisible
    {
        public static int[] solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length == 1)
            {
                return new[] { 0 };
            }

            var n = A.Length;
            var result = new int[n];
            var array = new int[n * 2 + 1];

            for (int i = 0; i < n; i++)
            {
                array[A[i]]++; // Stores how many times a number appears in A.
            }

            for (int i = 0; i < n; i++)
            {
                var a = A[i];
                var root = Math.Sqrt(a);
                var count = 0;

                for (int j = 1; j <= root; j++)
                {
                    var mod = a % j;

                    if (mod == 0)
                    {
                        count += array[j];

                        if (a / j != j)
                        {
                            count += array[a / j];
                        }
                    }
                }

                result[i] = n - count;
            }

            return result;
        }
    }
}
