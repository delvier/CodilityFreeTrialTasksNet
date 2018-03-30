using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Colidity_Free_Trial_Tasks
{
    [TestClass]
    public class MissingElement_N
    {
        [TestMethod]
        public void Test_Method_Simple()
        {
            var input = new int[] { 2, 3, 1, 5 };
            var solution = new Solution();
            Assert.AreEqual(4, solution.solution(input));
        }

        [TestMethod]
        public void TestMethod_Missing_First()
        {
            var input = new int[] { 2, 3 };
            var solution = new Solution();
            Assert.AreEqual(1, solution.solution(input));
        }

        [TestMethod]
        public void TestMethod_Misiing_Last()
        {
            var input = new int[] { 1, 2 };
            var solution = new Solution();
            Assert.AreEqual(3, solution.solution(input));
        }

        [TestMethod]
        public void TestMethod_Empty()
        {
            var input = new int[] { };
            var solution = new Solution();
            Assert.AreEqual(1, solution.solution(input));
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            var result = A.OrderBy(e => e).ToList();
            
            if (result.Count == 0)
            {
                return 1;
            }

            if (result.First() != 1) // first element missing. each collection should start at 1.
            {
                return 1;
            }

            if (result.Last() == result.Count) // last element is missing.
            {
                return result.Count + 1;
            }
            
            for (int i = 0; i < result.Count - 1; i++)
            {
                if(result[i] + 1 != result[i+1])
                {
                    return result[i] + 1;
                }
            }
            return -1;
        }
    }

}
