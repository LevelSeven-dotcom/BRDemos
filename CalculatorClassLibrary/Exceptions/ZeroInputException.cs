using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClassLibrary.Exceptions
{
    public class ZeroInputException : ApplicationException
    {
        public ZeroInputException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }
}
