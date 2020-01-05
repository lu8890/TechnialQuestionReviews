using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.InterviewQuestions
{
    /// <summary>
    /// https://www.geeksforgeeks.org/convert-given-time-words/
    /// 
    /// 6:00 six o'clock
    /// 6:10 ten minutes past six
    /// 6:15 quarter past six
    /// 6:30 half past six
    /// 6:45 quarter to seven
    /// 6:47 thirteen minutes to seven
    /// 
    /// Examples:
    /// Input : h = 5, m = 0
    /// Output : five o' clock
    ///
    /// Input : h = 6, m = 24
    /// Output : twenty four minutes past six
    /// </summary>
    public class McgHealth
    {
        private Dictionary<int, string> NumToStringMap { get; set; }

        public McgHealth()
        {
            SetupNumToStringMap();
        }

        private void SetupNumToStringMap()
        {
            NumToStringMap = new Dictionary<int, string>()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "quater" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" },
                { 20, "twenty" },
                { 21, "twenty-one" },
                { 22, "twenty-two" },
                { 23, "twenty-three" },
                { 24, "twenty-four" },
                { 25, "twenty-five" },
                { 26, "twenty-six" },
                { 27, "twenty-seven" },
                { 28, "twenty-eight" },
                { 29, "twenty-nine" },
                { 30, "half" }
            };
        }

        public string PrintTimeInWords(int hour, int min)
        {
            if (((hour < 0) || (hour > 12)) || ((min < 0) || (min > 60)))
                throw new ArgumentException();

            var Output = string.Empty;
            if (min == 0)
            {
                Output = $"{hour}:{min} {GetTimeInString(hour)} o'clock";
            }
            else if (min <= 30)
            {
                Output = $"{hour}:{min} {GetTimeInString(min)} past {GetTimeInString(hour)}";
            }
            else
            {
                Output = $"{hour}:{min} {GetTimeInString(min)} to {GetTimeInString(++hour)}";
            }

            return Output;
        }

        private string GetTimeInString(int num)
        {
            if ((num < 0) || (num > 60))
                throw new ArgumentException();

            var targetMin = num > 30
                            ? 60 - num
                            : num;

            var result = NumToStringMap.ContainsKey(targetMin)
                      ? NumToStringMap[targetMin]
                      : string.Empty;

            if (string.IsNullOrEmpty(result))
                throw new ArgumentException();

            return result;
        }
    }
}
