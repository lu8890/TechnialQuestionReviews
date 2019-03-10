namespace lu8890.TechReviews.InterviewQuestions
{
    public class Panopto
    {
        /// <summary>
        /*
         [1,2,3] =>
        
        [1,
         2,
         3]

        [0,0] => [0,0]
        [0,1] => [1,0]
        [0,2] => [2,0]
       
        ==================================
        [
         [1,2,3]
         [4,5,6]
        ]  =>

        [
         [4,1]
         [5,2]
         [6,3]
        ]

        [0,0] => [0,1]
        [0,1] => [1,1]
        [0,2] => [2,1]

        [1,0] => [0,0]
        [1,1] => [1,0]
        [1,2] => [2,0]

        ==================================
        [1,2,3]
        [4,5,6]
        [7,8,9]
        ==>
        7,4,1
        8,5,2
        9,6,3

        [0,0] => [0,2]
        [0,1] => [1,2]
        [0,2] => [2,2]

        [1,0] => [0,1]
        [1,1] => [1,1]
        [1,2] => [2,1]

        [2,0] => [0,0]
        [2,1] => [1,0]
        [2,2] => [2,0]
        */
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public int[,] RotateMatrixBy90Degress(int[,] inputs)
        {
            if (inputs.Length == 0)
                return null;

            var xCoordinates = inputs.GetLongLength(0);
            var yCoordinates = inputs.GetLongLength(1);
            var reversedCounter = xCoordinates;

            int[,] result = new int[yCoordinates, xCoordinates];

            for (var i = 0; i < xCoordinates; i++)
            {
                --reversedCounter;
                for (var j = 0; j < yCoordinates; j++)
                {
                    result[j,reversedCounter] = inputs[i, j];
                }
            }
           
            return result;
        }
    }
}
