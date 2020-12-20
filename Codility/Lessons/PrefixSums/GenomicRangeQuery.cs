using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.PrefixSums
{
    //https://codility.com/programmers/lessons/5-prefix_sums/genomic_range_query/
    public class GenomicRangeQuery
    {
        // A, C, G, T have impact factors as 1, 2, 3, 4
        public static int[] solution(string S, int[] P, int[] Q)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var A = new int[S.Length];
            var C = new int[S.Length];
            var G = new int[S.Length];

            for (int i = 0; i < S.Length; i++)
            {
                var isFirst = i == 0;
                A[i] = (isFirst ? 0 : A[i - 1]) + (S[i] == 'A' ? 1 : 0);
                C[i] = (isFirst ? 0 : C[i - 1]) + (S[i] == 'C' ? 1 : 0);
                G[i] = (isFirst ? 0 : G[i - 1]) + (S[i] == 'G' ? 1 : 0);
            }

            for (int i = 0; i < P.Length; i++)
            {
                var result = 0;
                if (A[Q[i]] - A[P[i]] > 0 || S[P[i]] == 'A')
                {
                    result = 1;
                }
                else if (C[Q[i]] - C[P[i]] > 0 || S[P[i]] == 'C')
                {
                    result = 2;
                }
                else if (G[Q[i]] - G[P[i]] > 0 || S[P[i]] == 'G')
                {
                    result = 3;
                }
                else
                {
                    result = 4;
                }

                P[i] = result;
            }

            return P;
        }
    }
}
