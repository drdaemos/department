using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDepartment.Parser.Exceptions
{
    public class SheetNotFoundException : Exception
    {
        public SheetNotFoundException(string sheetName)
            : base(sheetName)
        {
        }
    }
}