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
<<<<<<< HEAD
=======

        public CellNotFoundException()
            : base()
        {
        }
>>>>>>> b42533f517128efb308bbb43b3de66a163c257f5
    }
}