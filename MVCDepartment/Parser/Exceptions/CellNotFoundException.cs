using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDepartment.Parser.Exceptions
{
    public class CellNotFoundException : Exception
    {
        public CellNotFoundException(string cellName)
            : base(cellName)
        {
        }
    }
}