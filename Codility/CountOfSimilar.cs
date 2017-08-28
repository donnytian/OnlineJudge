using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class CountOfSimilar
    {
        public int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var result = 1;

            if (N == 0)
            {
                return result;
            }

            var s = N.ToString();
            var zeroCount = 0;
            var set = new System.Collections.Generic.HashSet<int>();
            var a = new int[10];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    zeroCount++;
                }

                var j = int.Parse(s[i].ToString());
                a[j]++;
                set.Add(s[i]);
            }

            var distinctCount = set.Count;
            var count = Calc(set.Count);
            count = count - Calc(distinctCount - zeroCount);

            var dup = s.Length - distinctCount - zeroCount;
            count = count - Calc(dup);

            return count;
        }

        private static int Calc(int c)
        {
            var result = 1;
            for (int i = c; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
