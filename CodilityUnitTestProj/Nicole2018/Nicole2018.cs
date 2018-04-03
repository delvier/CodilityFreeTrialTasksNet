using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks.Nicole2018
{
    //On the sequence of logical values(true or false) we can build up an OR-Pascal-triangle structure.
    //Instead of summing the values, as in a standard Pascal-triangle, we will combine them using the OR function.
    //That means that the lowest row is simply the input sequence, and every entry in each subsequent row is the OR of the two elements below it.
    //For example, the OR-Pascal-triangle built on the array[true, false, false, true, false] is as follows:


    //Your job is to count the number of nodes in the OR-Pascal-triangle that contain the value true (this number is 11 for the animation above).

    //Write a function:

    //class Solution { public int solution(bool[] P); }

    //that, given an array P of N Booleans, returns the number of fields in the OR-Pascal-triangle built on P
    //that contain the value true. If the result is greater than 1,000,000,000, your function should return 1,000,000,000.

    //Given P = [true, false, false, true, false], the function should return 11, as explained above.

    //Given P = [true, false, false, true], the function should return 7, as can be seen in the animation below.

    //Assume that:

    //N is an integer within the range[1..100, 000].
    //Complexity:

    //expected worst-case time complexity is O(N);
    //expected worst-case space complexity is O(1), beyond input storage(not counting the storage required for input arguments).

    public class Nicole2018Solution
    {
        public double Solution(bool[] P)
        {
            if (P.Length == 0)
            {
                return 0;
            }

            long dotCounter = 0;
            long iterationNumber = P.Length;
            for (int i = 0; i < iterationNumber; i++)
            {
                var currentLevelDotCount = P.Count(e => e);
                if (currentLevelDotCount == P.Length)
                {
                    double filledDot = (double)(1 + (P.Length+1)) * (P.Length+1) / 2; // Sn = (a1+an)*n/2
                    return dotCounter + filledDot;
                }

                dotCounter += currentLevelDotCount;

                var nextLevelArray = new List<bool>();
                for (int j = 0; j < P.Length - 1; j++)
                {
                    var result = GetNextLevelElement(P, j);
                    nextLevelArray.Add(result);
                }
                P = nextLevelArray.ToArray();
            }

            return dotCounter;
        }

        private bool GetNextLevelElement(bool[] P, int i)
        {
            if (i + 1 >= P.Length) // is last element
            {
                return false;
            }
            else
            {
                if (P[i] || P[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }

    [TestClass]
    public class Nicole2018
    {
        [TestMethod]
        public void Nicole2018__When_5_Elements_Array_TTTTT__Expected_11_Leafs()
        {
            var inputArray = new bool[] { true, true, true, true, true};
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Nicole2018__When_5_Elements_Array_TFFTF__Expected_11_Leafs()
        {
            var inputArray = new bool[] { true, false, false, true, false };
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Nicole2018__When_4_Elements_Array_TFFT__Expected_7_Leafs()
        {
            var inputArray = new bool[] { true, false, false, true };
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Nicole2018__When_Empty_Array__Expected_0()
        {
            var inputArray = new bool[] { };
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Nicole2018__When_Single_True_Element_Array__Expected_1()
        {
            var inputArray = new bool[] { true };
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Nicole2018__When_Single_False_Element_Array__Expected_0()
        {
            var inputArray = new bool[] { false };
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Nicole2018__When_Big_True_Array__Expected_Time_Below_100ms()
        {
            var maxElements = 100 * 1000;
            var inputArray = Enumerable.Repeat(true, maxElements).ToArray();
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(5000150001, result);
        }

        [TestMethod]
        public void Nicole2018__When_Big_True_Array_With_One_False__Expected_Time_Below_100ms()
        {
            var maxElements = 100 * 1000;
            var inputArray = Enumerable.Repeat(true, maxElements).ToArray();
            inputArray[maxElements - 2] = false;
            var nicoleSolution = new Nicole2018Solution();
            var result = nicoleSolution.Solution(inputArray);
            Assert.AreEqual(5000150001 - 1, result);
        }
    }
}