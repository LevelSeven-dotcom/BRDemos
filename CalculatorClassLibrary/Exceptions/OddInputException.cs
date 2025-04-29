namespace CalculatorClassLibrary.Exceptions
{
    public class OddInputException : ApplicationException
    {
        public OddInputException(string msg = null, Exception inner = null) : base(msg, inner) 
        { 
        
        }
    }
}
