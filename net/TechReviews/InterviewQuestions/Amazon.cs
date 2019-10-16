using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lu8890.TechReviews.InterviewQuestions
{
    public class Amazon
    {
        /// <summary>
        /// Given an array of integers.  Return a boolean indicating if it contains lengths of a triangle
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public bool HasATriangle(int[] inputArray)
        {
            if (inputArray.Length < 3)
                return false;
            inputArray = inputArray.OrderBy(x => x).ToArray();
            for (var i = 0; i < inputArray.Length; i++)
            {
                for (var j = i + 1; j < inputArray.Length; j++)
                {
                    for (var k = j + 1; k < inputArray.Length; k++)
                    {
                        if (inputArray[k] <= inputArray[i] + inputArray[j])
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
