using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDepartment.Parser
{
    public interface IParseResultSaver<T>
    {
        bool Commit(List<T> parseResults); 
    }
}
