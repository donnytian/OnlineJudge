using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.BinarySearchAlgorithm
{
    //https://codility.com/programmers/lessons/14-binary_search_algorithm/nailing_planks/
    public class NailingPlanks
    {
        public int solution(int[] A, int[] B, int[] C)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var M = C.Length;
            var N = A.Length;

            var l = 0;
            var r = C.Length - 1;
            var allNailed = true;

            while (l < r || !allNailed)
            {
                if (l > r && !allNailed) // Allows to check that last item in C.
                {
                    break;
                }

                allNailed = true;
                var m = (l + r) / 2;
                var nailSums = new int[2 * M + 1];

                for (int i = 0; i <= m; i++)
                {
                    nailSums[C[i]] = 1;
                }

                for (int i = 1; i < nailSums.Length; i++)
                {
                    nailSums[i] = nailSums[i - 1] + nailSums[i];
                }

                for (int i = 0; i < N; i++)
                {
                    var startNails = nailSums[A[i] - 1];
                    var endNails = nailSums[B[i]];
                    if (endNails - startNails == 0)
                    {
                        allNailed = false;
                        break;
                    }
                }

                if (allNailed)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return allNailed ? r + 1 : -1;
        }
    }
}
