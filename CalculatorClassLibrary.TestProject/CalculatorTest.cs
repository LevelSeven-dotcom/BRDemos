using CalculatorClassLibrary.Exceptions;

namespace CalculatorClassLibrary.TestProject
{
    [TestClass]
    public sealed class CalculatorTest
    {
        [TestMethod]
        public void SumTest_WithValidInput_WithValidResult() //positive test case 
        {
            //Approach - AAA
            //A - Arrange 
            Calculator target = new Calculator();
            int a = 10;
            int b = 20;
            int expected = 30;

            //A - Act
            int actual = target.Sum(a, b);

            //A - Assert
            Assert.AreEqual(expected, actual);
            //Do's and Dont's --in chat 
        }

        [TestMethod]
        [ExpectedException (typeof(ZeroInputException))]
        public void SumTest_WithZeroInput_ShouldThrowExp()
        {
            Calculator target = new Calculator();
            target.Sum(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeInputException))]
        public void SumTest_WithNegativeInput_ShouldThrowExp()
        {
            Calculator target = new Calculator();
            target.Sum(-1, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(OddInputException))]
        public void SumTest_WithOddInput_ShouldThrowExp()
        {
            Calculator target = new Calculator();
            target.Sum(1,3);
        }
    }
}
