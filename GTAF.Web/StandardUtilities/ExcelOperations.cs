﻿using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using ExlInterop = Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace StandardUtilities
{
    /// <summary>
    /// @Author - Pavan Parmar
    /// </summary>
    public static class ExcelOperations
    {

        public static void WriteExcelFile(string testDataFolderPath, string dataFile, string sheetname, int rowIndex, int columnIndex, string val)
        {
            DataTable dt = new DataTable();
            //tblExlData holds only data rows of excel sheet
            DataTable tblExcelData = new DataTable();
            string exlFileName = string.Empty;
            string exlDataSource = string.Empty;
            try
            {
                string fileName = dataFile + ".xlsx";
                string TestDataFolder = testDataFolderPath;
                string[] drTestdataFiles = Directory.GetFiles(TestDataFolder).
                    Where(x => x.EndsWith(".xls") || x.EndsWith(".xlsx")).ToArray();
                foreach (string tstDataFile in drTestdataFiles)
                {
                    exlFileName = tstDataFile.Substring(tstDataFile.LastIndexOf("\\") + 1);
                    if (fileName.Equals(exlFileName))
                    {
                        exlDataSource = Path.Combine(TestDataFolder, exlFileName);

                        break;
                    }
                }
                ExcelOperations.WriteDataToExcelUsingInterop(exlDataSource, sheetname, rowIndex, columnIndex, val);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ReadExcelUsingOLEDB(string exlDataSource)
        {
            OleDbConnection ocon; OleDbDataAdapter oda;
            DataTable tblExcelSchema;
            string sheetName = string.Empty;
            //dt holds both the empty and data rows of excel sheet
            DataTable dt = new DataTable();

            try
            {
                string ExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + exlDataSource + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'";
                ocon = new OleDbConnection(ExcelConn);
                ocon.Open();
                tblExcelSchema = ocon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = tblExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                oda = new OleDbDataAdapter("select * from [" + sheetName + "]", ocon);
                dt.TableName = "TestData";
                oda.Fill(dt);
                ocon.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return dt;
        }

        public static DataTable ReadExcelUsingInterop(string exlDataSource, string sheetname)
        {
            ExlInterop.Application exlApp = new ExlInterop.Application();
            ExlInterop.Workbook exlWb = null;
            ExlInterop.Worksheet exlSheet;

            int rCnt = 0; int cCnt = 0;
            object cellValue = null;
            string colValue = string.Empty;

            //dt holds both the empty and data rows of excel sheet
            DataTable dt = new DataTable();

            try
            {
                exlWb = exlApp.Workbooks.Open(exlDataSource);

                int numSheets = exlWb.Sheets.Count;
                for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
                {
                    exlSheet = (ExlInterop.Worksheet)exlWb.Sheets[sheetNum];
                    string strWorksheetName = exlSheet.Name;

                    exlWb.RefreshAll();
                    if (strWorksheetName.Equals(sheetname))
                    {
                        ExlInterop.Range range = exlSheet.UsedRange;
                        //                ExlInterop.Range range = exlSheet.UsedRange.SpecialCells(
                        //                               ExlInterop.XlCellType.xlCellTypeVisible,
                        //                               Type.Missing);
                        for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                        {
                            DataRow drow = dt.NewRow();
                            for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                            {
                                cellValue = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                colValue = cellValue == null ? string.Empty : Convert.ToString(cellValue);
                                //Adding Header Row to DataTable
                                if (rCnt == 1)
                                {
                                    dt.Columns.Add(colValue);
                                }
                                else
                                {
                                    drow[cCnt - 1] = colValue;
                                }
                            }
                            if (rCnt > 1)
                            {
                                dt.Rows.Add(drow);
                                dt.AcceptChanges();
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                exlWb.Close();
                exlApp.Quit();
                releaseProcessObject(exlWb);
                releaseProcessObject(exlApp);
            }
            return dt;
        }

        private static void releaseProcessObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void WriteDataToExcelUsingInterop(string exlDataSource, string sheetName, int rowIndex, int columnIndex, string val)
        {

            ExlInterop.Application exlApp = new ExlInterop.Application();
            exlApp.Visible = true;
            ExlInterop.Workbook exlWb = null;
            ExlInterop.Worksheet exlSheet;
            try
            {
                exlWb = exlApp.Workbooks.Open(exlDataSource, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, false, false);
                exlSheet = (Microsoft.Office.Interop.Excel.Worksheet)exlWb.Worksheets[sheetName];
                exlSheet.Cells[rowIndex, columnIndex] = val;
                exlWb.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                exlWb.Close();
                exlApp.Quit();
                releaseProcessObject(exlWb);
                releaseProcessObject(exlApp);
            }
        }

        public static string GetCellValueFromExcel(string TestCaseId, string ColumnName)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ReadExcelFile("TestData", "TestData");

                //To get complete row from excel based on test case id
                var rowValue = (from myRow in dt.AsEnumerable()
                                where myRow.Field<string>(0) == TestCaseId
                                select myRow).Single();

                int indexval = dt.AsEnumerable().Select(row => row.Field<string>("TCId") == TestCaseId).ToList().FindIndex(col => col);
                string value = dt.Rows[indexval][ColumnName].ToString();

                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + "Stack Trace:" + ex.StackTrace.ToString());
                return "";
            }
        }


        public static DataTable ReadExcelFile(string dataFile, string sheetname, bool isOLEDB = false)
        {
            DataTable tblExcelData = new DataTable();
            string exlFileName = string.Empty;
            try
            {
                string fileName = dataFile + ".xlsx";
                string testDataFolder = Directory.GetCurrentDirectory();// AppDomain.CurrentDomain.BaseDirectory.ToString()+"TestData" ;
                string[] drTestdataFiles = Directory.GetFiles(testDataFolder).
                    Where(x => x.EndsWith(".xls") || x.EndsWith(".xlsx")).ToArray();

                foreach (string tstDataFile in drTestdataFiles)
                {
                    exlFileName = tstDataFile.Substring(tstDataFile.LastIndexOf("\\") + 1);
                    if (fileName.Equals(exlFileName))
                    {
                        string exlDataSource = Path.Combine(testDataFolder, exlFileName);
                        if (isOLEDB)
                        {
                            tblExcelData = ReadExcelUsingOLEDB(exlDataSource);
                        }
                        else
                        {
                            //tblExcelData = ReadExcelUsingInterop(exlDataSource, sheetname);
                            tblExcelData = ReadExcelUsingNPOI(exlDataSource, sheetname);
                        }
                        break;
                    }
                }
                tblExcelData.TableName = "TestData";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + "Stack Trace:" + ex.StackTrace.ToString());
                //throw ex;
            }
            return tblExcelData;
        }

        /// <summary>
        /// Method to read excel file using NPOI libraries
        /// </summary>
        /// <param name="exlDataSource">Excel data Source Name</param>
        /// <returns></returns>
        public static DataTable ReadExcelUsingNPOI(string exlDataSource, string sheetName)
        {

            DataTable dt = new DataTable();//dt holds both the empty and data rows of excel sheet
            XSSFWorkbook hssfwb;
            try
            {
                using (FileStream file = new FileStream(exlDataSource, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new XSSFWorkbook(file);
                }

                ISheet sheet = hssfwb.GetSheet(sheetName);
                int rCnt = 0;
                string colValue = string.Empty;
                object cellValue = null;
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    var rowData = sheet.GetRow(row);
                    rCnt++;
                    if (rowData == null) continue;
                    DataRow drow = dt.NewRow();
                    for (int cCnt = 0; cCnt < rowData.LastCellNum; cCnt++)
                    {
                        ICell cellData = rowData.GetCell(cCnt, MissingCellPolicy.RETURN_NULL_AND_BLANK);

                        cellValue = cellData;
                        colValue = cellValue == null ? string.Empty : Convert.ToString(cellValue);
                        //Adding Header Row to DataTable
                        if (rCnt == 1)
                        {
                            dt.Columns.Add(colValue);
                        }
                        else
                        {
                            drow[cCnt] = colValue;
                        }
                    }

                    if (rCnt > 1)
                    {
                        dt.Rows.Add(drow);
                        dt.AcceptChanges();
                    }

                }


            }
            catch (Exception ex)
            {
                //Report.Error(ex.Message.ToString() + "Stack Trace:" + ex.StackTrace.ToString());
                throw ex;
            }

            return dt;
        }

    }
}