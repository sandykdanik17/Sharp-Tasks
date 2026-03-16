using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;

namespace Lab3.Tests
{
    [TestClass] 
    public class TrapezeTests
    {
        [TestMethod] 
        public void GetArea_ShouldCalculateCorrectly()
        {
            Trapeze t = new Trapeze(5, 7, 4, 1);
            double expectedArea = 24.0; 

            double actualArea = t.GetArea();

            Assert.AreEqual(expectedArea, actualArea, "Площа розрахована неправильно!");
        }

        [TestMethod]
        public void IsSquare_WhenSidesEqual_ShouldReturnTrue()
        {
            Trapeze t = new Trapeze(6, 6, 6, 1); 
            bool isSquare = t.IsSquare();

            Assert.IsTrue(isSquare);
        }
    }
}