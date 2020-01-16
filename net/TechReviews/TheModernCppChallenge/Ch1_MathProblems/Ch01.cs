using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.TheModernCppChallenge.Ch1_MathProblems
{
    public class Ch01
    {
        /// <summary>
        /// 01. Sum of naturals divisible by 3 and 5
        /// Write a program that calculates and prints the sum of all the natural numbers divisible 
        /// by either 3 or 5, up to a given limit entered by the user
        /// 
        /// Note: Natural numbers == positibe integers
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int SumOfNaturalNumsDivisibleBy3And5(int limit)
        {
            if (limit > int.MaxValue)
                throw new ArgumentOutOfRangeException();

            if (limit == 0)
                return 0;

            var ResultSum = 0;

            for(int i=1; i <= limit; i++)
            {
                if (((i % 3) == 0) || ((i % 5) == 0))
                {
                    Console.WriteLine($"Target Number Found: {i}");
                    ResultSum += i;
                }
            }

            return ResultSum;
        }

        /// <summary>
        /// 02. Greatest common divisor
        /// Write a program that, given two positive integers, will calculate and print the greatest common
        /// divisor of the two
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int FindGreatestCommonDivisor(int x, int y)
        {
            if((x > int.MaxValue) || (y > int.MaxValue))
                throw new ArgumentOutOfRangeException();

            if ((x == 0) || (y == 0))
                throw new ArgumentOutOfRangeException();

            var SmallOfTheTwo = (x <= y)
                ? Math.Abs(x)
                : Math.Abs(y);

            var ResultCol = new List<int>();

            for(int i=1; i<= SmallOfTheTwo; i++)
            {
                if (((x % i) == 0) && ((y % i) == 0))
                    ResultCol.Add(i);
            }

            ResultCol = ResultCol.OrderByDescending(arg=>arg).ToList();

            return ResultCol.Any()
                    ? ResultCol.FirstOrDefault()
                    : -1;
        }

        /// <summary>
        /// 03. Least common multiple
        /// Write a program that will, given two or more positive integers, clculate and print the 
        /// least common multiple of them all.
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public int FindLeastCommonMultiple(List<int> inputs)
        {
            
            if ((inputs == null) || (!inputs.Any()))
                return 0;

            if (inputs.Any(x => x <= 0))
                throw new ArgumentOutOfRangeException();

            if (inputs.Any(x => x > int.MaxValue))
                throw new ArgumentOutOfRangeException();

            if (inputs.Count == 1)
                return 1;

            var counter = 2;
            var MatchingCounter = 0;

            while (true)
            {
                inputs.ForEach(x =>
                { 
                    if((counter % x) == 0)
                    {
                        ++MatchingCounter;
                    }
                });

                if (MatchingCounter == inputs.Count)
                    return counter;

                MatchingCounter = 0;
                ++counter;
            }
        }

        /// <summary>
        /// 04. Largest prime smaller than given number
        /// Write a program that computes and prints the largest prime number that is smaller than a number 
        /// provided by the user, which must be a positive integer
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int? LargestPrimeNumber(int limit)
        {
            if ((limit > int.MaxValue) || (limit < 0))
                throw new ArgumentOutOfRangeException();

            if (limit <= 1)
                return null;

            if (limit <= 3)
                return limit;

            var PrimeCounter = limit;

            while(PrimeCounter > 0)
            {
                if (IsPrime(PrimeCounter))
                    return PrimeCounter;

                --PrimeCounter;
            }

            throw new Exception("No Solution Found");
        }

        private bool IsPrime(int input)
        {
            var counter = 1;

            for(int i=input; i >1; i--)
            {
                if ((input % i) == 0)
                    ++counter;
            }

            return (counter == 2)
                    ? true
                    : false;
        }

        /// <summary>
        /// 05. Sexy prime pairs
        /// Write a program that prints all the sexy prime pairs up to a limit entered by
        /// the user.
        /// 
        /// Note: sexy prime pair = two prime numbers that diff by 6
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetSexyPrimePairs(int limit)
        {

            if ((limit > int.MaxValue) || (limit < 0))
                throw new ArgumentOutOfRangeException();

            var result = new Dictionary<int, int>();

            for(int i=2; i <=limit; i++)
            {
                if ((i + 6) <= limit)
                {
                    if (IsPrime(i) && IsPrime(i + 6))
                        result.Add(i, i + 6);
                }
            }

            return result;
        }
    }
}
