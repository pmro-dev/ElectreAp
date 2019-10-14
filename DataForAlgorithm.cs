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
        protected List<Double[,]> listaZbiorowNieZgodnosci = new List<Double[,]>();
        protected List<Double[,]> listaZbiorowPrzewyzszania = new List<Double[,]>();
        protected List<Double[,]> listaMacierzyOcen = new List<Double[,]>();
        protected List<Int32> listaNumerowZNazwOpcji = new List<Int32>();
        protected List<Int32> listaNumerowZNazwNajlepszychOpcjiWewnatrz = new List<Int32>();
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
        protected List<String> rankingOpcjiFinalny = new List<String>();
        protected List<List<Int32>> listaRank = new List<List<Int32>>();
        protected List<List<Int32>> listaAlternatyw = new List<List<Int32>>();
        protected List<List<Int32>> listaNumerowOpcjiMacierzyOcen = new List<List<Int32>>();

        protected List<String> columnNames = new List<String>();
        public List<String> ColumnNames { get { return columnNames; } set { columnNames = value; } }
        public void ColumnNames_SetValue(int index, string valueToSet) { columnNames[index] = valueToSet; }
        public string ColumnNames_GetValue(int index) { return columnNames[index]; }

        protected String[,] miejscaOpcjiPoDestylacjiZstepujacej;
        public String[,] MiejscaOpcjiPoDestylacjiZstepujacej { get { return miejscaOpcjiPoDestylacjiZstepujacej; } }
        protected String[,] miejscaOpcjiPoDestylacjiWstepujacej;
        public String[,] MiejscaOpcjiPoDestylacjiWstepujacej { get { return miejscaOpcjiPoDestylacjiWstepujacej; } }
        protected String[,] punktacjaOpcji;
        protected String[,] punktacjaOpcjiZmienna;
        protected String[,] tabRank;
        protected String[] columnNamesDoListy;
        public String[] ColumnNamesDoListy { get { return columnNamesDoListy; } set { columnNamesDoListy = value; } }
        public void ColumnNamesDoListy_SetValue(int index, string valueToSet) { columnNamesDoListy[index] = valueToSet; }
        public string ColumnNamesDoListy_GetValue(int index) { return columnNamesDoListy[index]; }

        private String valueHelp = "";

        protected Double[,] concordanceMatrix;
        protected Double[,] tabelaAlternatyw;
        private Double[,] tabZstep;
        public Double[,] TabZstep { get { return tabZstep; } set { tabZstep = value; } }
        private Double[,] tabWstep;
        public Double[,] TabWstep { get { return tabWstep; } set { tabWstep = value; } }
        private Double[,] tabSum;
        public Double[,] TabSum { get { return tabSum; } set { tabSum = value; } }
        // macierz wskaźników wiarygodności inaczej Credibility Matrix
        private Double[,] credibilityMatrix;
        private Double[,] roboczyMatrixDOgol;
        public Double[,] RoboczyMatrixDOgol { get { return roboczyMatrixDOgol; } }
        private Double[,] matrixRownosciZbiorowPrzewyzszania;
        private Double[,] roboczyMatrixD;
        protected Double[,] tabelaMatrix;
        public void TabelaMatrix_SetValue(int row, int col, double valueToSet) { tabelaMatrix[row, col] = valueToSet; }        
        public Double TabelaMatrix_GetValue(int row, int col) { return tabelaMatrix[row, col]; }

        protected Double[,,] listaWartProgKryt;
        public void ListaWartProgKryt_SetValue(int index, int positionOfThreshold, int positionOfSymbol, double valueToSet) {
            listaWartProgKryt[index, positionOfThreshold, positionOfSymbol] = valueToSet;
        }
        public Double ListaWartProgKryt_GetValue(int index, int positionOfThreshold, int positionOfSymbol) {
            return listaWartProgKryt[index, positionOfThreshold, positionOfSymbol];
        }

        private double wartoscZgodnosci;
        protected double progQ = -1;
        protected double progP = -1;
        protected double progV = -1;
        private double testLogiczny = 0.0;
        private double Delta0 = 0.0;
        private double alfa = 0.15;
        public double Alfa { get { return alfa; } set { alfa = value;} }
        private double beta = 0.3;
        public double Beta { get { return beta; } set { beta = value; } }
        protected double newDelta = 0.0;
        private double sDeltaK = 0.0;
        private double zmiennaPomocnicza = 0.0;
        private double wartoscMax = 0.0;
        private double zmiennaPomocna = 0.0;
        private double zmiennaPomocnicza1 = 0.0;
        private double zmiennaHelp;

        private int liczbaZajetychMiejscWRankWDestZstep = 0;
        private int liczbaZajetychMiejscWRankWDestWstep = 0;
        protected int miejscPoPrzecinku = 2;
        public int MiejscPoPrzecinku { get { return miejscPoPrzecinku; } set { miejscPoPrzecinku = value; } }
        protected int numberOfCriterias = 0;
        public int NumberOfCriterias { get { return numberOfCriterias;  } set { numberOfCriterias = value; } }
        protected int numberOfAlternatives = 0;
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

        public void CreateMatrixBasedOnTable(){ }

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

            for (int y = 9; y < numberOfAlternatives + 9; y++)
            {
                for (int z = 0; z < numberOfCriterias; z++)
                {
                    tabelaAlternatyw[licznik, z] = tabelaMatrix[y, z];
                    Console.Write(tabelaMatrix[y, z] + " ");
                }
                licznik++;
            }

            Console.WriteLine("Tabela Alternatyw");

            for (int y = 0; y < numberOfAlternatives; y++)
            {
                for (int z = 0; z < numberOfCriterias; z++)
                {
                    Console.Write(tabelaAlternatyw[y, z] + " ");
                }
                Console.WriteLine("\n");
            }
        }

        public void CreateConcordanceMatrix(List<Double[,]> listOfConcordanceSets, int numberOfAlternatives){ }
        public void ShowConcordanceMatrix(){ }

        public DataTable CreateTable(int numberOfAlternatives, int numberOfCriterias) {
            columnNamesDoListy = new string[numberOfCriterias];
            DataTable dataTab = new DataTable();

            for (int i = 0; i < numberOfCriterias + 1; i++) {
                if (i == 0) { columnNames.Add("X"); } else { columnNames.Add("F" + i); columnNamesDoListy[i-1] = columnNames[i]; }

                DataColumn column = new DataColumn();
                column.ColumnName = columnNames[i];
                dataTab.Columns.Add(column);
            }

            int zmienna = 1;

            for (int y = 0; y < numberOfAlternatives + 3; y++) {
                
                List<string> row = new List<string>();

                for (int z = 0; z < numberOfCriterias + 1; z++) {
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

                        if (y >= 3) {
                            zmienna++;
                        }
                    }
                    else {
                        row.Add("0,00");
                    }
                }

                dataTab.Rows.Add(row.ToArray<string>());
            }

            tabelaMatrix = new Double[numberOfAlternatives + 9, numberOfCriterias];

            for (int y = 0; y < numberOfAlternatives + 9; y++) {
                for (int z = 0; z < numberOfCriterias; z++) {
                    tabelaMatrix[y, z] = 0.00;
                }
            }

            listaWartProgKryt = new Double[numberOfCriterias, 3, 2];

            // wypełnianie zerami
            for (int i = 0; i < numberOfCriterias; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        listaWartProgKryt[i, j, k] = 0.0;
                    }
                }
            }

            return dataTab;
        }

/*        public void Wyp(int numberOfAlternatives, int numberOfCriterias)
        {
            for (int y = 0; y < numberOfAlternatives + 9; y++)
            {
                for (int z = 0; z < numberOfCriterias; z++)
                {
                    Console.Write(tabelaMatrix[y, z]+" ");
                }
                Console.WriteLine();
            }
        }*/

        public void ExchangingListOfRanksToTable(List<List<Int32>> listOfRanks) { }
        public void ShowOptionRankingOfDistillation(String[,] rankingOfOptionsAfterDistillation) { }
    }
}
