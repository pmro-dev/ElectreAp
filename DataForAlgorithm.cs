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
        public List<Double> listaKierunkow = new List<Double>();
        private List<Double> listaModow = new List<Double>();
        private List<Double> listaWagW = new List<Double>();
        private List<Double> listaProguQB = new List<Double>();
        private List<Double> listaProguPB = new List<Double>();
        private List<Double> listaProguVB = new List<Double>();
        private List<Double> listaProguQA = new List<Double>();
        private List<Double> listaProguPA = new List<Double>();
        private List<Double> listaProguVA = new List<Double>();
        private List<Double[,]> listaZbiorowZgodnosci = new List<Double[,]>();
        private List<Double[,]> listaZbiorowNieZgodnosci = new List<Double[,]>();
        private List<Double[,]> listaZbiorowPrzewyzszania = new List<Double[,]>();
        private List<Double[,]> listaMacierzyOcen = new List<Double[,]>();
        private List<Int32> listaNumerowZNazwOpcji = new List<Int32>();
        private List<Int32> listaNumerowZNazwNajlepszychOpcjiWewnatrz = new List<Int32>();
        private List<Int32> listaNumerowZNazwOpcjiUsytWRank = new List<Int32>();
        private List<Int32> listaNumerowZNazwOpcjiOgolZstep = new List<Int32>();
        private List<Int32> listaNumerowZNazwOpcjiOgolWstep = new List<Int32>();
        private List<Int32> listaNumZNazwPomoc = new List<Int32>();
        private List<Int32> listaKtoZKimPrzegral = new List<Int32>();
        private List<Int32> listaAltWRank = new List<Int32>();
        private List<Int32> listaAltWRankNieSort = new List<Int32>();
        private List<Int32> listaChwilowa = new List<Int32>();
        private List<Int32> lul = new List<Int32>();
        private List<Int32> listaDlaRank = new List<Int32>();
        private List<String> rankingOpcjiFinalny = new List<String>();
        private List<List<Int32>> listaRank = new List<List<Int32>>();
        private List<List<Int32>> listaAlternatyw = new List<List<Int32>>();
        private List<List<Int32>> listaNumerowOpcjiMacierzyOcen = new List<List<Int32>>();

        public List<String> columnNames = new List<String>();

        private String[,] miejscaOpcjiPoDestylacjiZstepujacej;
        private String[,] miejscaOpcjiPoDestylacjiWstepujacej;
        private String[,] punktacjaOpcji;
        private String[,] punktacjaOpcjiZmienna;
        private String[,] tabRank;
        public String[] columnNamesDoListy;

        private String valueHelp = "";

        private Double[,] CorcordanceMatrix;
        public Double[,] tabelaAlternatyw;
        private Double[,] TabZstep;
        private Double[,] TabWstep;
        private Double[,] TabSum;
        // macierz wskaźników wiarygodności inaczej Credibility Matrix
        private Double[,] credibilityMatrix;
        private Double[,] roboczyMatrixDOgol;
        private Double[,] matrixRownosciZbiorowPrzewyzszania;
        private Double[,] roboczyMatrixD;
        public Double[,] tabelaMatrix;
        public Double[,,] listaWartProgKryt;

        private double wartoscZgodnosci;
        private double progQ = -1;
        private double progP = -1;
        private double progV = -1;
        private double testLogiczny = 0.0;
        private double Delta0 = 0.0;
        private double alfa = 0.15;
        private double beta = 0.3;
        private double newDelta = 0.0;
        private double sDeltaK = 0.0;
        private double zmiennaPomocnicza = 0.0;
        private double wartoscMax = 0.0;
        private double zmiennaPomocna = 0.0;
        private double zmiennaPomocnicza1 = 0.0;
        private double zmiennaHelp;

        private int liczbaZajetychMiejscWRankWDestZstep = 0;
        private int liczbaZajetychMiejscWRankWDestWstep = 0;
        private int miejscPoPrzecinku = 2;
/*        private int liczbaKryteriow = 0;
        private int liczbaAlternatyw = 0;*/
        private int miejsceA = 0;
        private int miejsceB = 0;
        private int min = 0;
        private int rank = 0;
        // wiersz wskazuje na wariant do rozpatrzenia
        private int wiersz = -1;
        private int numerNiepasujacego = -1;
        private int maxim = 0;
        private int pomocna = 0;
        private int licz = 0;

        private Boolean testDC = false;
        private Boolean testDelta = false;
        // destylacja zstępująca == true, destylacja wstępująca == false
        private Boolean typDestylacji = true;
        private Boolean tescik = false;
        private Boolean tescikBol = false;
        #endregion

        public void CreateMatrixBasedOnTable(){ }

        public void DivideThresholdsToLists() {
        /*
        uzupełnianie listy kierunków -> pobieranie wartości z matrixa tabeli
        wartość kierunku ( 0 lub 1 ) mówi nam czy wartości ujemne ( 0 ) czy wartości dodatnie ( 1 ) 
        dla danego kryterium są lepsze od tych drugich
        np. kryterium pojemność silnika im większa wartość ( wartość kierunku 1 ) tym lepiej dla danej alternatywy (motoru)
        np. kryterium oddległość od centrum miasta im mniejsza wartość ( wartość kierunku 0 ) tym lepiej dla danej alternatywy (nieruchomości)
        */

            
        }

        public void CreateMatrixForAlternativeData(int numberOfAlternatives, int numberOfCriterias) {
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
