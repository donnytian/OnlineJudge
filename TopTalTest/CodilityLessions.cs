using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    public static class CodilityLessions
    {
        public static int MaxBinaryGap(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (N <= 1)
            {
                return 0;
            }

            var s = Convert.ToString(N, 2);
            var length = 0;
            var max = 0;

            if (string.IsNullOrEmpty(s))
            {
                return max;
            }

            var counting = false;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (i > 0 && s[i - 1] == '1')
                    {
                        counting = true;
                    }

                    if (counting)
                    {
                        length++;
                    }
                }
                else
                {
                    if (counting && length > max)
                    {
                        max = length;
                    }

                    length = 0;
                    counting = false;
                }
            }

            return max;
        }
    }
}
