using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDepartment.Parser
{
    public interface IParseResultSaver<T>
    {
        bool commit(List<T> parseResults); 
    }
}
