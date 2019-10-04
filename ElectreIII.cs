using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElectreAp.Tables;

namespace ElectreAp
{
    class ElectreIII : IAlgorithm, IElectreIII
    {
        // deklaracje zmiennych
        #region
        private List<Double> listaKierunkow;
        private List<Double> listaModow;
        private List<Double> listaWagW;
        private List<Double> listaProguQB;
        private List<Double> listaProguPB;
        private List<Double> listaProguVB;
        private List<Double> listaProguQA;
        private List<Double> listaProguPA;
        private List<Double> listaProguVA;
        private List<Int32> listaNumerowZNazwOpcji;
        private List<Int32> listaNumerowZNazwNajlepszychOpcjiWewnatrz;
        private List<Int32> listaNumerowZNazwOpcjiUsytWRank;
        private List<Int32> listaNumerowZNazwOpcjiOgolZstep;
        private List<Int32> listaNumerowZNazwOpcjiOgolWstep;
        private List<Int32> listaNumZNazwPomoc;
        private List<String> rankingOpcjiFinalny;
        private List<List<Int32>> listaRank;
        private List<Int32> listaDlaRank;
        private List<List<Int32>> listaAlternatyw;
        private List<Int32> listaKtoZKimPrzegral;
        private List<Int32> listaAltWRank;
        private List<Int32> listaAltWRankNieSort;
        private List<Int32> listaChwilowa;
        private String[,] miejscaOpcjiPoDestylacjiZstepujacej;
        private String[,] miejscaOpcjiPoDestylacjiWstepujacej;
        private String[,] punktacjaOpcji;
        private String[,] punktacjaOpcjiZmienna;
        private String[,] tabRank;
        private List<Double[,]> listaZbiorowZgodnosci;
        private List<Double[,]> listaZbiorowNieZgodnosci;
        private List<Double[,]> listaZbiorowPrzewyzszania;
        private List<Double[,]> listaMacierzyOcen;
        private List<List<Int32>> listaNumerowOpcjiMacierzyOcen;
        private Double[,,] listaWartProgKryt;
        private List<Int32> lul;
        private Double[,] CorcordanceMatrix;
        public Double[,] tabelaMatrix;
        public Double[,] tabelaAlternatyw;
        private Double[,] TabZstep;
        private Double[,] TabWstep;
        private Double[,] TabSum;

        private int liczbaZajetychMiejscWRankWDestZstep = 0;
        private int liczbaZajetychMiejscWRankWDestWstep = 0;
        private double wynik;
        private int miejscPoPrzecinku = 2;
        private double progQ = -1;
        private double progP = -1;
        private double progV = -1;
        private double wartoscZgodnosci;
        private int liczbaKryteriow = 0;
        private int liczbaAlternatyw = 0;
        private Double testLogiczny = 0.0;
        private Boolean testDC = false;
        private Double[,] matrixRownosciZbiorowPrzewyzszania;
        // macierz wskaźników wiarygodności inaczej Credibility Matrix
        private Double[,] credibilityMatrix;
        private Double[,] roboczyMatrixDOgol;
        private Double Delta0 = 0.0;
        private Double alfa = 0.15;
        private Double beta = 0.3;
        private Double newDelta = 0.0;
        private Double sDeltaK = 0.0;
        private Double zmiennaPomocnicza = 0.0;
        private Boolean testDelta = false;
        private Double wartoscMax = 0.0;
         Double[,] roboczyMatrixD;
        private double zmiennaPomocna = 0.0;
        private Double zmiennaPomocnicza1 = 0.0;
        // destylacja zstępująca == true, destylacja wstępująca == false
        private Boolean typDestylacji = true;
        private int miejsceA = 0;
        private int miejsceB = 0;
        int min = 0;
        int rank = 0;
        Boolean tescik = false;
        Boolean tescikBol = false;
        int licz = 0;
        // wiersz wskazuje na wariant do rozpatrzenia
        int wiersz = -1;
        int numerNiepasujacego = -1;
        int maxim = 0;
        int pomocna = 0;
        #endregion

        public ElectreIII()
        {

            listaKierunkow = new List<Double>();
            listaModow = new List<Double>();
            listaWagW = new List<Double>();
            listaProguQB = new List<Double>();
            listaProguPB = new List<Double>();
            listaProguVB = new List<Double>();
            listaProguQA = new List<Double>();
            listaProguPA = new List<Double>();
            listaProguVA = new List<Double>();
            listaNumerowZNazwOpcji = new List<Int32>();
            listaNumerowZNazwNajlepszychOpcjiWewnatrz = new List<Int32>();
            listaNumerowZNazwOpcjiUsytWRank = new List<Int32>();
            listaNumerowZNazwOpcjiOgolZstep = new List<Int32>();
            listaNumerowZNazwOpcjiOgolWstep = new List<Int32>();
            listaNumZNazwPomoc = new List<Int32>();
            rankingOpcjiFinalny = new List<String>();
            listaZbiorowZgodnosci = new List<Double[,]>();
            listaZbiorowNieZgodnosci = new List<Double[,]>();
            listaZbiorowPrzewyzszania = new List<Double[,]>();
            listaMacierzyOcen = new List<Double[,]>();
            listaNumerowOpcjiMacierzyOcen = new List<List<Int32>>();
            lul = new List<Int32>();
            roboczyMatrixD = new Double[liczbaAlternatyw, liczbaAlternatyw];

        }

        public double CalculateSDeltaK(double deltaLast)
        {
            throw new NotImplementedException();
        }

        public void CalculateThreshold(double[,,] table, double value, int i, int mod)
        {
            throw new NotImplementedException();
        }

        public void CheckingIsThereThisSameOptions(int y)
        {
            throw new NotImplementedException();
        }

        public void CreateConcordanceSets()
        {
            throw new NotImplementedException();
        }

        public void CreateDiscordanceSets()
        {
            throw new NotImplementedException();
        }

        public void CreateFinalRanking(double[,] tabSum)
        {
            throw new NotImplementedException();
        }

        public void CreateOutrankingSets(List<double[,]> listOfOutrankingSets)
        {
            throw new NotImplementedException();
        }

        public void CreateSumTableOfDistillations(double[,] tabTopDownDistillation, double[,] tabUpwardDistillation)
        {
            throw new NotImplementedException();
        }

        public double[][] CreateTabOfDistillation(string[,] placesOfOptionsAfterDistillation, int valueX, int valueY, int valueZ)
        {
            throw new NotImplementedException();
        }

        public void DoCalculations()
        {
            throw new NotImplementedException();
        }

        public double DoInvers(double symbolA, double symbolB, int numberOfSymbol)
        {
            throw new NotImplementedException();
        }

        public void DoStageFirst()
        {
            throw new NotImplementedException();
        }

        public void DoStageSecond()
        {
            throw new NotImplementedException();
        }

        public void DoStepFifth(double lastDelta, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            throw new NotImplementedException();
        }

        public void DoStepFourth(double deltaLast, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            throw new NotImplementedException();
        }

        public void DoStepSecond(double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            throw new NotImplementedException();
        }

        public void DoStepSeventh(double[,] ratingMatrix, double qualificationOfTheBestOption, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            throw new NotImplementedException();
        }

        public void DoStepSixth(double[,] ratingMatrix, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            throw new NotImplementedException();
        }

        public void Exchange(int max, int min)
        {
            throw new NotImplementedException();
        }

        public void FindMax(string[][] rankingOfOptionsAfterDistillation)
        {
            throw new NotImplementedException();
        }

        public void FindMax(string[,] rankingOfOptionsAfterDistillation)
        {
            throw new NotImplementedException();
        }

        public void FindMin()
        {
            throw new NotImplementedException();
        }

        public void ShowConcordanceSets()
        {
            throw new NotImplementedException();
        }

        public void ShowDiscordanceSets()
        {
            throw new NotImplementedException();
        }

        public void ShowOutrankingSets()
        {
            throw new NotImplementedException();
        }

        public void ShowStageFirst()
        {
            throw new NotImplementedException();
        }

        public void ShowStageSecond()
        {
            throw new NotImplementedException();
        }

        public void ShowTableDataOfDistillation(double[,] tab)
        {
            throw new NotImplementedException();
        }

        double[,] IElectreIII.CreateTabOfDistillation(string[,] placesOfOptionsAfterDistillation, int valueX, int valueY, int valueZ)
        {
            throw new NotImplementedException();
        }
    }
}
