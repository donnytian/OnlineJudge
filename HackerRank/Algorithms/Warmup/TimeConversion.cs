using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerRank.Algorithms.Warmup
{
    //https://www.hackerrank.com/challenges/time-conversion/problem
    public class TimeConversion
    {
        // Sample input
        // 07:05:45PM
        //
        // Sample output
        // 19:05:45
        public static string timeConversion(string s)
        {
            // Complete this function
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            s = s.Trim();

            if (s.Length < "1:1:1AM".Length)
            {
                return string.Empty;
            }

            var time = s.Substring(0, s.Length - 2);
            var amPm = s.Substring(s.Length - 2, 2).ToUpper();
            var isAm = amPm == "AM";
            var arr = time.Split(':');

            if (arr.Length != 3)
            {
                return string.Empty;
            }

            var hour = -1;
            var minute = -1;
            var second = -1;

            int.TryParse(arr[0], out hour);
            int.TryParse(arr[1], out minute);
            int.TryParse(arr[2], out second);

            if (hour < 0 || minute < 0 || second < 0)
            {
                return string.Empty;
            }

            hour = !isAm && hour == 12 ? 0 : hour;
            hour = isAm ? hour : hour + 12;
            hour = hour >= 24 ? hour - 24 : hour;
            hour = isAm && hour == 12 ? 0 : hour;

            return $"{hour:00}:{minute:00}:{second:00}";
        }

        /*
        static void Main(String[] args)
        {
            string s = Console.ReadLine();
            string result = timeConversion(s);
            Console.WriteLine(result);
        }
        */
    }

    public class TimeConversion_Tests
    {
        [Theory]
        [InlineData("12:40:22AM", "00:40:22")]
        [InlineData("12:01:22PM", "12:01:22")]
        public void TimeConversion_Test(string s, string expected)
        {
            Assert.Equal(expected, TimeConversion.timeConversion(s));
        }
    }
}
