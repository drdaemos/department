using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDepartment.Parser
{
    public class ParseResult<T>
    {
        string Value { get; set; }
        T Info { get; set; }
        public ParseResult(string value, T info)
        {
            this.Value = value;
            this.Info = info; 
        }
    }
}
