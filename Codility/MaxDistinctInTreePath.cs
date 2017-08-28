using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;
    };

    public class MaxDistinctInTreePath
    {
        public static int solution(Tree T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            var result = 0;
            if (T == null)
            {
                return result;
            }

            var set = new System.Collections.Generic.HashSet<int>();

            return GetMax(T, set, 0);
        }

        private static int GetMax(Tree node, System.Collections.Generic.HashSet<int> set, int max)
        {
            if (node == null)
            {
                return max;
            }

            var existed = set.Contains(node.x);

            if (!existed)
            {
                set.Add(node.x);
                max = set.Count > max ? set.Count : max;
            }

            var lMax = GetMax(node.l, set, max);
            var rMax = GetMax(node.r, set, max);

            max = lMax > rMax ? lMax : rMax;

            if (!existed)
            {
                set.Remove(node.x);
            }

            return max;
        }
    }
}
