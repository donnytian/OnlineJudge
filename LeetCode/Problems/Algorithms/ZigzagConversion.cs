using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/zigzag-conversion/
    public class ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrWhiteSpace(s) || numRows <= 1)
            {
                return s;
            }

            var matrix = new List<char>[numRows];

            for (var i = 0; i < numRows; i++)
            {
                matrix[i] = new List<char>();
            }

            var increase = true;
            var y = 0;
            foreach (var character in s)
            {
                matrix[y].Add(character);

                if (increase)
                {
                    var tempY = y + 1;

                    if (tempY >= numRows)
                    {
                        tempY = y > 0 ? y - 1 : 0;
                        increase = false;
                    }

                    y = tempY;
                }
                else
                {
                    var tempY = y - 1;

                    if (tempY < 0)
                    {
                        tempY = y + 1 < numRows ? y + 1 : y;
                        increase = true;
                    }

                    y = tempY;
                }
            }

            return new string(matrix.SelectMany(x => x).ToArray());
        }
    }

    public class ZigzagConversionTests
    {
        [Theory]
        [InlineData("AB", 1, "AB")]
        [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
        [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
        public void ZigzagConversion(string s, int numRows, string expected)
        {
            var result = new ZigzagConversion().Convert(s, numRows);
            
            Assert.Equal(expected, result);
        }
    }
}
