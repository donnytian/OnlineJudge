using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Sorting
{
    //https://codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/
    public class NumberOfDiscIntersections
    {
        //O(N*N)
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
            {
                return 0;
            }

            var result = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                var r = (long)i + A[i];

                for (int j = i + 1; j < A.Length; j++)
                {
                    if (r >= (long)j - A[j])
                    {
                        result++;
                    }

                    if (result > 10000000)
                    {
                        return -1;
                    }
                }
            }

            return result;
        }

        //O(NlogN)
        public static int solution2(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
            {
                return 0;
            }

            var result = 0;
            var right = new long[A.Length];
            var left = new long[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                right[i] = (long)i + A[i];
                left[i] = (long)i - A[i];
            }

            Array.Sort(right);
            Array.Sort(left);

            for (int i = 0, j = 0; i < right.Length; i++)
            {
                while (j < left.Length && right[i] >= left[j])
                {
                    //result += j - i;
                    j++;
                }

                result += j - i - 1; // Subtracts duplicates and self pairs.

                if (result > 10000000)
                {
                    return -1;
                }
            }

            return result;
        }

        //O(N)
        //
        // Not Finished!!!
        //
        // https://stackoverflow.com/questions/4801242/algorithm-to-calculate-number-of-intersecting-discs/27549852#27549852
        public static int solution3(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
            {
                return 0;
            }

            var result = 0;
            var left = new int[A.Length];

            // "left" stores count of left sides at each endpoint in X-Axis.
            for (int i = 0; i < left.Length; i++)
            {
                var a = A[i];
                left[i] = -1;
                left[i - a < 0 ? 0 : i - a]++;
            }

            // Iterates each right side endpoint and sum left side count at that endpoint.
            for (int i = 0; i < A.Length; i++)
            {
                var a = A[i];
                var right = i + a;
                result += left[right >= A.Length ? A.Length - 1 : right];
            }

            return result;
        }
    }
}
