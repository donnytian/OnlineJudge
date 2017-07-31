using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Implementation
{
    //https://www.hackerrank.com/challenges/grading/problem
    public class GradingStudents
    {
        public static int[] solve(int[] grades)
        {
            // Complete this function
            if (grades == null || grades.Length == 0)
            {
                return new int[] { };
            }

            var result = new int[grades.Length];

            for (var i = 0; i < grades.Length; i++)
            {
                var g = grades[i];

                if (g < 38)
                {
                    result[i] = g;
                    continue;
                }

                var diff = 5 - g % 5;
                result[i] = diff < 3 ? g + diff : g;
            }

            return result;
        }

        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] grades = new int[n];
            for (int grades_i = 0; grades_i < n; grades_i++)
            {
                grades[grades_i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] result = solve(grades);
            Console.WriteLine(String.Join("\n", result));


        }
        */
    }
}
