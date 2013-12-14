using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDepartment.Parser
{
    public class CellPosition
    {
        public string SheetName 
        {
            get
            {
                return SheetName; 
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("sheetName cannot be null");
                }
<<<<<<< HEAD
                SheetName = value;
=======
                    SheetName = value;
>>>>>>> b42533f517128efb308bbb43b3de66a163c257f5
            }
        }
        public string AddressName
        {
            get
            {
                return AddressName; 
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("adressName cannot be null");
                }
                AddressName = value;
            }
        }
        public CellPosition(string sheetName, string addressName)
        {
            this.SheetName = sheetName;
            this.AddressName = addressName;
        }
    }
}