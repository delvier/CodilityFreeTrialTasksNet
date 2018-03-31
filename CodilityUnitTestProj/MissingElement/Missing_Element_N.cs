using Colidity_Free_Trial_Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks
{
    [TestClass]
    public class MissingElement_N
    {
        [TestMethod]
        public void Test_Method_Simple()
        {
            var input = new int[] { 2, 3, 1, 5 };
            var solution = new Solution();
            Assert.AreEqual(4, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Missing_First()
        {
            var input = new int[] { 2, 3 };
            var solution = new Solution();
            Assert.AreEqual(1, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Misiing_Last()
        {
            var input = new int[] { 1, 2 };
            var solution = new Solution();
            Assert.AreEqual(3, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Empty()
        {
            var input = new int[] { };
            var solution = new Solution();
            Assert.AreEqual(1, solution.FindMissingElement(input));
        }
    }
}
