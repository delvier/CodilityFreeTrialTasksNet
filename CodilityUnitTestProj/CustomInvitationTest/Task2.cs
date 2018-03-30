using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks.CustomInvitationTest
{
    [TestClass]
    public class Task2
    {
        private Task2Solution _sut;

        public Task2()
        {
            _sut = new Task2Solution();
        }

        [TestMethod]
        public void Task2_Test_Quasi_Constant_3()
        {
            var inputArray = new int[] { 6, 10, 6, 9, 7, 8 };
            var result = _sut.solution(inputArray);
            Assert.AreEqual(3, result); // 6,6,7
        }

        [TestMethod]
        public void Task2_Test_B_6677()
        {
            var inputArray = new int[] { 6, 6, 7, 7, 8, 10 };
            var result = _sut.solution(inputArray);
            Assert.AreEqual(4, result); // 6 6 7 7
        }

        [TestMethod]
        public void Task2_Test_B_Fool_Me_6677()
        {
            var inputArray = new int[] { 6, 7, 7, 8, 8, 10 };
            var result = _sut.solution(inputArray);
            Assert.AreEqual(4, result); // 7 7 8 8
        }

        [TestMethod]
        public void Task2_Test_B_Empty()
        {
            var inputArray = new int[] { };
            var result = _sut.solution(inputArray);
            Assert.AreEqual(0, result); // 6 6 7 7
        }
    }

    public class Task2Solution
    {
        public int solution(int[] A)
        {
            var orderedArray = A.OrderBy(e => e).ToArray();

            var subsequenceArray = new List<int>();
            var rememberSubsequenceLengths = new List<int>();
            var indexToStore = 0;
            for (int i = 0; i < orderedArray.Length; i++)
            {
                var curElement = orderedArray[i];

                if (subsequenceArray.Count > 0 &&
                    Math.Abs(subsequenceArray.Min() - curElement) >= 1 && 
                    indexToStore == 0) // amplitude rise by one => remember
                {
                    indexToStore = i;
                }

                if (subsequenceArray.Count > 0 &&
                    Math.Abs(subsequenceArray.Min() - curElement) > 1) // amp > 1
                {
                    rememberSubsequenceLengths.Add(subsequenceArray.Count); // remember length of subsequence
                    subsequenceArray.Clear();

                    if (indexToStore != orderedArray.Length - 1)
                    {
                        i = indexToStore - 1; // shifting index to where amplitude rise by.1
                        indexToStore = 0;
                    }
                    continue;
                }
                subsequenceArray.Add(curElement);
            }
            if (rememberSubsequenceLengths.Count == 0) return 0;
            return rememberSubsequenceLengths.Max();
        }
    }
}