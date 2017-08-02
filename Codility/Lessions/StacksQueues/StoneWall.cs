using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.StacksQueues
{
    //https://codility.com/programmers/lessons/7-stacks_and_queues/stone_wall/
    public class StoneWall
    {
        //The goal is to keep the stack sorted (asending) overtime a new number is adding to it. You need to count number of pushes!
        public static int solution(int[] H)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (H == null || H.Length == 0)
            {
                return 0;
            }

            var result = 0;
            var stack = new System.Collections.Generic.Stack<int>();

            for (int i = 0; i < H.Length; i++)
            {
                var h = H[i];

                while (stack.Count > 0 && stack.Peek() > h)
                {
                    stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek() < h)
                {
                    stack.Push(h);
                    result++;
                }
            }

            return result;
        }
    }
}
