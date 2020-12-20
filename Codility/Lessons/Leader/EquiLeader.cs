using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Codility.Lessions.Leader
{
    //https://codility.com/programmers/lessons/8-leader/equi_leader/
    public class EquiLeader
    {
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
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
            }

            if (candidateCount <= half)
            {
                return 0;
            }

            var equiLeaderCount = 0;
            var leftDominatorCount = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == candidate)
                {
                    leftDominatorCount++;
                }

                var righDominatorCount = candidateCount - leftDominatorCount;
                if (leftDominatorCount > (i + 1) / 2 && righDominatorCount > (A.Length - i - 1) / 2)
                {
                    equiLeaderCount++;
                }
            }

            return equiLeaderCount;
        }
    }

    public class EquiLeader_Tests
    {
        [Theory]
        [InlineData(new[] { 4 }, 0)]
        [InlineData(new[] { 4, 5 }, 0)]
        [InlineData(new[] { 4, 4 }, 1)]
        [InlineData(new[] { 4, 4, 4 }, 2)]
        [InlineData(new[] { 4, 5, 4 }, 0)]
        [InlineData(new[] { 4, 4, 5 }, 0)]
        [InlineData(new[] { 4, 3, 4, 4, 4, 2 }, 2)]
        [InlineData(new[] { 4, 3, 4, 3, 4, 3, 4, 4 }, 4)]
        [InlineData(new[] { 3, 3, 3, 4, 4, 3, 4, 4, 3, 4, 4, 3, 4, 4 }, 2)]
        public void EquiLeader_Test(int[] a, int expected)
        {
            Assert.Equal(expected, EquiLeader.solution(a));
        }
    }
}
