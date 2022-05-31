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
        protected List<Double> listOfDirections = new List<Double>();
        protected List<Int32> modsList = new List<Int32>();
        protected List<Double> listaWagW = new List<Double>();
        protected List<Double> thresholdDataSet_QB = new List<Double>();
        protected List<Double> thresholdDataSet_PB = new List<Double>();
        protected List<Double> thresholdDataSet_VB = new List<Double>();
        protected List<Double> listaProguQA = new List<Double>();
        protected List<Double> listaProguPA = new List<Double>();
        protected List<Double> listaProguVA = new List<Double>();
        protected List<Double[,]> listaZbiorowZgodnosci = new List<Double[,]>();
        public List<Double[,]> ListaZbiorowZgodnosci { get { return listaZbiorowZgodnosci; } }
        protected List<Double[,]> discordanceDataSets = new List<Double[,]>();
        public List<Double[,]> ListaZbiorowNieZgodnosci { get { return discordanceDataSets; } }
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
        protected List<Int32> resultsOfTheDuelsOfVariants = new List<Int32>();
        protected List<Int32> alternativesInRanking = new List<Int32>();
        protected List<Int32> alternativesInRankingNotSorted = new List<Int32>();
        //protected List<Int32> listaChwilowa = new List<Int32>();
        protected List<Int32> lul = new List<Int32>();
        protected List<Int32> workingListOfNumbersOfOptions = new List<Int32>();
        protected List<String> rankingOpcjiFinalny = new List<String>();
       // protected List<List<Int32>> listaRank = new List<List<Int32>>();
        protected List<List<Int32>> alternativesWithResultsOfDuels = new List<List<Int32>>();
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

        protected Double[,] concordanceMatrix;
        public Double[,] ConcordanceMatrix { get { return concordanceMatrix; } }
        protected Double[,] macierzOcen;
        protected Double[,] tableOfAlternatives;
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
        public Double[,] tabelaMatrix;

        public Double[,] TabelaMatrix { get { return tabelaMatrix; } set { tabelaMatrix = value; } }

        protected Double[,,] criteriaThresholdValueDataSet;
        public Double[,,] ListaWartProgKryt { get { return criteriaThresholdValueDataSet; } set { criteriaThresholdValueDataSet = value; } }

        protected double threshold_Q = -1;
        protected double threshold_P = -1;
        protected double threshold_V = -1;
        protected double alfa = 0.15;
        public double Alfa { get { return alfa; } set { alfa = value;} }
        protected double beta = 0.3;
        public double Beta { get { return beta; } set { beta = value; } }
        protected double newDelta = 0.0;
        protected double sDeltaK = 0.0;
                protected int liczbaZajetychMiejscWRankWDestZstep = 0;
        protected int liczbaZajetychMiejscWRankWDestWstep = 0;
        protected int decimalPlacesValue = 2;
        public int MiejscPoPrzecinku { get { return decimalPlacesValue; } set { decimalPlacesValue = value; } }
        public int numberOfCriterias = 0;
        public int NumberOfCriterias { get { return numberOfCriterias;  } set { numberOfCriterias = value; } }
        public int numberOfAlternatives = 0;
        public int NumberOfAlternatives { get { return numberOfAlternatives; } set { numberOfAlternatives = value; } }

        // destylacja zstępująca == true, destylacja wstępująca == false
        protected Boolean typDestylacji = true;
        public Boolean TypDestylacji { get { return typDestylacji; } set { typDestylacji = value; } }

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
            tableOfAlternatives = new Double[numberOfAlternatives, numberOfCriterias];

            // tworzenie matrixa dla wartości samych alternatyw
            // dane pobierane są z tabeli (wartości podane przez użytkownika do tabeli)
            // pierwsze 5 wierszy to kierunek, waga oraz progi
            // od 5 do n-tego wiersza mamy wartości alternatyw. 
            // To one są pobierane z tabeli i zapisywane do oddzielnej tabeli dla samych alternatyw
            int licznik = 0;
            Console.WriteLine("wypisywana Tabela Matrix podczas przypisywania jej wartości do tabeliAlternatyw");

            for (int y = 9; y < numberOfAlternatives + 9; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    tableOfAlternatives[licznik, z] = tabelaMatrix[y, z];
                    Console.Write(tabelaMatrix[y, z] + " ");
                }
                licznik++;
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Tabela Alternatyw");

            for (int y = 0; y < numberOfAlternatives; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    Console.Write(tableOfAlternatives[y, z] + " ");
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
        

        public async Task<double[,,]> CreateListOfValueThresholdsAsync(int numberOfCriterias, Double[,] matrix)
        {

            criteriaThresholdValueDataSet = new Double[numberOfCriterias, 3, 2];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                criteriaThresholdValueDataSet[i, 0, 1] = matrix[6, i];
                criteriaThresholdValueDataSet[i, 1, 1] = matrix[7, i];
                criteriaThresholdValueDataSet[i, 2, 1] = matrix[8, i];
                criteriaThresholdValueDataSet[i, 0, 0] = matrix[3, i];
                criteriaThresholdValueDataSet[i, 1, 0] = matrix[4, i];
                criteriaThresholdValueDataSet[i, 2, 0] = matrix[5, i];
            }

            return criteriaThresholdValueDataSet;
        }


        protected DataTable CreateDataTab()
        {
            DataTable dataTab = new DataTable();

            for (int i = 0; i < columnNames.Count; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = columnNames[i];
                dataTab.Columns.Add(column);
            }

            return dataTab;
        }


        protected delegate void CreateDataTableBasedOnMatrixDelegate(int colAdd, int rowAdd, DataTable dataTab);

        protected DataTable CreateDataTableBasedOnMatrix(int colAdd, int rowAdd, CreateDataTableBasedOnMatrixDelegate algorithmDelegate) {

            DataTable dataTab = CreateDataTab();

            algorithmDelegate(colAdd, rowAdd, dataTab);

            return dataTab;
        }

        public void ExchangingListOfRanksToTable(List<List<Int32>> listOfRanks) { }
        public void ShowOptionRankingOfDistillation(String[,] rankingOfOptionsAfterDistillation) { }
    }
}
