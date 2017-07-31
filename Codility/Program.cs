using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new int[] {-1, 3, -4, 5, 1, -6, 2, 1};

            Console.WriteLine(CodilityLessions.MaxBinaryGap(1041));
            Console.ReadLine();
        }

        public static int solutionA(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A == null || A.Length == 0)
            {
                return -1;
            }

            if (A.Length == 1)
            {
                return 0;
            }

            var left = new long[A.Length];
            var right = new long[A.Length];

            for (int i = 1, j = A.Length - 2; i < A.Length; i++, j--)
            {
                left[i] = i == 1 ? A[i - 1] : left[i - 2] + A[i - 1];
                right[j] = j == A.Length - 2 ? A[j + 1] : right[j + 2] + A[j + 1];
            }

            for (var i = 0; i < left.Length; i++)
            {
                if (left[i] == right[i])
                {
                    return i;
                }
            }

            return -1;
        }

        // Single swap for non-decreasing array.
        public bool solutionB(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            if (A == null)
            {
                return false;
            }

            if (A.Length <= 2)
            {
                return true;
            }

            var swapCount = 0;
            for (int i = 0, j = A.Length - 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    while (j > i)
                    {
                        if (A[j] <= A[i + 1]) // Revised line from 'if (A[j] <= A[i] && A[j] <= A[i + 1])'.
                        {
                            break;
                        }
                        j--;
                    }

                    if (j > i)
                    {
                        var temp = A[i];
                        A[i] = A[j];
                        A[j] = temp;
                        swapCount++;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (swapCount > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public class Tree
        {
            public int x;
            public Tree l;
            public Tree r;
        };

        // Longest Zigzag length of binary tree.
        public int solution(Tree T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var length = 0;

            if (T == null)
            {
                return length;
            }

            var stack = new System.Collections.Generic.Stack<Tree>();
            var node = T;
            node.x = 0;

            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);

                    var isRoot = node.x == 0;
                    if (node.x < 0 && node.r != null) // Detects Zigzag.
                    {
                        node.x--;
                    }
                    else if (node.x > 0 && node.l != null) // Detects Zigzag.
                    {
                        node.x++;
                    }

                    // Abs. of x for the Zigzag length for the current node.
                    var currentLength = node.x < 0 ? -node.x : node.x;
                    if (isRoot)
                    {
                        currentLength++;
                    }

                    if (currentLength > length)
                    {
                        length = currentLength;
                    }

                    node = node.l;
                    if (node != null)
                    {
                        node.x = -currentLength; // Negative indicates the left child to its parent.
                    }
                }
                else
                {
                    var item = stack.Pop();
                    node = item.r;
                    if (node != null)
                    {
                        var currentLength = item.x < 0 ? -item.x : item.x;
                        if (item.x == 0)
                        {
                            currentLength++;
                        }
                        node.x = currentLength; // Positive indicates the right child to its parent.
                    }
                }
            }

            return length > 0 ? length - 1 : length;
        }
    }
}
