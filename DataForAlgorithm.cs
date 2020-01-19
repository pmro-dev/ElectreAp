using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ElectreAp
{
    class DataForAlgorithm
    {

        // deklaracje zmiennych
        #region
        protected List<Double> listaKierunkow = new List<Double>();
        protected List<Int32> listaModow = new List<Int32>();
        protected List<Double> listaWagW = new List<Double>();
        protected List<Double> listaProguQB = new List<Double>();
        protected List<Double> listaProguPB = new List<Double>();
        protected List<Double> listaProguVB = new List<Double>();
        protected List<Double> listaProguQA = new List<Double>();
        protected List<Double> listaProguPA = new List<Double>();
        protected List<Double> listaProguVA = new List<Double>();
        protected List<Double[,]> listaZbiorowZgodnosci = new List<Double[,]>();
        public List<Double[,]> ListaZbiorowZgodnosci { get { return listaZbiorowZgodnosci; } }
        protected List<Double[,]> listaZbiorowNieZgodnosci = new List<Double[,]>();
        public List<Double[,]> ListaZbiorowNieZgodnosci { get { return listaZbiorowNieZgodnosci; } }
        protected List<Double[,]> listaZbiorowPrzewyzszania = new List<Double[,]>();
        public List<Double[,]> ListaZbiorowPrzewyzszania { get { return listaZbiorowPrzewyzszania; } }
        protected List<Double[,]> listaZstepMacierzyOcen = new List<Double[,]>();
        public List<Double[,]> ListaZstepMacierzyOcen { get { return listaZstepMacierzyOcen; } }
        protected List<Double[,]> listaWstepMacierzyOcen = new List<Double[,]>();
        public List<Double[,]> ListaWstepMacierzyOcen { get { return listaWstepMacierzyOcen; } }

        protected List<Int32> listaNumerowZNazwOpcji = new List<Int32>();
        protected List<Int32> listaNumerowZNazwNajlepszychOpcjiWewnatrz;
        protected List<Int32> listaNumerowZNazwOpcjiUsytWRank = new List<Int32>();
        protected List<Int32> listaNumerowZNazwOpcjiOgolZstep = new List<Int32>();
        public List<Int32> ListaNumerowZNazwOpcjiOgolZstep { get { return listaNumerowZNazwOpcjiOgolZstep; } }
        protected List<Int32> listaNumerowZNazwOpcjiOgolWstep = new List<Int32>();
        public List<Int32> ListaNumerowZNazwOpcjiOgolWstep { get { return listaNumerowZNazwOpcjiOgolWstep; } }
        protected List<Int32> listaNumZNazwPomoc = new List<Int32>();
        protected List<Int32> listaKtoZKimPrzegral = new List<Int32>();
        protected List<Int32> listaAltWRank = new List<Int32>();
        protected List<Int32> listaAltWRankNieSort = new List<Int32>();
        protected List<Int32> listaChwilowa = new List<Int32>();
        protected List<Int32> lul = new List<Int32>();
        protected List<Int32> listaDlaRank = new List<Int32>();
        protected List<Int32> workingListOfNumbersOfOptions = new List<Int32>();
        protected List<String> rankingOpcjiFinalny = new List<String>();
        protected List<List<Int32>> listaRank = new List<List<Int32>>();
        protected List<List<Int32>> listaAlternatyw = new List<List<Int32>>();
        protected List<List<Int32>> listaNumerowOpcjiMacierzyOcen = new List<List<Int32>>();
        public List<List<Int32>> ListaNumerowOpcjiMacierzyOcen { get { return listaNumerowOpcjiMacierzyOcen; } }

        protected List<String> columnNames = new List<String>();
        public List<String> ColumnNames { get { return columnNames; } set { columnNames = value; } }
        public void ColumnNames_SetValue(int index, string valueToSet) { columnNames[index] = valueToSet; }
        public string ColumnNames_GetValue(int index) { return columnNames[index]; }

        protected Double[,] topDownRanking;
        public Double[,] TopDownRanking { get { return topDownRanking; } }
        protected Double[,] upwardRanking;
        public Double[,] UpwardRanking { get { return upwardRanking; } }
        protected String[,] punktacjaOpcji;
        protected String[,] punktacjaOpcjiZmienna;
        protected Double[,] finalRanking;
        public Double[,] FinalRanking { get { return finalRanking; } }
        protected String[] columnNamesDoListy;
        public String[] ColumnNamesDoListy { get { return columnNamesDoListy; } set { columnNamesDoListy = value; } }
        public void ColumnNamesDoListy_SetValue(int index, string valueToSet) { columnNamesDoListy[index] = valueToSet; }
        public string ColumnNamesDoListy_GetValue(int index) { return columnNamesDoListy[index]; }

        private String valueHelp = "";

        protected Double[,] concordanceMatrix;
        public Double[,] ConcordanceMatrix { get { return concordanceMatrix; } }
        protected Double[,] macierzOcen;
        protected Double[,] tabelaAlternatyw;
        protected Double[,] tabZstep;
        public Double[,] TabZstep { get { return tabZstep; } set { tabZstep = value; } }
        protected Double[,] tabWstep;
        public Double[,] TabWstep { get { return tabWstep; } set { tabWstep = value; } }
        protected Double[,] finalRankingMatrix;
        public Double[,] FinalRankingMatrix { get { return finalRankingMatrix; } set { finalRankingMatrix = value; } }
        // macierz wskaźników wiarygodności inaczej Credibility Matrix
        protected Double[,] credibilityMatrix;
        public Double[,] CredibilityMatrix { get { return credibilityMatrix; } }
        protected Double[,] roboczyMatrixDOgol;
        public Double[,] RoboczyMatrixDOgol { get { return roboczyMatrixDOgol; } }
        protected Double[,] matrixRownosciZbiorowPrzewyzszania;
        private Double[,] roboczyMatrixD;
        public Double[,] tabelaMatrix;

        public Double[,] TabelaMatrix { get { return tabelaMatrix; } set { tabelaMatrix = value; } }
/*        public void TabelaMatrix_SetValue(int col, int row, double valueToSet) { tabelaMatrix[col, row] = valueToSet; }        
        public Double TabelaMatrix_GetValue(int col, int row) { return tabelaMatrix[col, row]; }*/

        protected Double[,,] listaWartProgKryt;
        public Double[,,] ListaWartProgKryt { get { return listaWartProgKryt; } set { listaWartProgKryt = value; } }
/*        public void ListaWartProgKryt_SetValue(int index, int positionOfThreshold, int positionOfSymbol, double valueToSet) {
            listaWartProgKryt[index, positionOfThreshold, positionOfSymbol] = valueToSet;
        }
        public Double ListaWartProgKryt_GetValue(int index, int positionOfThreshold, int positionOfSymbol) {
            return listaWartProgKryt[index, positionOfThreshold, positionOfSymbol];
        }*/

        private double wartoscZgodnosci;
        protected double progQ = -1;
        protected double progP = -1;
        protected double progV = -1;
        private double testLogiczny = 0.0;
        private double Delta0 = 0.0;
        protected double alfa = 0.15;
        public double Alfa { get { return alfa; } set { alfa = value;} }
        protected double beta = 0.3;
        public double Beta { get { return beta; } set { beta = value; } }
        protected double newDelta = 0.0;
        protected double sDeltaK = 0.0;
        private double zmiennaPomocnicza = 0.0;
        private double wartoscMax = 0.0;
        private double zmiennaPomocna = 0.0;
        private double zmiennaPomocnicza1 = 0.0;
        private double zmiennaHelp;

        protected int liczbaZajetychMiejscWRankWDestZstep = 0;
        protected int liczbaZajetychMiejscWRankWDestWstep = 0;
        protected int miejscPoPrzecinku = 2;
        public int MiejscPoPrzecinku { get { return miejscPoPrzecinku; } set { miejscPoPrzecinku = value; } }
        public int numberOfCriterias = 0;
        public int NumberOfCriterias { get { return numberOfCriterias;  } set { numberOfCriterias = value; } }
        public int numberOfAlternatives = 0;
        public int NumberOfAlternatives { get { return numberOfAlternatives; } set { numberOfAlternatives = value; } }
        private int miejsceA = 0;
        private int miejsceB = 0;
        private int min = 0;
        private int rank = 0;
        // wiersz wskazuje na wariant do rozpatrzenia
        private int wiersz = -1;
        private int numerNiepasujacego = -1;
        protected int maxim = 0;
        private int pomocna = 0;
        private int licz = 0;

        private Boolean testDC = false;
        private Boolean testDelta = false;
        // destylacja zstępująca == true, destylacja wstępująca == false
        protected Boolean typDestylacji = true;
        public Boolean TypDestylacji { get { return typDestylacji; } set { typDestylacji = value; } }
        private Boolean tescik = false;
        private Boolean tescikBol = false;

        private Boolean cboxConcordanceSetsChecked = false;
        public Boolean CboxConcordanceSetsChecked { get { return cboxConcordanceSetsChecked; } set { cboxConcordanceSetsChecked = value; } }
        private Boolean cboxConcordanceMatrixChecked = false;
        public Boolean CboxConcordanceMatrixChecked { get { return cboxConcordanceMatrixChecked; } set { cboxConcordanceMatrixChecked = value; } }
        private Boolean cboxNonConcordanceSetsChecked = false;
        public Boolean CboxNonConcordanceSetsChecked { get { return cboxNonConcordanceSetsChecked; } set { cboxNonConcordanceSetsChecked = value; } }
        private Boolean cboxOutrankingSetsChecked = false;
        public Boolean CboxOutrankingSetsChecked { get { return cboxOutrankingSetsChecked; } set { cboxOutrankingSetsChecked = value; } }
        private Boolean cboxSetEqualityMatrixChecked = false;
        public Boolean CboxSetEqualityMatrixChecked { get { return cboxSetEqualityMatrixChecked; } set { cboxSetEqualityMatrixChecked = value; } }
        private Boolean cboxCredibilityMatrixChecked = false;
        public Boolean CboxCredibilityMatrixChecked { get { return cboxCredibilityMatrixChecked; } set { cboxCredibilityMatrixChecked = value; } }
        private Boolean cboxRatingMatrixChecked = false;
        public Boolean CboxRatingMatrixChecked { get { return cboxRatingMatrixChecked; } set { cboxRatingMatrixChecked = value; } }
        private Boolean cboxTopDownDistillationChecked = false;
        public Boolean CboxTopDownDistillationChecked { get { return cboxTopDownDistillationChecked; } set { cboxTopDownDistillationChecked = value; } }
        private Boolean cboxUpwardDistillationChecked = false;
        public Boolean CboxUpwardDistillationChecked { get { return cboxUpwardDistillationChecked; } set { cboxUpwardDistillationChecked = value; } }
        private Boolean cboxRankingsChecked = false;
        public Boolean CboxRankingsChecked { get { return cboxRankingsChecked; } set { cboxRankingsChecked = value; } }
        #endregion

        public void CreateMatrixForAlternativeData(int numberOfAlternatives, int numberOfCriterias)
        {
            tabelaAlternatyw = new Double[numberOfAlternatives, numberOfCriterias];

            // tworzenie matrixa dla wartości samych alternatyw
            // dane pobierane są z tabeli (wartości podane przez użytkownika do tabeli)
            // pierwsze 5 wierszy to kierunek, waga oraz progi
            // od 5 do n-tego wiersza mamy wartości alternatyw. 
            // To one są pobierane z tabeli i zapisywane do oddzielnej tabeli dla samych alternatyw
            int licznik = 0;
            Console.WriteLine("wypisywana Tabela Matrix podczas przypisywania jej wartości do tabeliAlternatyw");

            for (int y = 9; y < numberOfAlternatives + 9; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    tabelaAlternatyw[licznik, z] = tabelaMatrix[y, z];
                    Console.Write(tabelaMatrix[y, z] + " ");
                }
                licznik++;
            }

            Console.WriteLine("Tabela Alternatyw");

            for (int y = 0; y < numberOfAlternatives; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    Console.Write(tabelaAlternatyw[y, z] + " ");
                }
                Console.WriteLine("\n");
            }
        }


        public async Task<string[]> CreateColumnNamesAsync(int numberOfCriterias, int colAdd) {
            
            columnNamesDoListy = new string[numberOfCriterias];

            for (int i = 0; i < numberOfCriterias + colAdd; i++) {
                if (i == 0) { columnNames.Add("X"); } 
                else { 
                    columnNames.Add("F" + i); 
                    columnNamesDoListy[i - 1] = columnNames[i]; 
                }
            }

            return columnNamesDoListy;
        }


        public async Task CreateBaseMatrix(int numberOfAlternatives, int numberOfCriterias) {

            tabelaMatrix = new Double[numberOfAlternatives + 9, numberOfCriterias];

            for (int y = 0; y < numberOfAlternatives + 9; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    tabelaMatrix[y, z] = 0.00;
                }
            }

            Console.WriteLine("Utworzono matrix -> wierszy = " + tabelaMatrix.GetLength(0) + " kolumny = " + tabelaMatrix.GetLength(1));
        }


        public async Task<double[,,]> CreateListOfValueThresholdsAsync(int numberOfCriterias, Double[,] matrix) {

            listaWartProgKryt = new Double[numberOfCriterias, 3, 2];

            for (int i = 0; i < matrix.GetLength(1); i++) {
                listaWartProgKryt[i, 0, 1] = matrix[6, i];
                listaWartProgKryt[i, 1, 1] = matrix[7, i];
                listaWartProgKryt[i, 2, 1] = matrix[8, i];                
                listaWartProgKryt[i, 0, 0] = matrix[3, i];
                listaWartProgKryt[i, 1, 0] = matrix[4, i];
                listaWartProgKryt[i, 2, 0] = matrix[5, i];
            }

            return listaWartProgKryt;
        }


        public async Task<DataTable> CreateDataTableBasedOnMatrixAsync(Double[,] matrix, int colAdd, int rowAdd) {
       // public DataTable CreateDataTableBasedOnMatrix(Double[,] matrix, int colAdd, int rowAdd) {

            DataTable dataTab = new DataTable();

            for (int i = 0; i < columnNames.Count; i++) {
                DataColumn column = new DataColumn();
                column.ColumnName = columnNames[i];
                dataTab.Columns.Add(column);
            }

            int zmienna = 1;

            for (int y = 0; y < matrix.GetLength(0) + rowAdd; y++) {
                List<string> row = null;
                if (y < 3 || y >= 9) { row = new List<string>(); }
                if (row != null) {
                    for (int z = 0; z < matrix.GetLength(1) + colAdd; z++) {
                        if (z == 0) {
                            if (y < 3) {
                                switch (y) {
                                    case 0:
                                        row.Add("K");
                                        break;
                                    case 1:
                                        row.Add("M");
                                        break;
                                    case 2:
                                        row.Add("W");
                                        break;
                                }
                            }
                            else { row.Add("A" + zmienna); }
                            if (y >= 3) { zmienna++; }
                        }
                        else {
                            if (y < 3 || y >= 9) {
                                row.Add(matrix[y, z - colAdd].ToString());
                            }
                        }
                    }
                    dataTab.Rows.Add(row.ToArray<string>());
                }
            }
            return dataTab;
        }

        public void ExchangingListOfRanksToTable(List<List<Int32>> listOfRanks) { }
        public void ShowOptionRankingOfDistillation(String[,] rankingOfOptionsAfterDistillation) { }
    }
}
