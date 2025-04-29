using CalculatorClassLibrary.Exceptions;

namespace CalculatorClassLibrary
{

    //calculator should find the sun if two non-zero numbers, non-negative, non-odd ints and return the rsult else throw expection 
    public class Calculator
    {
        public int Sum(int a, int b)
        {
            if (a == 0 || b == 0)
                throw new ZeroInputException("numbers must be non zero");

            if (a < 0 || b < 0)
                throw new NegativeInputException("numbers should be non negative");

            if (a % 2 != 0 || b % 2 != 0)
                throw new OddInputException("numbers must be non odd");

            return a + b;
        }
    }
}
