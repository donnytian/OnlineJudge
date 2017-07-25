﻿using System;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/compare-the-triplets
    public class CompareTriplets
    {
        public static int[] solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {
            var a = new[] { a0, a1, a2 };
            var b = new[] { b0, b1, b2 };
            var pointsA = 0;
            var pointsB = 0;

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    pointsA++;
                }
                else if (a[i] < b[i])
                {
                    pointsB++;
                }
            }

            return new[] { pointsA, pointsB };
        }

        /*
        static void Main(String[] args)
        {
            string[] tokens_a0 = Console.ReadLine().Split(' ');
            int a0 = Convert.ToInt32(tokens_a0[0]);
            int a1 = Convert.ToInt32(tokens_a0[1]);
            int a2 = Convert.ToInt32(tokens_a0[2]);
            string[] tokens_b0 = Console.ReadLine().Split(' ');
            int b0 = Convert.ToInt32(tokens_b0[0]);
            int b1 = Convert.ToInt32(tokens_b0[1]);
            int b2 = Convert.ToInt32(tokens_b0[2]);
            int[] result = solve(a0, a1, a2, b0, b1, b2);
            Console.WriteLine(String.Join(" ", result));
        }
        */
    }
}
