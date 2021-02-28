using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/regular-expression-matching/
    /// <summary>
    /// Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
    /// '.' Matches any single character.​​​​
    /// '*' Matches zero or more of the preceding element.(repeat 0 or more times)
    /// The matching should cover the entire input string (not partial).
    /// </summary>
    public class RegularExpressionMatching
    {
        public bool IsMatch(string s, string p)
        {
            if (string.IsNullOrWhiteSpace(p))
            {
                return false;
            }

            var dp = new bool[s.Length + 1, p.Length + 1];
            // "" and "" always match;
            dp[0, 0] = true;

            // if p is "", then if s is not empty, it won't match, default false;
            // is s is "", only this kind of pattern would match 'x*x*x*', the length should be even and every even position should be '*'
            for (var j = 2; j <= p.Length; j += 2)
            {
                dp[0, j] = dp[0, j - 2] && p[j - 1] == '*';
            }

            for (var i = 1; i <= s.Length; i++)
            {
                for (var j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] == '.' || p[j - 1] == s[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        var repeatZeroTimeMatch = dp[i, j - 2];
                        var repeatNonZeroTimeMatch = (s[i - 1] == p[j - 2] || p[j - 2] == '.') && dp[i - 1, j];
                        dp[i, j] = repeatZeroTimeMatch || repeatNonZeroTimeMatch;
                    }
                }
            }

            return dp[s.Length, p.Length];
        }
    }

    public class RegularExpressionMatchingTests
    {
        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("aaa", "a*a", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "cmis*is*p*.", false)]
        public void RegularExpressionMatching(string s, string p, bool expected)
        {
            var result = new RegularExpressionMatching().IsMatch(s, p);
            
            Assert.Equal(expected, result);
        }
    }
}
