using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.PrimeAndCompositeNumbers
{
    //https://codility.com/programmers/lessons/10-prime_and_composite_numbers/flags/
    public class Flags
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            var list = new System.Collections.Generic.List<int>();
            var minDist = int.MaxValue;

            for (int i = 1; i < A.Length - 1; i++)
            {
                var a = A[i];

                if (a <= A[i - 1] || a <= A[i + 1])
                {
                    continue;
                }

                if (list.Count > 0 && i - list[list.Count - 1] < minDist)
                {
                    minDist = i - list[list.Count - 1];
                }

                list.Add(i);
            }

            if (minDist >= list.Count)
            {
                return list.Count;
            }

            var max = Math.Sqrt(list[list.Count - 1] - list[0]) + 1;

            for (int i = 3; i <= max; i++)
            {
                var count = 1;
                var prev = 0;

                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j] - list[prev] >= i)
                    {
                        count++;
                        prev = j;
                    }

                    if (count >= i)
                    {
                        break;
                    }
                }

                if (count < i)
                {
                    return i - 1;
                }
            }

            return (int)max;
        }
    }
}
