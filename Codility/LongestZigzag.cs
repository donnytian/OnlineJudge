using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility
{
    // Longest Zigzag length of binary tree.
    public class LongestZigzag
    {
        public class Tree
        {
            public int x;
            public Tree l;
            public Tree r;
        }

        public static int solution(Tree T)
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

                    if (node.x < 0 && node.r != null) // Zigzag detected.
                    {
                        node.x--;
                    }
                    else if (node.x > 0 && node.l != null) // Zigzag detected.
                    {
                        node.x++;
                    }

                    // Abs. of x for the Zigzag length for the current node.
                    var currentLength = node.x < 0 ? -node.x : node.x;
                    if (currentLength == 0) // Takes care of root.
                    {
                        currentLength = 1;
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
                        if (currentLength == 0) // Takes care of root.
                        {
                            currentLength = 1;
                        }
                        node.x = currentLength; // Positive indicates the right child to its parent.
                    }
                }
            }

            return length > 0 ? length - 1 : length;
        }

        [Theory]
        [InlineData(new[] { 0 }, 0)]
        [InlineData(new[] { 1 }, 0)]
        [InlineData(new[] { 1, /*D1*/1, 1 }, 0)]
        [InlineData(new[] { 1, /*D1*/1, 0 }, 0)]
        [InlineData(new[] { 1, /*D1*/0, 1 }, 0)]
        [InlineData(new[] { 1, /*D1*/1, 1, /*D2*/1, 0, 1, 1 }, 1)]
        [InlineData(new[] { 1, /*D1*/1, 1, /*D2*/1, 0, 0, 1 }, 0)]
        [InlineData(new[] { 1, /*D1*/0, 1, /*D2*/0, 0, 0, 1 }, 0)]
        [InlineData(new[] { 1, /*D1*/1, 1, /*D2*/1, 0, 0, 1, /*D3*/0, 1, 0, 0, 0, 0, 1, 1 }, 1)]
        [InlineData(new[] { 1, /*D1*/0, 1, /*D2*/0, 0, 0, 1, /*D3*/0, 0, 0, 0, 0, 0, 1, 0 }, 1)]
        [InlineData(new[] { 1, /*D1*/1, 1, /*D2*/1, 1, 0, 1, /*D3*/0, 1, 1, 0, 0, 0, 1, 1 }, 2)]
        public void LongestZigZag_Test1(int[] a, int expected)
        {
            var nodes = new Tree[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                nodes[i] = a[i] == 1 ? new Tree() : null;
            }

            for (var i = 1; i < a.Length; i++)
            {
                if (a[i] == 1)
                {
                    var parent = nodes[(i - 1) / 2];
                    if (parent != null)
                    {
                        if (i % 2 == 1)
                        {
                            parent.l = nodes[i];
                        }
                        else
                        {
                            parent.r = nodes[i];
                        }
                    }
                }
            }

            Assert.Equal(expected, solution(nodes[0]));
        }

        [Fact]
        public void LongestZigZag_Test2()
        {
            var root = new Tree();

            var r2c1 = root.l = new Tree();
            var r2c2 = root.r = new Tree();

            var r3c1 = r2c1.l = new Tree();
            var r3c2 = r2c1.r = new Tree();
            var r3c4 = r2c2.r = new Tree();

            var r4c2 = r3c1.r = new Tree();
            var r4c4 = r3c2.r = new Tree();
            var r4c7 = r3c4.l = new Tree();
            var r4c8 = r3c4.r = new Tree();

            var r5c8 = r4c4.r = new Tree();
            var r5c14 = r4c7.r = new Tree();

            Assert.Equal(2, solution(root));
        }
    }
}
