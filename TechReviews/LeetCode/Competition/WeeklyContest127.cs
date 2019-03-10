using System.Collections.Generic;

namespace lu8890.TechReviews.LeetCode.Competition
{

    public class WeeklyContest127
    {
        /*
           1005. Maximize Sum Of Array After K Negations
           Difficulty: Easy
           Given an array A of integers, we must modify the array in the following way: 
            we choose an i and replace A[i] with -A[i], and we repeat this process K times in total.  (We may choose the same index i multiple times.)

           Return the largest possible sum of the array after modifying it in this way.

           Example 1:

           Input: A = [4,2,3], K = 1
           Output: 5
           Explanation: Choose indices (1,) and A becomes [4,-2,3].
           Example 2:

           Input: A = [3,-1,0,2], K = 3
           Output: 6
           Explanation: Choose indices (1, 2, 2) and A becomes [3,1,0,2].
           Example 3:

           Input: A = [2,-3,-1,5,-4], K = 2
           Output: 13
           Explanation: Choose indices (1, 4) and A becomes [2,3,-1,5,4].
        */
        public int LargestSumAfterKNegations(int[] A, int K)
        {
            return -1;
        }

        /*
           1006. Clumsy Factorial
           Difficulty: Medium
           Normally, the factorial of a positive integer n is the product of all positive integers less than or equal to n.  For example, factorial(10) = 10 * 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1.
           We instead make a clumsy factorial: using the integers in decreasing order, we swap out the multiply operations for a fixed rotation of operations: multiply (*), divide (/), add (+) and subtract (-) in this order.
           For example, clumsy(10) = 10 * 9 / 8 + 7 - 6 * 5 / 4 + 3 - 2 * 1.  
           
           However, these operations are still applied using the usual order of operations of arithmetic: 
            we do all multiplication and division steps before any addition or subtraction steps, and multiplication and division steps are processed left to right.

           Additionally, the division that we use is floor division such that 10 * 9 / 8 equals 11.  This guarantees the result is an integer.
           Implement the clumsy function as defined above: given an integer N, it returns the clumsy factorial of N.
           
            Example 1:

            Input: 4
            Output: 7
            Explanation: 7 = 4 * 3 / 2 + 1
            Example 2:

            Input: 10
            Output: 12
            Explanation: 12 = 10 * 9 / 8 + 7 - 6 * 5 / 4 + 3 - 2 * 1
             
            Note:

            1 <= N <= 10000
            -2^31 <= answer <= 2^31 - 1  (The answer is guaranteed to fit within a 32-bit integer.)
        */
        public int Clumsy(int N)
        {
            int Counter = 1;
            var formulaArray = new List<int>();
            int sum = 0;


            if (N < 1)
                return -1;
            if (N == 0)
                return 0;
            if (N == 1)
                return 1;

            while (N >= 1)
            {
                formulaArray.Add(N);
                formulaArray.Add(Counter % 4);
                ++Counter;
                --N;
            }

            return 0;
        }

        /*
          1007. Minimum Domino Rotations For Equal Row
          Difficulty: Medium
          In a row of dominoes, A[i] and B[i] represent the top and bottom halves of the i-th domino.  (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
          We may rotate the i-th domino, so that A[i] and B[i] swap values.
          Return the minimum number of rotations so that all the values in A are the same, or all the values in B are the same.
          If it cannot be done, return -1.

          Example 1:
          
            Input: A = [2,1,2,4,2,2], B = [5,2,6,2,3,2]
            Output: 2
            Explanation: 
            The first figure represents the dominoes as given by A and B: before we do any rotations.
            If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, as indicated by the second figure.

         Example 2:

            Input: A = [3,5,1,2,3], B = [3,6,3,3,4]
            Output: -1
            Explanation: 
            In this case, it is not possible to rotate the dominoes to make one row of values equal.

         Note:

            1 <= A[i], B[i] <= 6
            2 <= A.length == B.length <= 20000
         */
        public int MinDominoRotations(int[] A, int[] B)
        {
            return -1;
        }


        /*
         1008. Construct Binary Search Tree from Preorder Traversal
         Difficulty: Medium
         Return the root node of a binary search tree that matches the given preorder traversal.
         (Recall that a binary search tree is a binary tree where for every node, any descendant of node.left has a value < node.val, and any descendant of node.right has a value > node.val.  
         Also recall that a preorder traversal displays the value of the node first, then traverses node.left, then traverses node.right.)

        Example 1:

            Input: [8,5,1,7,10,12]
            Output: [8,5,10,1,7,null,12]

        Note: 

            1 <= preorder.length <= 100
            The values of preorder are distinc

             Definition for a binary tree node.
             public class TreeNode {
                 public int val;
                 public TreeNode left;
                 public TreeNode right;
                 public TreeNode(int x) { val = x; }
             }
        */
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null)
                return null;
            if (preorder.Length == 1)
                return new TreeNode(preorder[0]);
            else
            {
                foreach (var i in preorder)
                {

                }
            }

            return null;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
