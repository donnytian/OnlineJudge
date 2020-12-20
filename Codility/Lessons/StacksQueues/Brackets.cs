using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.StacksQueues
{
    //https://codility.com/programmers/lessons/7-stacks_and_queues/brackets/
    public class Brackets
    {
        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (S == null)
            {
                return 0;
            }

            if (S.Length == 0)
            {
                return 1;
            }

            var left = "{[(";
            var right = "}])";
            var stack = new System.Collections.Generic.Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                var l = left.IndexOf(c);
                var r = right.IndexOf(c);

                if (l >= 0)
                {
                    stack.Push(c);
                }
                else if (r >= 0 && stack.Count > 0)
                {
                    if (stack.Pop() != left[r])
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }

            return stack.Count == 0 ? 1 : 0;
        }
    }
}
