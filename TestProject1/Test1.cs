using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLib;

namespace MatrixLib.Tests
{
    [TestClass]
    public class MatrixHelperTests
    {
        [TestMethod]
        public void IsColumnPositive_AllPositive_ReturnsTrue()
        {
            double[] col = { 1.1, 2.5, 3.0 };
            bool result = MatrixHelper.IsColumnPositive(col);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsColumnPositive_WithZero_ReturnsFalse()
        {
            double[] col = { 1.0, 0.0, 2.0 };
            bool result = MatrixHelper.IsColumnPositive(col);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsColumnPositive_WithNegative_ReturnsFalse()
        {
            double[] col = { 5.0, -1.2, 3.0 };
            bool result = MatrixHelper.IsColumnPositive(col);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindPositiveColumns_MixedMatrix_ReturnsCorrectNumbers()
        {
            double[,] matrix = {
                { 2.0, -1.0, 4.0 },
                { 3.0,  0.0, 5.0 }
            };
            int[] result = MatrixHelper.FindPositiveColumns(matrix);
            CollectionAssert.AreEqual(new int[] { 1, 3 }, result);
        }

        [TestMethod]
        public void FindPositiveColumns_NoPositiveColumns_ReturnsEmptyArray()
        {
            double[,] matrix = {
                { -1.0, 0.0 },
                { -2.0, -0.5 }
            };
            int[] result = MatrixHelper.FindPositiveColumns(matrix);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void IsColumnPositive_EmptyArray_ReturnsFalse()
        {
            double[] col = new double[0];
            bool result = MatrixHelper.IsColumnPositive(col);
            Assert.IsFalse(result);
        }

    }
}