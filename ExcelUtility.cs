using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.CSharp.RuntimeBinder;
using _Excel = Microsoft.Office.Interop.Excel;

namespace Regression_Suite
{
    class ExcelUtility
    {


        string Writepath = "";
        string ReadPath = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public ExcelUtility(string filReadepath,string fileWritrePath, int sheet)
        {

            ReadPath = filReadepath;
            Writepath = fileWritrePath;

            wb = excel.Workbooks.Open(filReadepath);
            ws = wb.Worksheets[sheet];
        }
        public  string ReadCell(int row, int colum)
        {
            row++;
            colum++;


            if (ws.Cells[row,colum].Value2 != null)
                return ws.Cells[ row, colum].Value2;
            wb.Close();
            return null;
        }

        public void WriteinCell(int row , int column, string value)
        {
            row++;
            column++;
            ws.Cells[row, column].Value2 = value;
         
        }
        public void FlushFiles()
        {
            //wb.Save();
            wb.SaveAs(Writepath);
            wb.Close();
        }

        // created a list of Type Datavalues so that at one index i can have 3 values - rows , column and data for entering into excel cell.
        public List<DataValues> dt = new List<DataValues>()

        {
           new DataValues()
           {
               row=ConfigClass.ExcelRowsandColumns[0,0],
               column=ConfigClass.ExcelRowsandColumns[0,1],
               data= ConfigClass.ExcelCellvalues[0],
           },
           new DataValues()
           {
               row=ConfigClass.ExcelRowsandColumns[1,0],
               column=ConfigClass.ExcelRowsandColumns[1,1],
               data= ConfigClass.ExcelCellvalues[1],
           },

           new DataValues()
           {
               row=ConfigClass.ExcelRowsandColumns[2,0],
               column=ConfigClass.ExcelRowsandColumns[2,1],
               data= ConfigClass.ExcelCellvalues[2],
           },

           new DataValues()
           {
              row=ConfigClass.ExcelRowsandColumns[3,0],
               column=ConfigClass.ExcelRowsandColumns[3,1],
               data= ConfigClass.ExcelCellvalues[3],
           },
           new DataValues()
           {
               row=ConfigClass.ExcelRowsandColumns[4,0],
               column=ConfigClass.ExcelRowsandColumns[4,1],
               data= ConfigClass.ExcelCellvalues[4],
           },

           };

         
        
        // Method for entering data into excel using List of Type DataValues

        public void WriteInMultipleCells()
        {
            foreach (var item in dt)
            {
                WriteinCell(item.row, item.column, item.data);
            }

            FlushFiles();
             
        }


    }
    

    public class DataValues
    {

        public  int row { get; set; }
        public  int column { get; set; }
        public  string data { get; set; }
    }
        
}
