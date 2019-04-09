using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.LeetCode.Competition
{
    public class WeeklyContest130
    {
        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-130/problems/binary-prefix-divisible-by-5/
        /// Attemmpted three different solutions, but always break when A.Length = 33 and beyond.
        /// Each instance, getting the 2's compliment because input value is greater than Int32.MaxValue 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
            IList<bool> result = new List<bool>();
            
            if ((A == null) || (A.Length == 0))
                return result;

            if (A.Length > 30000)
                return result;

            var binaryBuilder = new StringBuilder();

            foreach (var bit in A)
            {
                if ((bit == 0) || (bit == 1))
                {
                    binaryBuilder.Append(bit);
                    var conv = ConvertBinaryToInt(binaryBuilder.ToString());
                    result.Add( (Int64)conv % 5 == 0);
                    Console.WriteLine(conv + "\t" + binaryBuilder.ToString());
                }
                else
                {
                    return null;
                }
            }

            return result;
        }

        private static double ConvertBinaryToInt(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var bitChar = input.ToCharArray();
            var counter = 0;
            double result = 0;

            for (var i = bitChar.Length - 1; i > -1; i--)
            {
                if (bitChar[i] == '1')
                    result += Math.Pow(2, counter);

                ++counter;
            }

            return Math.Round(result, 15);
        }

        /// <summary>
        /// sum inside foreach loop would go out of int64.maxvalue range
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_2(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
            IList<bool> result = new List<bool>();

            if ((A == null) || (A.Length == 0))
                return result;

            if (A.Length > 30000)
                return result;

            Int64 sum = 0;

            foreach (var bit in A)
            {
                sum = (sum << 1) + bit;
                result.Add(sum % 5 == 0);

                Console.WriteLine("bit: {0} \t sum:{1}", bit, sum);
            }

            return result;
        }

        /// <summary>
        /// sum inside foreach loop would go out of int64.maxvalue range
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_3(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
            IList<bool> result = new List<bool>();

            if ((A == null) || (A.Length == 0))
                return result;

            if (A.Length > 30000)
                return result;

            Int64 sum = 0;

            foreach (var bit in A)
            {
                sum = ((sum * 2) + bit);
                result.Add(sum % 5 == 0);
                Console.WriteLine("bit: {0} \t sum:{1}", bit, sum);
            }

            return result;
        }

        /// <summary>
        /// Runtime: 268 ms, faster than 40.00% of C# online submissions for Binary Prefix Divisible By 5.
        /// Memory Usage: 33 MB, less than 100.00% of C# online submissions for Binary Prefix Divisible By 5.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_4(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
            IList<bool> result = new List<bool>();

            if ((A == null) || (A.Length == 0))
                return result;

            if (A.Length > 30000)
                return result;

            int sum = 0;

            foreach (var bit in A)
            {
                sum = ((sum * 2) + bit) % 5;
                result.Add(sum % 5 == 0);
                Console.WriteLine("bit: {0} \t sum:{1}", bit, sum);
            }

            return result;
        }

        /// <summary>
        /// Runtime: 264 ms, faster than 77.14% of C# online submissions for Binary Prefix Divisible By 5.
        /// Memory Usage: 33 MB, less than 100.00% of C# online submissions for Binary Prefix Divisible By 5.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public IList<bool> PrefixesDivBy5_5(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
            IList<bool> result = new List<bool>();

            if ((A == null) || (A.Length == 0))
                return result;

            if (A.Length > 30000)
                return result;

            int sum = 0;

            foreach (var bit in A)
            {
                sum = ((sum << 1) + bit) % 5;
                result.Add(sum % 5 == 0);

                Console.WriteLine("bit: {0} \t sum:{1}", bit, sum);
            }

            return result;
        }
    }

}
