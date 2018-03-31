using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility_Free_Trial_Tasks.MissingElement
{
    [TestClass]
    public class Missing_Element_N
    {
        [TestMethod]
        public void Test_Method_Simple()
        {
            var input = new int[] { 2, 3, 1, 5 };
            var solution = new MissingElementSolution();
            Assert.AreEqual(4, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Missing_First()
        {
            var input = new int[] { 2, 3 };
            var solution = new MissingElementSolution();
            Assert.AreEqual(1, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Misiing_Last()
        {
            var input = new int[] { 1, 2 };
            var solution = new MissingElementSolution();
            Assert.AreEqual(3, solution.FindMissingElement(input));
        }

        [TestMethod]
        public void TestMethod_Empty()
        {
            var input = new int[] { };
            var solution = new MissingElementSolution();
            Assert.AreEqual(1, solution.FindMissingElement(input));
        }
    }
}
