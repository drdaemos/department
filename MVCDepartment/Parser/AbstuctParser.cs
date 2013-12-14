﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDepartment.Parser;
using MVCDepartment.Parser.Exceptions; 

namespace MVCDepartment.Parser
{
    abstract public class AbstuctParser<Pos, ResInfoType> : IParser<ParseResult<ResInfoType>> 
    {
        IFileReader<Pos> fileReader;
        public AbstuctParser(IFileReader<Pos> fileReader)
        {
            if (fileReader != null)
            {
                this.fileReader = fileReader;
            }
            else
            {
                throw new NullReferenceException("fileReader cannot be null");
            }
            positions = new LinkedList<Pos>(); 
            resultsInfo = new LinkedList<ResInfoType>(); 
        }

        public string DefultVal 
        {
            get
            {
                if (DefultVal != null) 
                { 
                    return DefultVal; 
                }
                else 
                { 
                    return ""; 
                }
            }
            set 
            {
                DefultVal = value; 
            } 
        }

        LinkedList<Pos> positions;
        LinkedList<ResInfoType> resultsInfo;

        public void addQuerry(Pos position, ResInfoType resultInfo)
        {
            positions.AddLast(position);
            resultsInfo.AddLast(resultInfo); 
        }

        public List<ParseResult<ResInfoType>> getParseResults()
        {
            List<string> readResult;
            try
            {
                readResult = fileReader.getInfo(positions);
            }
            catch (Exception ex)
            {
                throw new fileReaderException(ex.Message, ex); 
            }
            
            List<ParseResult<ResInfoType>> retList = new List<ParseResult<ResInfoType>>(readResult.Count);
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