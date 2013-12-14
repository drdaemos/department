using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDepartment.Parser; 

namespace MVCDepartment.Parser
{
    public class ExampleParser : AbstractParser<CellPosition, string>
    {
        public ExampleParser(IFileReader<CellPosition> fileReader) : base(fileReader)
        {
            AddQuery(new CellPosition("План", "R10C7"), "философия");
            AddQuery(new CellPosition("План", "R6C7"), "Иностранный язык"); 
        }
    }

    // пример использования 
    // ExampleParser exampleParser = new ExampleParser(new FileReader(path)); 
    // ParseResultSaver parseResultSaver = new ParseResultSaver(); 
    // parseResultSaver.commit(exampleParser.getParseResults()); 
    // 
}