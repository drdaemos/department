using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDepartment.Parser
{
    public interface IFileReader<T>
    {
        List<string> getInfo(LinkedList<T> positions); 
    }
}
