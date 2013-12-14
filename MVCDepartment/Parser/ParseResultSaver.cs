using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDepartment.Parser; 

namespace MVCDepartment.Parser
{
    public class ParseResultSaver : IParseResultSaver<ParseResult<string>>
    {
        public bool Commit(List<ParseResult<string>> parseResults)
        {
            throw new NotImplementedException();
        }
    }
}