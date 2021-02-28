using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCode.Problems.Algorithms
{
    /*
     * You are given coins of different denominations and a total amount of money amount.
     * Write a function to compute the fewest number of coins that you need to make up that amount.
     * If that amount of money cannot be made up by any combination of the coins, return -1.
     * You may assume that you have an infinite number of each kind of coin.
     */
    //https://leetcode.com/problems/coin-change/
    public class CoinChange
    {
        private const int Invalid = -1;
        public int Change(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0 || amount < 0)
            {
                return Invalid;
            }

            var fx = new int[amount + 1];

            for (var i = 1; i < fx.Length; i++)
            {
                fx[i] = int.MaxValue;
            }

            for (var i = 0; i < fx.Length; i++)
            {
                for (var j = 0; j < coins.Length; j++)
                {
                    var coin = coins[j];
                    var index = i - coin;
                    if (index >= 0 && fx[index] != int.MaxValue)
                    {
                        fx[i] = Math.Min(fx[i], fx[index] + 1);
                    }
                }
            }

            var result = fx[amount];
            return result == int.MaxValue ? Invalid : result;
        }
    }

    public class CoinChangeTests
    {
        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(-1, 3, 2)]
        [InlineData(3, 11, 1, 2, 5)]
        public void CoinChange(int expected, int amount, params int[] coins)
        {
            var result = new CoinChange().Change(coins, amount);
            
            Assert.Equal(expected, result);
        }
    }
}
