using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Sorting
{
    //https://codility.com/programmers/lessons/6-sorting/distinct/
    public class Distinct
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            var set = new System.Collections.Generic.HashSet<int>(A);

            return set.Count;
        }
    }
}
