﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using ExcelDataReader;



namespace DataDrivenFramework
{
    public static class ExcelOperations
    {
        private static DataTable ExcelDataTable(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["DataSet"];
            return resultTable;

        }
        public class DataCollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }

        }
        static List<DataCollection> dataCol = new List<DataCollection>();
        public static void PopulateInCollection(string filename)
        {
            DataTable table = ExcelDataTable(filename);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()

                    };
                    dataCol.Add(dtTable);
                }
            }
        }
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol where colData.colName == columnName && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();
                return data.ToString();

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}