using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4; 

namespace Lab4.Tests
{
    [TestClass]
    public class TrapezeTests
    {
        [TestMethod]
        public void Indexer_WhenIndexIsZero_ShouldReturnA()
        {
            Trapeze t = new Trapeze(10, 20, 5, 1);

            int actualValue = t[0];

            Assert.AreEqual(10, actualValue, "Індексатор повернув неправильне значення для t[0]!");
        }

        [TestMethod]
        public void OperatorMultiply_ShouldMultiplyAAndH()
        {
            Trapeze t = new Trapeze(5, 7, 4, 1);
            int scalar = 3;

            Trapeze result = t * scalar;

            
            Assert.AreEqual(15, result[0], "Поле 'a' не помножилося!"); 
            Assert.AreEqual(7, result[1], "Поле 'b' мало залишитися без змін!"); 
            Assert.AreEqual(12, result[2], "Поле 'h' не помножилося!"); 
            Assert.AreEqual(1, result[3], "Колір 'c' мав залишитися без змін!"); 
        }
    }
}