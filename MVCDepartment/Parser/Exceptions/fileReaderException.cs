using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDepartment.Parser.Exceptions
{
    public class fileReaderException : Exception
    {
        public fileReaderException() 
            : base() 
        {
        }

        public fileReaderException(string message)
            : base(message)
        {
        }

        public fileReaderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}