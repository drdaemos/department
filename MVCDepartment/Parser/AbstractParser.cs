using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDepartment.Parser;
using MVCDepartment.Parser.Exceptions; 

namespace MVCDepartment.Parser
{
    abstract public class AbstractParser<Pos, ResInfoType> : IParser<ParseResult<ResInfoType>> 
    {
        IFileReader<Pos> fileReader;

        protected AbstractParser(IFileReader<Pos> fileReader)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException("fileReader cannot be null");
            }
            this.fileReader = fileReader;
            positions = new LinkedList<Pos>(); 
            resultsInfo = new LinkedList<ResInfoType>(); 
        }

        public string DefaultVal 
        {
            get
            {
                if (DefaultVal != null) 
                { 
                    return DefaultVal; 
                }
                else 
                { 
                    return ""; 
                }
            }
            set 
            {
                DefaultVal = value; 
            } 
        }

        LinkedList<Pos> positions;
        LinkedList<ResInfoType> resultsInfo;

        public void AddQuery(Pos position, ResInfoType resultInfo)
        {
            positions.AddLast(position);
            resultsInfo.AddLast(resultInfo); 
        }

        public List<ParseResult<ResInfoType>> GetParseResults()
        {
            List<string> readResult = fileReader.GetInfo(positions);
            var retList = new List<ParseResult<ResInfoType>>(resultsInfo.Count);
            var index = resultsInfo.First; 
            foreach (string result in readResult)
            {
                if (index != null)
                {
                    retList.Add(new ParseResult<ResInfoType>(result, index.Value));
                    index = index.Next; 
                }
            }
            return retList; 
        }
    }
}