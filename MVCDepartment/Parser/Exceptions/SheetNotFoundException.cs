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
<<<<<<< HEAD
=======

        public SheetNotFoundException()
            : base()
        {
        }

>>>>>>> b42533f517128efb308bbb43b3de66a163c257f5
    }
}