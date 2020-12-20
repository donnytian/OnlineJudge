using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.StacksQueues
{
    //https://codility.com/programmers/lessons/7-stacks_and_queues/fish/
    public class Fish
    {
        public static int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length == 0 || B == null || B.Length == 0)
            {
                return 0;
            }

            var stack = new System.Collections.Generic.Stack<int>();

            for (int i = 0; i < A.Length; i++)
            {
                var size = A[i];
                var dir = B[i];

                while (stack.Count != 0)
                {
                    var prev = stack.Peek();
                    var prevDir = B[prev];
                    var prevSize = A[prev];

                    if (prevDir == 0 || dir == 1)
                    {
                        stack.Push(i);
                        break;
                    }

                    if (prevSize < size)
                    {
                        stack.Pop(); // Previous fish has been eatten.
                    }
                    else
                    {
                        // Does not push to indicate the current fish has been eatten.
                        break;
                    }
                }

                if (stack.Count == 0)
                {
                    stack.Push(i);
                }
            }

            return stack.Count;
        }
    }
}
