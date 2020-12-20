using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.TimeComplexity
{
    //https://codility.com/programmers/lessons/3-time_complexity/frog_jmp/
    public class FrogJmp
    {
        public static int solution(int X, int Y, int D)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var mod = (Y - X) % D;
            var count = (Y - X) / D;
            return mod == 0 ? count : count + 1;
        }
    }
}
