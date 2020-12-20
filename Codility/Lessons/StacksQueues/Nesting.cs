using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.StacksQueues
{
    //https://codility.com/programmers/lessons/7-stacks_and_queues/nesting/
    public class Nesting
    {
        public static int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (string.IsNullOrEmpty(S))
            {
                return 1;
            }

            var left = '(';
            var right = ')';
            var stack = new System.Collections.Generic.Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                var s = S[i];

                if (s == left)
                {
                    stack.Push(s);
                }
                else if (s == right && stack.Count > 0)
                {
                    if (stack.Pop() != left)
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
