using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.SieveOfEratosthenes
{
    //https://codility.com/programmers/lessons/11-sieve_of_eratosthenes/count_semiprimes/
    public class CountSemiprimes
    {
        public static int[] solution(int N, int[] P, int[] Q)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var result = new int[P.Length];

            var array = new int[N + 1];
            var i = 2;

            // Initializes array with the smallest prime factor for the number of i which is <= n;
            // If i itself is a prime, keep array[i] as zero.
            while (i * i <= N)
            {
                if (array[i] == 0)
                {
                    var k = i * i;

                    while (k <= N)
                    {
                        array[k] = i;
                        k += i;
                    }
                }

                i++;
            }

            var semiPrimes = new int[N + 1];

            for (int j = 2; j <= N;j++)
            {
                var a = array[j];

                // a > 0 means j is not a prime, a and j / a are 2 factors while a is the smallest prime factor.
                // array[j / a] == 0 means j / a is also a prime factor. So j is a semi-prime.
                if (a > 0 && array[j / a] == 0)
                {
                    semiPrimes[j] = 1; // Set 1 as a flag to indicates j is a semi-prime.
                }
            }

            // Pre-sum for semi-primes.
            for (int j = 3; j <= N; j++)
            {
                semiPrimes[j] += semiPrimes[j - 1];
            }

            // Counts semi-primes for range queries.
            for (int j = 0; j < result.Length; j++)
            {
                var l = P[j];
                var r = Q[j];

                result[j] = semiPrimes[r] - semiPrimes[l];

                // Checks if the left number of range is a semi-prime.
                if (l > 2 && semiPrimes[l] > semiPrimes[l - 1])
                {
                    result[j]++;
                }
            }

            return result;
        }
    }
}
