
//using Excel;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        /// <summary>
        /// Storing all the excel values in to the in memory collections
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through therows and columns of the table
            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for(int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    _dataCol.Add(dtTable);
                }
            }
        }

        ///<summary>
        ///Reads all the data from excel sheet
        ///</summary>

        //private static DataTable ExcelToDataTable(string fileName)
        //{
        //    //open file and reurn as Stream
        //    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
        //    //Createopenxmlreader via ExcelReaderFactory
        //    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx {for .xls use CreateBinaryReader method}
        //    //Set the first Row as Column name
        //    excelReader.IsFirstRowAsColumnNames = true;
        //    //Return as DataSet
        //    DataSet result = excelReader.AsDataSet();
        //    //Get all the tables
        //    DataTableCollection table = result.Tables;
        //    //Store it in Datatable
        //    DataTable resultTable = table["Sheet1"];
        //    //return
        //    return resultTable;
        //}

        private static DataTable ExcelToDataTable(string fileName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //Set the first Row as Column name
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });
                        //Get all the tables
                        DataTableCollection table = result.Tables;
                        //Store it in Datatable
                        DataTable resultTable = table["Sheet1"];
                        //return
                        return resultTable;
                     }
                }
            
        }

        public static string ReadData (int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in _dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch(Exception e)
            {
                return null;
            }
        }








    }

    public class Datacollection
    {
        public int rowNumber { get; set;}
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
