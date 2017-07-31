using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessions.Arrays
{
    //https://codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/
    public class OddOccurrencesInArray
    {
        public static int solution(int[] A)
        {
            var result = 0;

            for (var i = 0; i < A.Length; i++)
            {
                result ^= A[i];
            }

            return result;
        }
    }
}
