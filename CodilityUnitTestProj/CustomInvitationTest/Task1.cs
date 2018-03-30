using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks.CustomInvitationTest
{
    [TestClass]
    public class Task1
    {
        private Task1Solution _sut;

        public Task1()
        {
            _sut = new Task1Solution();
        }

        [TestMethod]
        public void Task1_Test_53_On_2_Position()
        {
            var result = _sut.solution(53, 1953786);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Task1_Test_78_On_4_Position_B()
        {
            var result = _sut.solution(78, 1953786);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Task1_Test_10_Not_Existing_Should_minus1()
        {
            var result = _sut.solution(10, 1953786);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Task1_Test_Short_Number_On_Position_1()
        {
            var result = _sut.solution(1, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Task1_A_is_longer_than_B()
        {
            var result = _sut.solution(45678, 453);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void Task1_0_Should_Return_0()
        {
            var result = _sut.solution(0, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Task1_The_Same_Values()
        {
            var result = _sut.solution(54545, 954545);
            Assert.AreEqual(1, result);
        }
    }

    public class Task1Solution
    {
        public int solution(int A, int B)
        {
            var text = B.ToString();
            var pattern = A.ToString();

            for (int i = 0; i < text.Length; i++)
            {
                // substring indx in bounds.
                if (i + pattern.Length <= text.Length)
                {
                    if (pattern == text.Substring(i, pattern.Length))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

    }
}