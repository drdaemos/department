using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; 

namespace MVCDepartment.Other
{
    interface IParser
    {
        string getInfo(String query); 
    }

    public class Parser
    {
        string filePath;
        string file; 
        public Parser(string filePath)
        {        
            if (filePath == null)
            {
                throw new NullReferenceException("File is null"); 
            }
            file = System.IO.File.ReadAllText(filePath);
            this.filePath = filePath; 
        }

        public string getInfo(String query)
        {
            if ((query == null) || (query == ""))
            {
                throw new ArgumentException("Queue is empty"); 
            }
            String retString;



            throw new NotFoundException(); 
        }
    }

}