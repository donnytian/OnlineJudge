using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.FibonacciNumbers
{
    //https://codility.com/programmers/lessons/13-fibonacci_numbers/ladder/
    public class Ladder
    {
        public static int[] solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var result = new int[A.Length];
            var fib = new int[A.Length + 1];

            fib[0] = 1;
            fib[1] = 1;

            for (int i = 2; i < fib.Length; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
                fib[i] %= 1 << 30;
            }

            for (int i = 0; i < A.Length; i++)
            {
                result[i] = fib[A[i]] % (1 << B[i]);
            }

            return result;
        }
    }
}
