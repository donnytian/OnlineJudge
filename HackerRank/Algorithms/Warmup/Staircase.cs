using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/staircase
    public class Staircase
    {
        public static void resolve(int n)
        {
            if (n <= 0)
            {
                return;
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(i + j >= n - 1 ? "#" : " ");
                }

                Console.Write(Environment.NewLine);
            }
        }


        /*
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            resolve(n);
        }
        */
    }
}
