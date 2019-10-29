using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ElectreAp
{
    class ExcelManaging
    {
        int liczbaKryteriowWczytywanie = 0;
        int liczbaAlternatywWczytywanie = 0;
        //File plik;
        String sciezka = null;
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

        public ExcelManaging() {

        }

        public Double[,] ReadDataFromFileToMatrix(string path, out Double[,] tabelaMatrix, ref int numberOfAlternatives, ref int numberOfCriterias) {

            try {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exWorkbook = exApp.Workbooks.Open(@"" + path);
                Excel._Worksheet exWorksheet = exWorkbook.Sheets[1];
                Excel.Range exRange = exWorksheet.UsedRange;
                int rowCount = exRange.Rows.Count;
                int colCount = exRange.Columns.Count;
                numberOfAlternatives = rowCount - 10;
                numberOfCriterias = colCount - 1;

                tabelaMatrix = new Double[rowCount-1, colCount - 1];
                string zzz = "";

                for (int i = 2; i <= rowCount; i++) {
                    for (int j = 2; j <= colCount; j++) {
                        if (exRange.Cells[i, j] != null && exRange.Cells[i, j].Value2 != null) {
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

            } catch(Exception ex) { Console.WriteLine(ex); MessageBox.Show("Niestety nie udało się wczytać pliku.", "Błąd pliku", MessageBoxButtons.OK); return tabelaMatrix = null; }
        }

         void SaveDataToExelFile(string path) { }
         void SaveTableToExelFile(string path) { }
         void ChoisePath() { }
    }
}
