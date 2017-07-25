using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCode.Problems.Algorithms
{
    //https://leetcode.com/problems/median-of-two-sorted-arrays
    //
    // Then median = (max(left_part) + min(right_part))/2
    // Binary Search
    public class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double median = 0;
            nums1 = nums1 ?? new int[] { };
            nums2 = nums2 ?? new int[] { };
            var m = nums1.Length;
            var n = nums2.Length;

            if (m + n == 0)
            {
                throw new InvalidOperationException();
            }

            // Makes sure m >= n.
            if (n > m)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            if (n == 0)
            {
                // Returns the median of the nums1 array.
                return ((double)nums1[(m - 1) / 2] + nums1[m / 2]) / 2;
            }

            var mod = (m + n) % 2;
            var half = (m + n) / 2;
            var imin = 0;
            var imax = m;

            // Using binary search to locate i for nums1 and j for nums2 as the starting indeces of the right part of the merged array.
            while (imin <= imax)
            {
                var i = (imin + imax) / 2;
                var j = half - i;

                var l1 = i - 1 >= 0 ? nums1[i - 1] : int.MinValue;
                var r1 = i < m ? nums1[i] : int.MaxValue;
                var l2 = j - 1 >= 0 ? (j - 1 < n ? nums2[j - 1] : int.MaxValue) : int.MinValue;
                var r2 = j < n ? (j >= 0 ? nums2[j] : int.MinValue) : int.MaxValue;

                // i is too big.
                if (l1 > r2)
                {
                    imax = i - 1;
                }
                // i is too small.
                else if (l2 > r1)
                {
                    imin = i + 1;
                }
                // i is perfectly match
                else
                {
                    median = mod == 0 ? (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0 : Math.Min(r1, r2);
                    break;
                }
            }

            return median;
        }
    }

    public class MedianOfTwoSortedArrays_Tests
    {
        [Theory]
        [InlineData(new int[] { }, new[] { 1 }, 1.0)]
        [InlineData(new[] { 1, 3 }, new int[] { }, 2.0)]
        [InlineData(new int[] { }, new[] { 1, 3 }, 2.0)]
        [InlineData(new[] { 1, 3 }, new[] { 2 }, 2.0)]
        [InlineData(new[] { 2 }, new[] { 1, 3 }, 2.0)]
        [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
        [InlineData(new[] { 1, 3, 3, 4, 5 }, new[] { 0, 2, 9 }, 3.0)]
        [InlineData(new[] { 1 }, new[] { 2, 3, 4, 5 }, 3.0)]
        [InlineData(new[] { 4 }, new[] { 1, 2, 3, 5 , 6 }, 3.5)]
        [InlineData(new[] { 1 }, new[] { 2, 3, 4, 5, 6, 7 }, 4.0)]
        public void MedianOfTwoSortedArrays_Test(int[] a, int[] b, double median)
        {
            Assert.Equal(median, MedianOfTwoSortedArrays.FindMedianSortedArrays(a, b));
        }
    }
}
