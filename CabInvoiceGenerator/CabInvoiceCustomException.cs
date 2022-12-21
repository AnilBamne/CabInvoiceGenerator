using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator222Batch
{
    /// <summary>
    /// Using custom exceptions
    /// </summary>
    public class CabInvoiceCustomException : Exception
    {
        public ExceptionType exceptionType;
        public enum ExceptionType 
        { 
            INVALID_DISTANCE,           //exception types
            INVALID_TIME
        }
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exceptionType"></param>
        public CabInvoiceCustomException(string message,ExceptionType exceptionType) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
