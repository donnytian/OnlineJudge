using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/longest-palindromic-substring
    public class LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length <= 1)
            {
                return s;
            }

            var start = 0;
            var length = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var lenOdd = GetExtendedLength(s, i, i);

                if (lenOdd > length)
                {
                    start = i - lenOdd / 2;
                    length = lenOdd;
                }

                var lenEven = GetExtendedLength(s, i, i + 1);

                if (lenEven > length)
                {
                    start = i - lenEven / 2 + 1;
                    length = lenEven;
                }
            }

            return s.Substring(start, length);
        }

        private static int GetExtendedLength(string s, int l, int r)
        {
            var len = l == r ? -1 : 0;

            while (l >= 0 && r < s.Length)
            {
                if (s[l] == s[r])
                {
                    len += 2;
                    l--;
                    r++;
                }
                else
                {
                    break;
                }
            }

            return len;
        }
    }

    public class LongestPalindromicSubstring_Tests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("aa", "aa")]
        [InlineData("aaa", "aaa")]
        [InlineData("aaaa", "aaaa")]
        [InlineData("babad", "bab")]
        [InlineData("abcde", "a")]
        [InlineData("abcdeeeefeeee", "eeeefeeee")]
        [InlineData("abcdefghiihgfeee", "efghiihgfe")]
        public void LongestPalindromicSubstring_Test(string s, string result)
        {
            Assert.Equal(result, LongestPalindromicSubstring.LongestPalindrome(s));
        }
    }
}
