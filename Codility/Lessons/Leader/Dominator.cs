using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Leader
{
    //https://codility.com/programmers/lessons/8-leader/dominator/
    public class Dominator
    {
        // Simulate a stack since the expected space complexicity is O(1).
        // removing pair of different elements from the sequence, 
        // after removing all pairs of different elements, at this point we end up with a stack containing elements with the same values.
        // This value is the only possible candidate to be the leader
        public static int solution(int[] A)
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

            var half = A.Length / 2;
            var candidateIndex = 0;
            var candidateCount = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[candidateIndex] == A[i])
                {
                    candidateCount++; // Simulates a push.
                }
                else
                {
                    candidateCount--; // Simulates a pop. Removing a pair of different elements.

                    if (candidateCount == 0)
                    {
                        candidateCount++;
                        candidateIndex = i;
                    }
                }
            }

            // Verify if the found number is a dominator.
            candidateCount = 0;
            var candidate = A[candidateIndex];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    candidateCount++;
                }

                if (candidateCount > half)
                {
                    return candidateIndex;
                }
            }

            return -1;
        }
    }
}
