using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ElectreAp
{
    class ExcelManaging
    {
        int liczbaKryteriowWczytywanie = 0;
        int liczbaAlternatywWczytywanie = 0;
        //File plik;
        String path = null;
        // WritableSheet sheet;
        //Label label;
        //  Number number;
        String pomoc;

        int kolumny = 0;
        int wiersze = 0;
        int sheetNum = 0;
        //WritableWorkbook workbook;
        String rozszerzenie = "xls";
        Double zmiennaHelp2;

        public ExcelManaging()
        {

        }

        public Double[,] ReadDataFromFileToMatrix(string path, out Double[,] tabelaMatrix, ref int numberOfAlternatives, ref int numberOfCriterias)
        {

            try
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exWorkbook = exApp.Workbooks.Open(@"" + path);
                Excel._Worksheet exWorksheet = exWorkbook.Sheets[1];
                Excel.Range exRange = exWorksheet.UsedRange;
                int rowCount = exRange.Rows.Count;
                int colCount = exRange.Columns.Count;
                numberOfAlternatives = rowCount - 10;
                numberOfCriterias = colCount - 1;

                tabelaMatrix = new Double[rowCount - 1, colCount - 1];
                string zzz = "";

                for (int i = 2; i <= rowCount; i++)
                {
                    for (int j = 2; j <= colCount; j++)
                    {
                        if (exRange.Cells[i, j] != null && exRange.Cells[i, j].Value2 != null)
                        {
                            zzz = exRange.Cells[i, j].Value2.ToString();
                            tabelaMatrix[i - 2, j - 2] = Double.Parse(zzz);
                        }
                    }
                }
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is 
                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(exRange);
                Marshal.ReleaseComObject(exWorksheet);
                //close and release
                exWorkbook.Close();
                Marshal.ReleaseComObject(exWorkbook);
                //quit and release
                exApp.Quit();
                Marshal.ReleaseComObject(exApp);
                Console.WriteLine("END TESTOWANKO");
                return tabelaMatrix;

            }
            catch (Exception ex) { Console.WriteLine(ex); MessageBox.Show("Niestety nie udało się wczytać pliku.", "Błąd pliku", MessageBoxButtons.OK); return tabelaMatrix = null; }
        }

        void SaveDataToExelFile(string path) { }

        public void WriteCell(int i, int j, string value) {
            exWorksheet.Cells[i + 1, j + 1].Value2 = value;
        }

        Excel.Application exApp;
        Excel.Workbook exWorkBook;
        private Excel._Worksheet exWorksheet;

        public void SaveTableToExelFile(string path, Double[,] matrix) {
            exApp = new Excel.Application();
            exWorkBook = exApp.Workbooks.Add(Type.Missing);
            exWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)exWorkBook.ActiveSheet;
            exWorksheet = exWorkBook.Worksheets[1];
            exWorksheet.Name = "Basic Table";

            //try {

            for (int i = 0; i < matrix.GetLength(0) + 1; i++) {
                for (int j = 0; j < matrix.GetLength(1) + 1; j++) {
                    if (j == 0) {
                        switch (i) {
                            case 0:
                                WriteCell(i, j, "X");
                                break;
                            case 1:
                                WriteCell(i, j, "K");
                                break;
                            case 2:
                                WriteCell(i, j, "M");
                                break;
                            case 3:
                                WriteCell(i, j, "W");
                                break;
                            case 4:
                                WriteCell(i, j, "QA");
                                break;
                            case 5:
                                WriteCell(i, j, "PA");
                                break;
                            case 6:
                                WriteCell(i, j, "VA");
                                break;
                            case 7:
                                WriteCell(i, j, "QB");
                                break;
                            case 8:
                                WriteCell(i, j, "PB");
                                break;
                            case 9:
                                WriteCell(i, j, "VB");
                                break;
                            default:
                                WriteCell(i, j, "A"+(i-9));
                                break;
                        }
                    }
                    else if (j > 0 && i == 0) { WriteCell(i, j, "A" + j); }
                    else { WriteCell(i, j, matrix[i - 1, j - 1].ToString()); }
                }
            }

            exApp.Visible = true;
            exApp.UserControl = true;
            exWorkBook.SaveAs(path);
            exWorkBook.Close();
            exApp.Quit();
            /*            }
                        catch (Exception ex)
                        {

                        }*/
        }
        void ChoisePath() { }
    }
}
