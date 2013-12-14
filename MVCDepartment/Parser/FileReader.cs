using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MVCDepartment.Parser.Exceptions; 


namespace MVCDepartment.Parser
{
    public class FileReader : IFileReader<CellPosition>
    {
        public string filePath;
        public FileReader(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath); 
            }
            this.filePath = filePath; 
        }

        private Cell getCell(CellPosition position, WorkbookPart wbPart)
        {
            Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().Where(sheet => sheet.Name == position.SheetName).FirstOrDefault();
            if (theSheet == null)
            {
                throw new SheetNotFoundException(position.SheetName); 
            }
            WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));
            Cell theCell = wsPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference == position.AddressName).FirstOrDefault();
            if (theCell == null)
            {
                throw new CellNotFoundException(position.AddressName); 
            }
            return theCell; 
        }

        public List<string> getInfo(LinkedList<CellPosition> positions)
        {
            List<string> retValues = new List<string>(positions.Count()); 
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                foreach (CellPosition position in positions)
                {
                     retValues.Add(getCell(position, wbPart).InnerText);
                }
            }
            return retValues; 
        }

    }
}