using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDepartment.Parser
{
    public interface IParser<T>
    {
       // IParser(IFileReader<T> fileReader); 
        List<T> GetParseResults(); 
    }
}
