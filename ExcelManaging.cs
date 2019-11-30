using System;
using System.Collections.Generic;
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
        String rozszerzenie = "xlsx";
        Double zmiennaHelp2;


        public ExcelManaging() { }


        public Double[,] ReadTableFromFileToMatrix(string path, out Double[,] tabelaMatrix, ref int numberOfAlternatives, ref int numberOfCriterias)
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


        Excel.Application exApp;
        Excel.Workbook exWorkBook;
        Excel._Worksheet exWorksheet;


        private void NewExcelFile() {
            exApp = new Excel.Application();
            exWorkBook = exApp.Workbooks.Add(Type.Missing);
        }


        private void NewSheet(string nameSheet) {
            exWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)exWorkBook.ActiveSheet;
            exWorksheet = exWorkBook.Worksheets[1];
            exWorksheet.Name = nameSheet;
        }


        private void WriteCell(int i, int j, string value) {
            exWorksheet.Cells[i + 1, j + 1].Value2 = value;
        }


        private void CloseAndSaveFile(string path) {
            exWorkBook.SaveAs(path);
            exWorkBook.Close();
            exApp.Quit();
        }


        private void AddBasicMatrixToSheet(Double[,] basicMatrix) {
            for (int i = 0; i < basicMatrix.GetLength(0) + 1; i++) {
                for (int j = 0; j < basicMatrix.GetLength(1) + 1; j++) {
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
                                WriteCell(i, j, "A" + (i - 9));
                                break;
                        }
                    }
                    else if (j > 0 && i == 0) { WriteCell(i, j, "A" + j); }
                    else { WriteCell(i, j, basicMatrix[i - 1, j - 1].ToString()); }
                }
            }
        }


        private delegate void MatrixFuncDelegate(int x, int i, int j, Double[,] matrix);


        private void RatingMatrixFunc(int x, int i, int j, Double[,] ratingMatrix) {
            if (j == 0) {
                switch (i) {
                    case 0:
                        WriteCell(x, j, "X");
                        break;
                    case 1:
                        WriteCell(x, j, "Power");
                        break;
                    case 2:
                        WriteCell(x, j, "Weakness");
                        break;
                    case 3:
                        WriteCell(x, j, "Qualification");
                        break;
                }
            }
            else if (j > 0 && i == 0) {
                switch(j){
                    case 0:
                        WriteCell(x, j, "X");
                        break;
                    default:
                        WriteCell(x, j, "A" + ratingMatrix[0, j - 1]);
                        break;
                }
            }
            else if (i > 1) { x--;  WriteCell(x, j, ratingMatrix[i - 1, j - 1].ToString()); }
        }


        private void OtherMatrixFunc(int x, int i, int j, Double[,] otherMatrix) {
            if (j == 0) {
                switch (i) {
                    case 0:
                        WriteCell(x, j, "X");
                        break;
                    default:
                        WriteCell(x, j, "A" + i);
                        break;
                }
            }
            else if (j > 0 && i == 0) { WriteCell(x, j, "A" + j); }
            else { WriteCell(x, j, otherMatrix[i - 1, j - 1].ToString()); }
        }


        private void RankingPositionFunc(int x, int i, int j, Double[,] rankingMatrix) {
            if (j == 0) {
                switch (i) {
                    case 0:
                        WriteCell(x, j, "X");
                        break;
                    case 1:
                        WriteCell(x, j, "Pozycja");
                        break;
                }
            }
            else if (j > 0 && i == 0) { WriteCell(x, j, "A" + j); }
            else if(i > 1) { x--; WriteCell(x, j, rankingMatrix[i - 1, j - 1].ToString()); }
        }


        string symbol = null;

        public void RankingMatrixFunc(int x, int i, int j, Double[,] rankingMatrix) {
            if (j == 0) {
                switch (i) {
                    case 0:
                        WriteCell(x, j, "X");
                        break;
                    default:
                        WriteCell(x, j, "A" + i);
                        break;
                }
            }
            else if (j > 0 && i == 0) { WriteCell(x, j, "A" + j); }
            else { 
                switch (rankingMatrix[i - 1, j - 1]) {
                    case -1.0:
                        symbol = "\u20B1";
                        break;
                    case 0.0:
                        symbol = "I";
                        break;
                    case 1.0:
                        symbol = "\u03A1";
                        break;
                    case 2.0:
                        symbol = "R";
                        break;
                }
                WriteCell(x, j, symbol);

                //WriteCell(x, j, rankingMatrix[i - 1, j - 1].ToString()); 
            }

        }


        private void AddMatrixToSheet(Double[,] matrix, string matrixName, MatrixFuncDelegate matrixFuncDelegate) {
            WriteCell(x, 0, matrixName);
            x++; ;

            for (int i = 0; i < matrix.GetLength(0) + 1; i++) {
                for (int j = 0; j < matrix.GetLength(1) + 1; j++) {
                    matrixFuncDelegate(x, i, j, matrix);
                }
                x++;
            }
            x++; ;
        }


        int x = 0;
        int iterat = 1;


        private void AddSetToSheet(List<Double[,]> listOfMatrixes, string setName)
        {
            NewSheet(setName);
            iterat = 1;
            foreach (Double[,] item in listOfMatrixes) {
                AddMatrixToSheet(item, setName+" "+ iterat, OtherMatrixFunc);
                iterat++;
            }
        }


        private void AddRatingToSheet(List<Double[,]> listOfRatings, string ratingName) {
            NewSheet(ratingName);
            iterat = 1;
            foreach (Double[,] item in listOfRatings) {
                AddMatrixToSheet(item, ratingName + " " + iterat, RatingMatrixFunc);
                iterat++;
            }
        }


        public void SaveTableToExelFile(string path, Double[,] matrix) {
            NewExcelFile();
            NewSheet("Basic Table");
            AddBasicMatrixToSheet(matrix);
            CloseAndSaveFile(path);
        }


        public void SaveDataToExelFile(string path, Double[,] basicMatrix, Double[,] concordanceMatrix, Double[,] credibilityMatrix, List<Double[,]> listaZbiorowZgodnosci, List<Double[,]> listaZbiorowNieZgodnosci, List<Double[,]> listaZbiorowPrzewyzszania ,List<Double[,]> listaZstepMacierzyOcen, List<Double[,]> listaWstepMacierzyOcen, Double[,] finalRanking, Double[,] topDownRanking, Double[,] upwardRanking, Double[,] finalRankingMatrix) {
            NewExcelFile();
            NewSheet("Basic Table");
            AddBasicMatrixToSheet(basicMatrix);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("Concordance Matrix");
            AddMatrixToSheet(concordanceMatrix, "Concordane Matrix", OtherMatrixFunc);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("Credibility Matrix");
            AddMatrixToSheet(credibilityMatrix, "Credibility Matrix", OtherMatrixFunc);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            AddSetToSheet(listaZbiorowZgodnosci, "Concordance Set");
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            AddSetToSheet(listaZbiorowNieZgodnosci, "Discordance Set");
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            AddSetToSheet(listaZbiorowPrzewyzszania, "Outranking Set");
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            AddRatingToSheet(listaZstepMacierzyOcen, "TopDown Rating");
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            AddRatingToSheet(listaWstepMacierzyOcen, "Upward Rating");
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("Final Ranking");
            AddMatrixToSheet(finalRanking, "Final Ranking", RankingPositionFunc);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("TopDown Ranking");
            AddMatrixToSheet(topDownRanking, "TopDown Ranking", RankingPositionFunc);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("Upward Ranking");
            AddMatrixToSheet(upwardRanking, "Upward Ranking", RankingPositionFunc);
            x = 0;
            exWorksheet = exWorkBook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
            NewSheet("Final Ranking Matrix");
            AddMatrixToSheet(finalRankingMatrix, "Final Ranking Matrix", RankingMatrixFunc);

            CloseAndSaveFile(path);
        }
    }
}
