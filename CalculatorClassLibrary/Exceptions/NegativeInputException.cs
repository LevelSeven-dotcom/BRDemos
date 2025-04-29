namespace CalculatorClassLibrary.Exceptions
{
    public class NegativeInputException : ApplicationException
    {
        public NegativeInputException(string msg = null, Exception inner = null) : base(msg, inner) 
        { 
        
        }
    }
}
