using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.FibonacciNumbers
{
    //https://codility.com/programmers/lessons/13-fibonacci_numbers/fib_frog/
    public class FibFrog
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A.Length < 3)
            {
                return 1;
            }

            var n = A.Length;
            var mins = new int[n + 1]; // Min jumps to arrive the current leaf.
            var fibList = new System.Collections.Generic.List<int>();

            fibList.Add(1);
            fibList.Add(2);

            while (fibList[fibList.Count - 1] < n)
            {
                var i = fibList.Count;
                fibList.Add(fibList[i - 1] + fibList[i - 2]);
            }

            for (int i = 0; i < mins.Length; i++)
            {
                if (i != n && A[i] != 1)
                {
                    mins[i] = -1;
                    continue;
                }

                var min = int.MaxValue;

                for (int j = fibList.Count - 1; j >= 0; j--)
                {
                    var k = i - fibList[j];

                    if (k < -1)
                    {
                        continue;
                    }

                    if (k == -1)
                    {
                        min = 1;
                        break;
                    }

                    if (mins[k] == -1)
                    {
                        continue;
                    }

                    if (mins[k] + 1 < min)
                    {
                        min = mins[k] + 1;
                    }
                }

                mins[i] = min == int.MaxValue ? -1 : min;
            }

            return mins[n];
        }
    }
}
