using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks.CustomInvitationTest
{
    [TestClass]
    public class Task3
    {
        private Task3Solution _sut;

        public Task3()
        {
            _sut = new Task3Solution();
        }
        [TestMethod]
        public void Task3_Test_A()
        {
            var result = _sut.solution(new int[] {1, 1, 0, 1, 0, 0});

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Task3_Test_B()
        {
            var result = _sut.solution(new int[] { 0, 1, 1, 1, 1, 0 });

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Task3_Test_C()
        {
            var result = _sut.solution(new int[] { 1, 0, 0, 1, 1, 0, 1 });

            Assert.AreEqual(4, result);
        }
    }

    public class Task3Solution
    {
        public int solution(int[] A)
        {
            int n = A.Length;
            int result = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] == A[i + 1])
                    result = result + 1;
            }
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                if (i > 0)
                {
                    if (A[i - 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                if (i < n - 1)
                {
                    if (A[i + 1] != A[i])
                        count = count + 1;
                    else
                        count = count - 1;
                }
                r = Math.Max(r, count);
            }
            return result + r;
        }
    }
}