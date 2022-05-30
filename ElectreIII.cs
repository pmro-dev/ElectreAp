using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElectreAp;

namespace ElectreAp
{
    class ElectreIII : DataForAlgorithm, IAlgorithm, IElectreIII
    {

        public ElectreIII() { }

        public DataTable CreateDataTableAsync(int colAdd, int rowAdd)
        {
            CreateDataTableBasedOnMatrixDelegate algorithmDelegate = AlgorithmForDelegate;

            return CreateDataTableBasedOnMatrix(colAdd, rowAdd, algorithmDelegate);
        }

        protected void AlgorithmForDelegate(int colAdd, int rowAdd, DataTable dataTab)
        {
            int zmienna = 1;

            for (int y = 0; y < TabelaMatrix.GetLength(0) + rowAdd; y++)
            {
                List<string> row = null;
                if (y < 3 || y >= 9) { row = new List<string>(); }
                if (row != null)
                {
                    for (int z = 0; z < TabelaMatrix.GetLength(1) + colAdd; z++)
                    {
                        if (z == 0)
                        {
                            if (y < 3)
                            {
                                switch (y)
                                {
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
                        else
                        {
                            if (y < 3 || y >= 9)
                            {
                                row.Add(TabelaMatrix[y, z - colAdd].ToString());
                            }
                        }
                    }
                    dataTab.Rows.Add(row.ToArray<string>());
                }
            }
        }

        public double CalculateSDeltaK(double deltaLast)
        {
            sDeltaK = beta - (alfa * deltaLast);
            return sDeltaK;
        }


        public void CalculateThreshold(double[,,] table, double value, int i, int mod)
        {
            switch (mod)
            {

                // mod invers
                case 0:
                    //Console.WriteLine("CASE 0");
                    //Console.WriteLine("Q PRZEL. ALFA * var + PRZEL. BETA");
                    progQ = Math.Round((DoInvers(table[i, 0, 0], table[i, 0, 1], 0) * value + DoInvers(table[i, 0, 0], table[i, 0, 1], 1)), miejscPoPrzecinku);
                    //Console.WriteLine(DoInvers(table[i,0,0], table[i,0,1], 0) + " * " + value + " + " + DoInvers(table[i,0,0], table[i,0,1], 1));
                    //Console.WriteLine("PROG Q = " + progQ);
                    //Console.WriteLine();

                    //Console.WriteLine("P PRZEL. ALFA * var + PRZEL. BETA");
                    progP = Math.Round((DoInvers(table[i, 1, 0], table[i, 1, 1], 0) * value + DoInvers(table[i, 1, 0], table[i, 1, 1], 1)), miejscPoPrzecinku);
                    //Console.WriteLine(DoInvers(table[i,1,0], table[i,1,1], 0) + " * " + value + " + " + DoInvers(table[i,1,0], table[i,1,1], 1));
                    //Console.WriteLine("PROG P = " + progP);
                    //Console.WriteLine();

                    //Console.WriteLine("V PRZEL. ALFA * var + PRZEL. BETA");
                    progV = Math.Round((DoInvers(table[i, 2, 0], table[i, 2, 1], 0) * value + DoInvers(table[i, 2, 0], table[i, 2, 1], 1)), miejscPoPrzecinku);
                    //  Console.WriteLine(DoInvers(table[i,2,0], table[i,2,1], 0) + " * " + value + " + " + DoInvers(table[i,2,0], table[i,2,1], 1));
                    //  Console.WriteLine("PROG V = " + progV);
                    //  Console.WriteLine();
                    break;

                // mod direct
                case 1:
                    //  Console.WriteLine("CASE 1");
                    progQ = Math.Round((table[i, 0, 0] * value + table[i, 0, 1]), miejscPoPrzecinku);
                    //   Console.WriteLine(table[i,0,0] + " * " + value + " + " + table[i,0,1]);

                    progP = Math.Round((table[i, 1, 0] * value + table[i, 1, 1]), miejscPoPrzecinku);
                    //  Console.WriteLine(table[i,1,0] + " * " + value + " + " + table[i,1,1]);

                    progV = Math.Round((table[i, 2, 0] * value + table[i, 2, 1]), miejscPoPrzecinku);
                    // Console.WriteLine(table[i,2,0] + " * " + value + " + " + table[i,2,1]);
                    break;
            }
        }


        public void CreateConcordanceSets()
        {
            // var1 i var2 są to zmienne do których przypisujemy odpowiednie wartości alternatyw, a te są wykorzystywane w algorytmie
            double var2 = 0;
            double var1 = 0;
            // y1 i z1 są to współrzędne odpowiednio wiersza i kolumny zmiennej var1
            int y1 = 0;
            int z1 = 0;

            // TABELA ALTERNATYW INACZEJ MACIERZ -> WYCIETA TABELA Z INTERFEJSU CZYLI KOLUMNY TO KRYTERIA A WIERSZE TO ALTERNATYWY
            /* licz1 (poruszanie się po kolumnach(kryteriach) tabeliAlternatyw)*/
            for (int licz1 = 0; licz1 < numberOfCriterias; licz1++)
            {
                // dopisane
                //Console.WriteLine($"### Kierunek -> {listaKierunkow[licz1]}");
                Console.WriteLine($"### Mody -> {listaModow[licz1]}");
                
                /* tworzymy nowy obiekt matrixa (wymiar zależy od zadeklarowanej liczby alternatyw), do którego będą zapisywane nowe wartości */
                Double[,] matrixKryterium = new Double[numberOfAlternatives, numberOfAlternatives];

                // sprawdzamy czy kierunek rosnący
                if (listaKierunkow[licz1] == 1)
                {

                    // poruszanie się po kolumnach alternatyw
                    for (int i = 0; i < numberOfAlternatives; i++)
                    {

                        /* licz2 (poruszanie się po wierszach) */
                        for (int licz2 = 0; licz2 < numberOfAlternatives; licz2++)
                        {
                            if (i == 0 && licz2 == 0)
                            {
                                // na początku obydwie porównywalne wartości są takie same
                                var1 = tabelaAlternatyw[licz2, licz1];
                                y1 = licz2;
                                z1 = licz1;

                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            else
                            {
                                // w kolejnych krokach pierwsza wartość zmienia się dopiero przy pętli licz1
                                // a druga wartość właśnie teraz w tej pętli - jest to poruszanie się po tabelaAlternatyw[][]
                                // dla danej tabeli będzie to wartość z wiersza LICZ2 i kolumny LICZ1
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            switch (listaModow[licz1])
                            {
                                // stałe - bez wzoru
                                case -1:
                                    progQ = listaProguQB[licz1];
                                    progP = listaProguPB[licz1];
                                    progV = listaProguVB[licz1];
                                    break;
                                // inverse    
                                case 0:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var1, licz1, 0); }
                                    else { CalculateThreshold(listaWartProgKryt, var2, licz1, 0); }
                                    break;
                                // direct    
                                case 1:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var2, licz1, 1); }
                                    else { CalculateThreshold(listaWartProgKryt, var1, licz1, 1); }
                                    break;
                            }
                            //                      WEDŁUG ELECTRE III-IV ROYA #1
                            if (var2 >= (var1 + progP))
                            {
                                /* TO ZWRÓĆ WARTOŚĆ 0 */
                                matrixKryterium[i, licz2] = 0;
                            }
                            if ((var1 + progQ) < var2 && var2 < (var1 + progP))
                            {
                                double suma = (progP - var2 + var1) / (progP - progQ);
                                matrixKryterium[i, licz2] = Math.Round(suma, miejscPoPrzecinku);
                                suma = 0;
                            }
                            if (var2 <= (var1 + progQ))
                            {
                                /* TO ZWRÓĆ WARTOŚĆ 1 */
                                matrixKryterium[i, licz2] = 1;
                            }
                        }
                        if (y1 + 1 < numberOfAlternatives)
                        {
                            y1 = y1 + 1;
                            var1 = tabelaAlternatyw[y1, z1];
                        }
                    }
                }
                // sprawdzamy czy kierunek malejący
                else if (listaKierunkow[licz1] == 0)
                {
                    for (int i = 0; i < numberOfAlternatives; i++)
                    {

                        /* licz2 (poruszanie się po wierszach) */
                        for (int licz2 = 0; licz2 < numberOfAlternatives; licz2++)
                        {
                            if (i == 0 && licz2 == 0)
                            {
                                // na początku obydwie porównywalne wartości są takie same
                                var1 = tabelaAlternatyw[licz2, licz1];
                                y1 = licz2;
                                z1 = licz1;

                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            else
                            {
                                // w kolejnych krokach pierwsza wartość zmienia się dopiero przy pętli licz1
                                // a druga wartość właśnie teraz w tej pętli - jest to poruszanie się po tabelaAlternatyw[][]
                                // dla danej tabeli będzie to wartość z wiersza LICZ2 i kolumny LICZ1
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            switch (listaModow[licz1])
                            {
                                case -1:
                                    progQ = listaProguQB[licz1];
                                    progP = listaProguPB[licz1];
                                    progV = listaProguVB[licz1];
                                    break;
                                case 0:
                                    if (var1 < var2)
                                    {
                                        CalculateThreshold(listaWartProgKryt, var2, licz1, 0);
                                    }
                                    else
                                    {
                                        CalculateThreshold(listaWartProgKryt, var1, licz1, 0);
                                    }
                                    break;
                                case 1:
                                    if (var1 < var2)
                                    {
                                        CalculateThreshold(listaWartProgKryt, var1, licz1, 1);
                                    }
                                    else
                                    {
                                        CalculateThreshold(listaWartProgKryt, var2, licz1, 1);
                                    }
                                    break;
                            }
                            //                      WEDŁUG ELECTRE III-IV ROYA
                            if (var1 - progP > var2)
                            {
                                /* TO ZWRÓĆ WARTOŚĆ 0 */
                                matrixKryterium[i, licz2] = 0;
                            }
                            if (progQ < (var1 - var2) && (var1 - var2) < progP)
                            {
                                double suma = (progP - var1 + var2) / (progP - progQ);
                                matrixKryterium[i, licz2] = Math.Round(suma, miejscPoPrzecinku);
                                suma = 0;
                            }
                            if (var1 - var2 <= progQ)
                            {
                                /* TO ZWRÓĆ WARTOŚĆ 1 */
                                matrixKryterium[i, licz2] = 1;
                            }
                        }
                        if (y1 + 1 < numberOfAlternatives)
                        {
                            y1 = y1 + 1;
                            var1 = tabelaAlternatyw[y1, z1];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("BŁĘDNE DANE W KOMORKACH KIERUNKOW, może być tylko 0 lub 1");
                }
                listaZbiorowZgodnosci.Add(matrixKryterium);
            }
        }


        public void CreateDiscordanceSets()
        {
            // var1 i var2 są to zmienne do których przypisujemy odpowiednie wartości alternatyw, a te są wykorzystywane w algorytmie
            double var2 = 0;
            double var1 = 0;
            // y1 i z1 są to współrzędne odpowiednio wiersza i kolumny zmiennej var1
            int y1 = 0;
            int z1 = 0;

            /* licz1 (poruszanie się po kolumnach / kryteriach)*/
            for (int licz1 = 0; licz1 < numberOfCriterias; licz1++)
            {
                /* tworzymy nowy obiekt matrixa (wymiar zależy od zadeklarowanej liczby alternatyw), do którego będą zapisywane nowe wartości */
                Double[,] matrixKryterium = new double[numberOfAlternatives, numberOfAlternatives];
                // sprawdzamy czy kierunek rosnący
                if (listaKierunkow[licz1] == 1)
                {
                    // poruszanie się po kolumnach alternatyw
                    for (int i = 0; i < numberOfAlternatives; i++)
                    {
                        /* licz2 (poruszanie się po wierszach) */
                        for (int licz2 = 0; licz2 < numberOfAlternatives; licz2++)
                        {
                            if (i == 0 && licz2 == 0)
                            {
                                // na początku obydwie porównywalne wartości są takie same
                                var1 = tabelaAlternatyw[licz2, licz1];
                                y1 = licz2;
                                z1 = licz1;
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            else
                            {
                                // w kolejnych krokach pierwsza wartość zmienia się dopiero przy pętli licz1
                                // a druga wartość właśnie teraz w tej pętli - jest to poruszanie się po tabelaAlternatyw[][]
                                // dla danej tabeli będzie to wartość z wiersza LICZ2 i kolumny LICZ1
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }

                            switch (listaModow[licz1])
                            {
                                case -1:
                                    progQ = listaProguQB[licz1];
                                    progP = listaProguPB[licz1];
                                    progV = listaProguVB[licz1];
                                    break;
                                case 0:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var1, licz1, 0); }
                                    else { CalculateThreshold(listaWartProgKryt, var2, licz1, 0); }
                                    break;
                                case 1:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var2, licz1, 1); }
                                    else { CalculateThreshold(listaWartProgKryt, var1, licz1, 1); }
                                    break;
                            }

                            if (listaWartProgKryt[licz1, 2, 0] == 999999999.9)
                            {
                                matrixKryterium[i, licz2] = 0;
                            }
                            //                  WEDŁUG ROYA
                            else if (var2 <= var1 + progP)
                            {
                                matrixKryterium[i, licz2] = 0;
                            }
                            else if (progP < var2 - var1 && var2 - var1 < progV)
                            {
                                //  Console.WriteLine("var2 - var1 - progP / progV - progP");
                                //  Console.WriteLine(var2 + " - " + var1 + " - " + progP + " / " + progV + " - " + progP);
                                double suma = ((var2 - var1 - progP) / (progV - progP));
                                matrixKryterium[i, licz2] = Math.Round(suma, miejscPoPrzecinku);
                                //suma = 0;
                            }
                            else if (var2 >= var1 + progV)
                            {
                                matrixKryterium[i, licz2] = 1;
                            }
                        }

                        if (y1 + 1 < numberOfAlternatives)
                        {
                            y1 = y1 + 1;
                            var1 = tabelaAlternatyw[y1, z1];
                        }
                    }
                }
                // sprawdzamy czy kierunek malejący
                else if (listaKierunkow[licz1] == 0)
                {
                    for (int i = 0; i < numberOfAlternatives; i++)
                    {
                        /* licz2 (poruszanie się po wierszach) */
                        for (int licz2 = 0; licz2 < numberOfAlternatives; licz2++)
                        {
                            if (i == 0 && licz2 == 0)
                            {
                                // na początku obydwie porównywalne wartości są takie same
                                var1 = tabelaAlternatyw[licz2, licz1];
                                y1 = licz2;
                                z1 = licz1;
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }
                            else
                            {
                                // w kolejnych krokach pierwsza wartość zmienia się dopiero przy pętli licz1
                                // a druga wartość właśnie teraz w tej pętli - jest to poruszanie się po tabelaAlternatyw[][]
                                // dla danej tabeli będzie to wartość z wiersza LICZ2 i kolumny LICZ1
                                var2 = tabelaAlternatyw[licz2, licz1];
                            }

                            switch (listaModow[licz1])
                            {
                                case -1:
                                    progQ = listaProguQB[licz1];
                                    progP = listaProguPB[licz1];
                                    progV = listaProguVB[licz1];
                                    break;
                                case 0:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var2, licz1, 0); }
                                    else { CalculateThreshold(listaWartProgKryt, var1, licz1, 0); }
                                    break;
                                case 1:
                                    if (var1 < var2) { CalculateThreshold(listaWartProgKryt, var2, licz1, 1); }
                                    else { CalculateThreshold(listaWartProgKryt, var1, licz1, 1); }
                                    break;
                            }

                            if (listaWartProgKryt[licz1, 2, 0] == 999999999.9)
                            {
                                matrixKryterium[i, licz2] = 0;
                            }
                            //                  WEDŁUG ROYA
                            else if ((var1 - var2) <= progP)
                            {
                                // Console.WriteLine(var1 + " - " + var2 + " <= " + progP);
                                matrixKryterium[i, licz2] = 0;
                            }
                            else if (var1 - progV < var2 && var2 < var1 - progP)
                            {
                                //  Console.WriteLine("progP < var1 - var2 && var1 - var2 < progV");
                                //  Console.WriteLine(progP + " < " + var1 + " - " + var2 + " && " + var1 + " - " + var2 + " < " + progV);
                                double suma = ((var1 - var2 - progP) / (progV - progP));
                                matrixKryterium[i, licz2] = Math.Round(suma, miejscPoPrzecinku);
                                suma = 0;
                            }
                            else if ((var1 - var2) >= progV)
                            {
                                matrixKryterium[i, licz2] = 1;
                            }
                        }

                        if (y1 + 1 < numberOfAlternatives)
                        {
                            y1 = y1 + 1;
                            var1 = tabelaAlternatyw[y1, z1];
                        }
                    }
                }

                listaZbiorowNieZgodnosci.Add(matrixKryterium);
            }
        }


        public void CreateFinalRanking(ref Double[,] tabSum)
        {
            listaAlternatyw = new List<List<Int32>>();
            // budowanie listy kto z kim przegrywa
            for (int i = 0; i < tabSum.GetLength(0); i++)
            {
                listaKtoZKimPrzegral = new List<Int32>();
                for (int j = 0; j < tabSum.GetLength(1); j++)
                {
                    if (tabSum[i, j] == -1)
                    {
                        listaKtoZKimPrzegral.Add((j + 1));
                    }
                }
                listaAlternatyw.Add(listaKtoZKimPrzegral);
            }

            listaRank = new List<List<Int32>>();
            listaAltWRank = new List<Int32>();
            listaAltWRankNieSort = new List<Int32>();
            listaChwilowa = new List<Int32>();

            FindMin();
            ChangeRankListToTable(listaRank);

            if (CboxRankingsChecked)
            {
                PreparedDataTable(ref finalRanking, "Rank. Final.");
            }
        }


        public void ChangeRankListToTable(List<List<Int32>> listaRank)
        {
            for (int i = 0; i < listaRank.Count; i++)
            {
                for (int j = 0; j < listaRank[i].Count; j++)
                {
                    finalRanking[1, listaRank[i][j] - 1] = (double)(i + 1);
                }
            }
        }


        public void CreateOutrankingSets()
        {
            //  Console.WriteLine("SPRAWDZAMY listaZbiorowNieZgodnosci.size() =" + listaZbiorowNieZgodnosci.Count);
            for (int numerZbioru = 0; numerZbioru < listaZbiorowNieZgodnosci.Count; numerZbioru++)
            {
                /* tworzymy nowy obiekt matrixa (wymiar zależy od zadeklarowanej liczby alternatyw), do którego będą zapisywane nowe wartości */
                Double[,] matrixKryterium = new double[numberOfAlternatives, numberOfAlternatives];
                for (int numerWiersza = 0; numerWiersza < listaZbiorowNieZgodnosci[numerZbioru].GetLength(0); numerWiersza++)
                {
                    for (int numerKolumny = 0; numerKolumny < listaZbiorowNieZgodnosci[numerZbioru].GetLength(1); numerKolumny++)
                    {
                        if (listaZbiorowNieZgodnosci[numerZbioru][numerWiersza, numerKolumny] > concordanceMatrix[numerWiersza, numerKolumny])
                        {
                            matrixKryterium[numerWiersza, numerKolumny] = 1;
                        }
                        else
                        {
                            matrixKryterium[numerWiersza, numerKolumny] = 0;
                        }
                    }
                }
                listaZbiorowPrzewyzszania.Add(matrixKryterium);
            }
        }


        public void CreateSumTableOfDistillations(ref Double[,] tabSum)
        {
            tabSum = new double[numberOfAlternatives, numberOfAlternatives];
            for (int i = 0; i < tabSum.GetLength(0); i++)
            {
                for (int j = 0; j < tabSum.GetLength(1); j++)
                {
                    if (tabZstep[i, j] == 1 && tabWstep[i, j] == 1)
                    {
                        tabSum[i, j] = 1;
                    }
                    else if ((tabZstep[i, j] == 1 && tabWstep[i, j] == 0) || (tabZstep[i, j] == 0 && tabWstep[i, j] == 1))
                    {
                        tabSum[i, j] = 1;
                    }
                    else if ((tabZstep[i, j] == 0 && tabWstep[i, j] == 0))
                    {
                        tabSum[i, j] = 0;
                    }
                    else if ((tabZstep[i, j] == 0 && tabWstep[i, j] == -1) || (tabZstep[i, j] == -1 && tabWstep[i, j] == 0))
                    {
                        tabSum[i, j] = -1;
                    }
                    else if ((tabZstep[i, j] == -1 && tabWstep[i, j] == -1))
                    {
                        tabSum[i, j] = -1;
                    }
                    else if ((tabZstep[i, j] == -1 && tabWstep[i, j] == 1) || (tabZstep[i, j] == 1 && tabWstep[i, j] == -1))
                    {
                        tabSum[i, j] = 2;
                    }
                }
            }
        }


        public delegate Boolean TestOperationDelegate(int i, int j, double[,] placesOfOptionsAfterDistillation);


        private Boolean LessOperation(int i, int j, double[,] placesOfOptionsAfterDistillation) { return (placesOfOptionsAfterDistillation[1, i] < placesOfOptionsAfterDistillation[1, j]); }


        private Boolean GreaterOperation(int i, int j, double[,] placesOfOptionsAfterDistillation) { return (placesOfOptionsAfterDistillation[1, i] > placesOfOptionsAfterDistillation[1, j]); }


        public void CreateTabOfDistillation(ref double[,] tableOfDistillation, ref Double[,] placesOfOptionsAfterDistillation, int valueX, int valueY, int valueZ, TestOperationDelegate testOperationDelegate)
        {
            tableOfDistillation = new double[numberOfAlternatives, numberOfAlternatives];
            for (int i = 0; i < tableOfDistillation.GetLength(0); i++)
            {
                for (int j = 0; j < tableOfDistillation.GetLength(1); j++)
                {
                    if (testOperationDelegate(i, j, placesOfOptionsAfterDistillation))
                    {
                        tableOfDistillation[i, j] = valueX;
                    }
                    else if (placesOfOptionsAfterDistillation[1, i] == placesOfOptionsAfterDistillation[1, j])
                    {
                        tableOfDistillation[i, j] = valueY;
                    }
                    else
                    {
                        tableOfDistillation[i, j] = valueZ;
                    }
                }
            }
        }


        public void ShowTabOfDistillation(ref Double[,] tab)
        {
            Console.WriteLine("TAB DEST");
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        double valueOfConcordance;

        public void CreateConcordanceMatrix()
        {
            concordanceMatrix = new Double[numberOfAlternatives, numberOfAlternatives];
            double sumOfQuotients = 0;
            double sumOfWeights = 0;

            WriteConcordaceSetsIntoConsoleOutput(listaZbiorowZgodnosci);

            // wybór kolumny
            for (int j = 0; j < numberOfAlternatives; j++)
            {
                // wybór wiersza
                for (int k = 0; k < numberOfAlternatives; k++)
                {
                    sumOfWeights = 0;
                    sumOfQuotients = 0;

                    // wybór zbioru zgodnosci dla i-tego kryterium
                    for (int i = 0; i < listaZbiorowZgodnosci.Count; i++)
                    {
                        sumOfQuotients = sumOfQuotients + (listaWagW[i] * (double)listaZbiorowZgodnosci[i][k, j]);

                        // dopisane
                        Console.Write("K"+i+" ");
                        Console.WriteLine(listaWagW[i] + " " + "*" + (double)listaZbiorowZgodnosci[i][k, j]);
                        
                        sumOfWeights = sumOfWeights + listaWagW[i];
                    }

                    // dopisane
                    Console.WriteLine("\n");
                    Console.WriteLine($"Suma wag = {sumOfWeights}");

                    if (sumOfWeights == 0)
                    {
                        valueOfConcordance = 0;
                    }
                    else
                    {
                        valueOfConcordance = (sumOfQuotients / sumOfWeights);
                    }

                    concordanceMatrix[k, j] = Math.Round(valueOfConcordance, miejscPoPrzecinku);
                    
                    // dopisane
                    Console.WriteLine($"wartość concordance[{k},{j}] = {concordanceMatrix[k, j]}");
                    Console.WriteLine();

                }
            }
        }


        public void DoCalculations()
        {

            DivideThresholdsToLists();
            CreateMatrixForAlternativeData(numberOfAlternatives, numberOfCriterias);

            CreateConcordanceSets();
            CreateConcordanceMatrix();
            CreateDiscordanceSets();
            CreateOutrankingSets();
            DoStageFirst();
            DoStageSecond();
            PrepareTopDownDistillation();

            // wykonaj destylacje zstępującą
            //Console.WriteLine("WIERSZY W ROBOCZYMATRIXDOGOL" + roboczyMatrixDOgol.GetLength(0));
            //Console.WriteLine("liczba numerow NAZWOPCJIOGOLZSTEP = " + listaNumerowZNazwOpcjiOgolZstep.Count);
            DoStepSecond(roboczyMatrixDOgol, typDestylacji, listaNumerowZNazwOpcjiOgolZstep);

            PrepareUpwardDistillation();

            // wykonaj destylację wstępującą
            DoStepSecond(roboczyMatrixDOgol, typDestylacji, listaNumerowZNazwOpcjiOgolWstep);

            PrepareUpwardScore();

            TestOperationDelegate testOperation;
            testOperation = GreaterOperation;
            CreateTabOfDistillation(ref tabZstep, ref topDownRanking, -1, 0, 1, testOperation);
            //ShowTabOfDistillation(ref tabZstep);
            testOperation = LessOperation;
            CreateTabOfDistillation(ref tabWstep, ref upwardRanking, 1, 0, -1, testOperation);
            //ShowTabOfDistillation(ref tabWstep);
            CreateSumTableOfDistillations(ref finalRankingMatrix);
            //ShowTabOfDistillation(ref finalRankingMatrix);

            CreateFinalRanking(ref finalRankingMatrix);
        }


        List<string> listOfPathsImages = new List<string>();

        public List<string> ListOfPathsImages { get { return listOfPathsImages; } }

        public void PreparedImagesAndShowCollections()
        {

            string ps = AppDomain.CurrentDomain.BaseDirectory;
            listOfPathsImages.Add(ps + "\\MathImg\\wzor_mal_direct_prog.PNG");
            listOfPathsImages.Add(ps + "\\MathImg\\wzor_rosn_direct_prog.PNG");
            listOfPathsImages.Add(ps + "\\MathImg\\wzor_mal_invers_prog.PNG");
            listOfPathsImages.Add(ps + "\\MathImg\\wzor_rosn_invers_prog.PNG");
            listOfPathsImages.Add(ps + "\\MathImg\\wzor_przeliczanie_wspolczynnikow.PNG");

            if (CboxConcordanceSetsChecked)
            {
                ShowSets(ref listaZbiorowZgodnosci, "Zgodności");
                listOfPathsImages.Add(ps + "\\MathImg\\wspolczynnik_zgodnosci_kryterium_rosn.PNG");
                listOfPathsImages.Add(ps + "\\MathImg\\wspolczynnik_zgodnosci_kryterium_mal.PNG");
            }

            if (CboxConcordanceMatrixChecked)
            {
                ShowMatrix(ref concordanceMatrix, "Zgodności");
                listOfPathsImages.Add(ps + "\\MathImg\\indeks_zgodnosci.PNG");
            }

            if (CboxNonConcordanceSetsChecked)
            {
                ShowSets(ref listaZbiorowNieZgodnosci, "Niegodności");
                listOfPathsImages.Add(ps + "\\MathImg\\wspolczynnik_niezgodnosci_kryterium_rosn.PNG");
                listOfPathsImages.Add(ps + "\\MathImg\\wspolczynnik_niezgodnosci_kryterium_mal.PNG");
            }

            if (CboxOutrankingSetsChecked)
            {
                ShowSets(ref listaZbiorowPrzewyzszania, "Przewyższania");
                listOfPathsImages.Add(ps + "\\MathImg\\WartoscPrzewyzszania.JPG");
            }

            if (CboxSetEqualityMatrixChecked)
            {
                ShowMatrix(ref matrixRownosciZbiorowPrzewyzszania, "Równości Zbiorów Przewyższania");
            }

            if (CboxCredibilityMatrixChecked)
            {
                ShowMatrix(ref credibilityMatrix, "Wiarygodności");
                listOfPathsImages.Add(ps + "\\MathImg\\indeks_wiarygodnosci.PNG");
            }

            if (CboxTopDownDistillationChecked)
            {
                ShowDistillation("ZSTĘPUJĄCA", topDownRanking);
            }

            if (CboxUpwardDistillationChecked)
            {
                ShowDistillation("WSTĘPUJĄCA", upwardRanking);
            }

            if (CboxUpwardDistillationChecked || CboxTopDownDistillationChecked)
            {
                listOfPathsImages.Add(ps + "\\MathImg\\alfa_zero.PNG");
                listOfPathsImages.Add(ps + "\\MathImg\\s_alfa.PNG");
                listOfPathsImages.Add(ps + "\\MathImg\\alfa_nplus.PNG");
            }

            if (CboxRankingsChecked)
            {
                PreparedDataTable(ref topDownRanking, "Rank. Zstep.");
                PreparedDataTable(ref upwardRanking, "Rank. Wstep.");
                // zakomentowuje bo naprawiam blad z FindMini
                PreparedDataTable(finalRankingMatrix, "Finalna Macierz Zależności", lul);
            }

            //if (CboxRatingMatrixChecked)
            //{ // , workingListOfNumbersOfOptions
            //    foreach (Double[,] macierz in listaZstepMacierzyOcen) { PreparedDataTable(macierz, "Macierz Ocen " + listaZstepMacierzyOcen.Count + " (D.Z.)"); }
            //    foreach (Double[,] macierz in listaWstepMacierzyOcen) { PreparedDataTable(macierz, "Macierz Ocen " + listaWstepMacierzyOcen.Count + " (D.W.)"); }
            //}
        }

        public void ShowList<T>(List<T> list, string name)
        {
            Console.WriteLine(name);
            for (int z = 0; z < numberOfCriterias; z++)
            {
                Console.Write(list[z] + " ");
            }
            Console.WriteLine();
        }

        public void DivideThresholdsToLists()
        {
            /*
                uzupełnianie listy kierunków -> pobieranie wartości z matrixa tabeli
                wartość kierunku ( 0 lub 1 ) mówi nam czy wartości ujemne ( 0 ) czy wartości dodatnie ( 1 ) 
                dla danego kryterium są lepsze od tych drugich
                np. kryterium pojemność silnika im większa wartość ( wartość kierunku 1 ) tym lepiej dla danej alternatywy (motoru)
                np. kryterium oddległość od centrum miasta im mniejsza wartość ( wartość kierunku 0 ) tym lepiej dla danej alternatywy (nieruchomości)
            */

            for (int z = 0; z < numberOfCriterias; z++)
            {
                listaKierunkow.Add(tabelaMatrix[0, z]);
                listaModow.Add((Int32)(tabelaMatrix[1, z]));
                // uzupełnianie listy Wag W -> pobieranie wartości z matrixa tabeli
                listaWagW.Add(tabelaMatrix[2, z]);
                // uzupełnianie listy Progu Q -> pobieranie wartości z matrixa tabeli
                listaProguQA.Add(tabelaMatrix[3, z]);
                // uzupełnianie listy Progu P -> pobieranie wartości z matrixa tabeli        
                listaProguPA.Add(tabelaMatrix[4, z]);
                // uzupełnianie listy Progu V -> pobieranie wartości z matrixa tabeli        
                listaProguVA.Add(tabelaMatrix[5, z]);
                // uzupełnianie listy Progu Q -> pobieranie wartości z matrixa tabeli        
                listaProguQB.Add(tabelaMatrix[6, z]);
                // uzupełnianie listy Progu P -> pobieranie wartości z matrixa tabeli        
                listaProguPB.Add(tabelaMatrix[7, z]);
                // uzupełnianie listy Progu V -> pobieranie wartości z matrixa tabeli        
                listaProguVB.Add(tabelaMatrix[8, z]);
            }

            // ShowList(listaKierunkow, "K");


            /*            for (int z = 0; z < numberOfCriterias; z++) {

                        }*/

            // ShowList(listaModow, "M");

            // uzupełnianie listy Wag W -> pobieranie wartości z matrixa tabeli
            /*            for (int z = 0; z < numberOfCriterias; z++) {

                        }*/

            //ShowList(listaWagW, "W");

            //Console.WriteLine();


            // uzupełnianie listy Progu Q -> pobieranie wartości z matrixa tabeli        
            /*            for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguQA.Add(tabelaMatrix[3, z]);
                        }*/

            // ShowList(listaProguQA, "QA");

            // uzupełnianie listy Progu P -> pobieranie wartości z matrixa tabeli        
            /*            for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguPA.Add(tabelaMatrix[4, z]);
                        }*/

            //  ShowList(listaProguPA, "PA");


            /*            // uzupełnianie listy Progu V -> pobieranie wartości z matrixa tabeli        
                        for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguVA.Add(tabelaMatrix[5, z]);
                        }

                     //   ShowList(listaProguVA, "VA");

                        // uzupełnianie listy Progu Q -> pobieranie wartości z matrixa tabeli        
                        for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguQB.Add(tabelaMatrix[6, z]);
                        }

                     //   ShowList(listaProguQB, "QB");


                        // uzupełnianie listy Progu P -> pobieranie wartości z matrixa tabeli        
                        for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguPB.Add(tabelaMatrix[7, z]);
                        }

                       // ShowList(listaProguPB, "PB");


                        // uzupełnianie listy Progu V -> pobieranie wartości z matrixa tabeli        
                        for (int z = 0; z < numberOfCriterias; z++) {
                            listaProguVB.Add(tabelaMatrix[8, z]);
                        }*/

            // ShowList(listaProguVB, "VB");



            topDownRanking = new double[2, numberOfAlternatives];
            upwardRanking = new double[2, numberOfAlternatives];
            finalRanking = new Double[2, numberOfAlternatives];
            punktacjaOpcji = new String[2, numberOfAlternatives];
            punktacjaOpcjiZmienna = new String[2, numberOfAlternatives];

            for (int z = 0; z < numberOfAlternatives; z++)
            {
                listaNumerowZNazwOpcji.Add(z);
                listaNumerowZNazwOpcjiOgolZstep.Add(z);
                listaNumerowZNazwOpcjiOgolWstep.Add(z);

                topDownRanking[0, z] = (z + 1);
                topDownRanking[1, z] = 0;
                //finalRanking[0,z] = "A" + (z + 1);
                finalRanking[0, z] = (double)(z + 1);
                //finalRanking[1,z] = "0";
                finalRanking[1, z] = 0.0;
                upwardRanking[0, z] = (z + 1);
                upwardRanking[1, z] = 0;
                punktacjaOpcji[0, z] = "A" + (z + 1);
                punktacjaOpcji[1, z] = "0";
            }

            /*            for (int z = 0; z < numberOfAlternatives; z++) {
                            topDownRanking[0,z] = (z + 1);
                            topDownRanking[1,z] = 0;
                            //finalRanking[0,z] = "A" + (z + 1);
                            finalRanking[0, z] = (double)(z + 1);
                            //finalRanking[1,z] = "0";
                            finalRanking[1, z] = 0.0;
                            upwardRanking[0,z] = (z + 1);
                            upwardRanking[1,z] = 0;
                            punktacjaOpcji[0,z] = "A" + (z + 1);
                            punktacjaOpcji[1,z] = "0";
                        }*/
        }


        public double DoInvers(double symbolA, double symbolB, int positionOfSymbol)
        {
            double symbol = 0;

            switch (positionOfSymbol)
            {
                // obliczamy alfe
                case 0:
                    symbol = (symbolA) / (1 + symbolA);
                    break;
                // obliczamy bete
                case 1:
                    symbol = (symbolB) / (1 + symbolA);
                    break;
            }

            return Math.Round(symbol, miejscPoPrzecinku);
        }


        Double testLogiczny = 0.0;
        Boolean testDC = false;

        public void DoStageFirst()
        {
            // matrix -> jedna tabela do zapisu inf. czy wartosci z takiej samej komorki ale dla roznych zbiorow przewyzszania sa sobie równe
            matrixRownosciZbiorowPrzewyzszania = new double[numberOfAlternatives, numberOfAlternatives];
            //  Console.WriteLine("alternatywy wartosc: " + numberOfAlternatives);
            for (int numerWiersza = 0; numerWiersza < matrixRownosciZbiorowPrzewyzszania.GetLength(0); numerWiersza++)
            {
                for (int numerKolumny = 0; numerKolumny < matrixRownosciZbiorowPrzewyzszania.GetLength(1); numerKolumny++)
                {
                    //suma2 = 0.0;
                    for (int numerZbioruPrzewyzsszania = 0; numerZbioruPrzewyzsszania < listaZbiorowPrzewyzszania.Count; numerZbioruPrzewyzsszania++)
                    {
                        if (1 == listaZbiorowPrzewyzszania[numerZbioruPrzewyzsszania][numerWiersza, numerKolumny])
                        {
                            testDC = true;
                            break;
                        }
                    }
                    if (testDC) { testLogiczny = 1.0; }
                    else { testLogiczny = 0.0; }
                    //  Console.WriteLine("wartosc testu: " + testLogiczny);
                    //  Console.WriteLine("wartosc wiersza: " + numerWiersza);
                    //  Console.WriteLine("wartosc kolumny: " + numerKolumny);
                    matrixRownosciZbiorowPrzewyzszania[numerWiersza, numerKolumny] = testLogiczny;
                }
            }
        }


        public void DoStageSecond()
        {
            double iloczyn = 1;
            double zmiennaPomocnicza = 0;
            credibilityMatrix = new Double[numberOfAlternatives, numberOfAlternatives];
            roboczyMatrixDOgol = new Double[numberOfAlternatives, numberOfAlternatives];
            //  Console.WriteLine("DoStageSecond sprawdzamy");
            //  Console.WriteLine("roboczyMatrixDOgol kolumn i wierszy = " + roboczyMatrixDOgol.GetLength(0));
            for (int numerWiersza = 0; numerWiersza < credibilityMatrix.GetLength(0); numerWiersza++)
            {
                for (int numerKolumny = 0; numerKolumny < credibilityMatrix.GetLength(1); numerKolumny++)
                {
                    if (matrixRownosciZbiorowPrzewyzszania[numerWiersza, numerKolumny] == 0.0)
                    {
                        credibilityMatrix[numerWiersza, numerKolumny] = concordanceMatrix[numerWiersza, numerKolumny];
                        roboczyMatrixDOgol[numerWiersza, numerKolumny] = concordanceMatrix[numerWiersza, numerKolumny];
                    }
                    else
                    {
                        for (int numerZbioru = 0; numerZbioru < listaZbiorowNieZgodnosci.Count; numerZbioru++)
                        {
                            if (listaZbiorowNieZgodnosci[numerZbioru][numerWiersza, numerKolumny] >= concordanceMatrix[numerWiersza, numerKolumny])
                            {
                                // zapobiegnięcie dzielenia przez 0
                                if ((1 - concordanceMatrix[numerWiersza, numerKolumny]) == 0)
                                {
                                    zmiennaPomocnicza = 0;
                                }
                                else
                                {
                                    zmiennaPomocnicza = ((1 - listaZbiorowNieZgodnosci[numerZbioru][numerWiersza, numerKolumny]) / (1 - concordanceMatrix[numerWiersza, numerKolumny]));
                                }
                                iloczyn = iloczyn * zmiennaPomocnicza;
                            }
                        }
                        if (iloczyn == 0)
                        {
                            credibilityMatrix[numerWiersza, numerKolumny] = 0;
                            roboczyMatrixDOgol[numerWiersza, numerKolumny] = 0;
                        }
                        else
                        {
                            iloczyn = concordanceMatrix[numerWiersza, numerKolumny] * iloczyn;
                            iloczyn = Math.Round(iloczyn, miejscPoPrzecinku);
                            credibilityMatrix[numerWiersza, numerKolumny] = iloczyn;
                            roboczyMatrixDOgol[numerWiersza, numerKolumny] = iloczyn;
                        }
                        iloczyn = 1;
                        zmiennaPomocnicza = 0;
                    }
                }
            }
        }


        int liczenieKrok2 = 0;

        // public void DoStepSecond(ref double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        public void DoStepSecond(double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            liczenieKrok2++;
            Console.WriteLine("Krok2 po raz -> {0}", liczenieKrok2);

            Console.WriteLine("Krok 2");
            //Console.WriteLine("workingMatrix wierszy = " + workingMatrix.GetLength(0) + " kolumn = " + workingMatrix.GetLength(1)+"\n\n");
            double deltaMax = 0.0;
            for (int numerWiersza = 0; numerWiersza < workingMatrix.GetLength(0); numerWiersza++)
            {
                for (int numerKolumny = 0; numerKolumny < workingMatrix.GetLength(1); numerKolumny++)
                {
                    if (workingMatrix[numerWiersza, numerKolumny] > deltaMax && numerWiersza != numerKolumny)
                    {
                        deltaMax = workingMatrix[numerWiersza, numerKolumny];
                    }
                }
            }
            if (deltaMax != 0)
            {
                Console.WriteLine("Krok 2 - DeltaMax = " + deltaMax);
                DoStepFourth(deltaMax, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
            }
            else
            {
                Console.WriteLine("KONIEC przy KROK 2");
                DoStepFourth(deltaMax, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
            }
        }


        Double zmiennaPomocnicza = 0.0;
        Double wartoscMax = 0.0;

        public void DoStepFourth(double deltaLast, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            Console.WriteLine("Krok 4");
            Boolean testDelta = false;
            zmiennaPomocnicza = deltaLast - CalculateSDeltaK(deltaLast);
            Console.WriteLine("deltaLast - ObliczSDeltaK(deltaLast) poniżej");
            Console.WriteLine(deltaLast + " - " + CalculateSDeltaK(deltaLast));
            Console.WriteLine("zmiennaPomocnicza = " + zmiennaPomocnicza);
            for (int numerWiersza = 0; numerWiersza < workingMatrix.GetLength(0); numerWiersza++)
            {
                for (int numerKolumny = 0; numerKolumny < workingMatrix.GetLength(1); numerKolumny++)
                {
                    if (workingMatrix[numerWiersza, numerKolumny] < zmiennaPomocnicza)
                    {
                        testDelta = true;
                        break;
                    }
                }
            }
            Console.WriteLine("testDelta = " + testDelta);
            if (testDelta == false) { newDelta = 0.0; }
            else
            {
                wartoscMax = 0.0;
                for (int numerWiersza = 0; numerWiersza < workingMatrix.GetLength(0); numerWiersza++)
                {
                    for (int numerKolumny = 0; numerKolumny < workingMatrix.GetLength(1); numerKolumny++)
                    {
                        if (workingMatrix[numerWiersza, numerKolumny] > wartoscMax && workingMatrix[numerWiersza, numerKolumny] < zmiennaPomocnicza && numerWiersza != numerKolumny)
                        {
                            wartoscMax = workingMatrix[numerWiersza, numerKolumny];
                        }
                    }
                }
                newDelta = wartoscMax;
            }
            Console.WriteLine("Wartość współczynnika Alfa (newDelta) = " + newDelta);
            //  Console.WriteLine("Krok 4");
            DoStepFifth(newDelta, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
        }


        Double zmiennaPomocnicza1 = 0.0;
        double zmiennaPomocna = 0.0;

        public void DoStepFifth(double lastDelta, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {

            Console.WriteLine("Krok 5");
            Double[,] macierzWygranych = new Double[workingMatrix.GetLength(0), workingMatrix.GetLength(1)];
            //listaMacierzyWygranych
            List<Int32> listaNazwOpcjiMacOc = new List<Int32>();
            // macierz dla power(wiersz 0) weakness (wiersz 1) i qualification (wieresz 2)
            Double[,] macierzOcen = new Double[4, workingMatrix.GetLength(1)];

            for (int numerWiersza = 0; numerWiersza < workingMatrix.GetLength(0); numerWiersza++)
            {
                for (int numerKolumny = 0; numerKolumny < workingMatrix.GetLength(1); numerKolumny++)
                {

                    zmiennaPomocnicza1 = workingMatrix[numerWiersza, numerKolumny] - CalculateSDeltaK(workingMatrix[numerWiersza, numerKolumny]);
                    //    Console.WriteLine("zmiennaPomocnicza1 = workingMatrix[numerWiersza, numerKolumny] - CalculateSDeltaK(workingMatrix[numerWiersza, numerKolumny])");
                    Console.WriteLine("zmiennaPomocnicza1 = {0} - {1}", workingMatrix[numerWiersza, numerKolumny], CalculateSDeltaK(workingMatrix[numerWiersza, numerKolumny]));

                    if (zmiennaPomocnicza1 > workingMatrix[numerKolumny, numerWiersza] && workingMatrix[numerWiersza, numerKolumny] > lastDelta)
                    {
                        macierzWygranych[numerWiersza, numerKolumny] = 1;
                        zmiennaPomocna = macierzOcen[1, numerWiersza] + 1;
                        macierzOcen[1, numerWiersza] = zmiennaPomocna;
                        zmiennaPomocna = macierzOcen[2, numerKolumny] - 1;
                        macierzOcen[2, numerKolumny] = zmiennaPomocna;
                    }
                    else { macierzWygranych[numerWiersza, numerKolumny] = 0; }
                }
            }

            int kolumnaOceny;
            double zmiennaTymczasowa;

            for (kolumnaOceny = 0; kolumnaOceny < macierzOcen.GetLength(1); kolumnaOceny++)
            {
                zmiennaTymczasowa = macierzOcen[1, kolumnaOceny] + macierzOcen[2, kolumnaOceny];
                macierzOcen[3, kolumnaOceny] = zmiennaTymczasowa;
                macierzOcen[0, kolumnaOceny] = workingListOfNumbersOfOptions[kolumnaOceny] + 1;
            }

            Console.WriteLine("rozmiar macierzy ocen = " + macierzOcen.GetLength(0) + " " + macierzOcen.GetLength(1));
            if (typeOfDistillation)
            {
                listaZstepMacierzyOcen.Add(macierzOcen);
            }

            else { listaWstepMacierzyOcen.Add(macierzOcen); }


            if (CboxRatingMatrixChecked)
            {
                if (typeOfDistillation) { PreparedDataTable(macierzOcen, "Macierz Ocen " + listaZstepMacierzyOcen.Count + " (D.Z.)", workingListOfNumbersOfOptions); }
                else { PreparedDataTable(macierzOcen, "Macierz Ocen " + listaWstepMacierzyOcen.Count + " (D.W.)", workingListOfNumbersOfOptions); }
            }

            // if (CboxRatingMatrixChecked) {
            // Console.WriteLine("Macierz Ocen");
            //Console.Write("        ");

            for (int r = 0; r < workingListOfNumbersOfOptions.Count; r++)
            {
                //Console.Write("A" + workingListOfNumbersOfOptions[r] + " | ");
                listaNazwOpcjiMacOc.Add(workingListOfNumbersOfOptions[r]);
            }

            Console.WriteLine();
            listaNumerowOpcjiMacierzyOcen.Add(listaNazwOpcjiMacOc);

            /*                for (int wierszOceny = 0; wierszOceny < macierzOcen.GetLength(0); wierszOceny++) {
                                switch (wierszOceny) {
                                    case 0:
                                        Console.Write("OPTION");
                                        break;
                                    case 1:
                                        Console.Write("POWER ");
                                        break;
                                    case 2:
                                        Console.Write("WEAKN ");
                                        break;
                                    case 3:
                                        Console.Write("QUALI ");
                                        break;
                                }

                                for (kolumnaOceny = 0; kolumnaOceny < macierzOcen.GetLength(1); kolumnaOceny++) {
                                    Console.Write(macierzOcen[wierszOceny, kolumnaOceny] + " | ");
                                }

                                Console.WriteLine();
                            }*/
            //Console.WriteLine("\n\n");
            // }
            DoStepSixth(macierzOcen, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
        }


        public void DoStepSixth(double[,] ratingMatrix, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {

            Console.WriteLine("Krok 6");
            Console.WriteLine("ratingMatrix = " + ratingMatrix.GetLength(0) + " " + ratingMatrix.GetLength(1));
            if (typeOfDistillation == true)
            {
                double qualificationNajlepszejOpcji = 0;
                qualificationNajlepszejOpcji = ratingMatrix[3, 0];
                Console.WriteLine("Najlepsze quali od ratingMatrix = " + qualificationNajlepszejOpcji);
                // znajdujemy najlepszą punktacje qualification
                for (int kolumnaOceny = 0; kolumnaOceny < ratingMatrix.GetLength(1); kolumnaOceny++)
                {
                    if (ratingMatrix[3, kolumnaOceny] > qualificationNajlepszejOpcji)
                    {
                        qualificationNajlepszejOpcji = ratingMatrix[3, kolumnaOceny];
                    }
                }

                Console.WriteLine("Najlepsze quali = " + qualificationNajlepszejOpcji);
                DoStepSeventh(ratingMatrix, qualificationNajlepszejOpcji, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
            }
            else if (typeOfDistillation == false)
            {
                double qualificationNajgorszejOpcji = 0;
                qualificationNajgorszejOpcji = ratingMatrix[3, 0];
                // znajdujemy najgorszą punktacje qualification
                for (int kolumnaOceny = 0; kolumnaOceny < ratingMatrix.GetLength(1); kolumnaOceny++)
                {
                    if (ratingMatrix[3, kolumnaOceny] < qualificationNajgorszejOpcji)
                    {
                        qualificationNajgorszejOpcji = ratingMatrix[3, kolumnaOceny];
                    }
                }
                Console.WriteLine("Najgorsze quali = " + qualificationNajgorszejOpcji);
                DoStepSeventh(ratingMatrix, qualificationNajgorszejOpcji, workingMatrix, typeOfDistillation, workingListOfNumbersOfOptions);
            }
        }


        int miejsceA = 0;
        int miejsceB = 0;

        public void DoStepSeventh(double[,] ratingMatrix, double qualificationOfTheBestOption, double[,] workingMatrix, bool typeOfDistillation, List<int> workingListOfNumbersOfOptions)
        {
            Console.WriteLine("Krok 7");

            /*            Console.Write("workingListOfNumbersOfOptions = ");
                        //int iter = 0;
                        foreach (int item in workingListOfNumbersOfOptions) { 
                            Console.Write(item);
            *//*                ratingMatrix[0, iter] = workingListOfNumbersOfOptions[iter];
                            iter++;*//*
                        }
                        Console.WriteLine();*/

            int liczbaNajlepszychOpcji = 0;
            listaNumerowZNazwNajlepszychOpcjiWewnatrz = new List<Int32>();
            Console.WriteLine("rozmiar listaNumerowZNazwOpcji PRZED = " + workingListOfNumbersOfOptions.Count);
            listaNumerowZNazwOpcjiUsytWRank.Sort();

            // liczymy ile opcji ma najlepszą (lub najgorszą) ocenę
            for (int kolumnaOceny = 0; kolumnaOceny < ratingMatrix.GetLength(1); kolumnaOceny++)
            {
                if (qualificationOfTheBestOption == ratingMatrix[3, kolumnaOceny])
                {
                    liczbaNajlepszychOpcji++;
                }
            }

            Console.WriteLine("Liczba Najlepszych / Najgorszych Opcji = " + liczbaNajlepszychOpcji);
            // tworzymy nową macierz dla najlepszych opcji - macierz credibility tylko dla najlepszych opcji wewnątrz
            Double[,] matrixNajlepszychOpcjiWewnatrz = new Double[liczbaNajlepszychOpcji, liczbaNajlepszychOpcji];
            Console.WriteLine("rozmiar matrixnajlepszychopcjiwewnatrz = " + matrixNajlepszychOpcjiWewnatrz.GetLength(0));
            int numerNajlepszejOpcjiWew = -1;
            int numerWierszaX = 0;
            int numerKolumnyY = 0;

            // wszystkie opcje, które mają najlepszą (najgorszą) ocenę równą qualificationNajlepszejOpcji / najgorszej opcji dodajemy do nowego matrixa "matrixNajlepszychOpcjiWewnatrz" / "matrix.. najgorszychOpcji"
            for (int numerKolumny = 0; numerKolumny < ratingMatrix.GetLength(1); numerKolumny++)
            {
                double wartoscKomorkiMacierzOcen = ratingMatrix[3, numerKolumny];
                Console.WriteLine("wartoscKomorkiMacirzOcen = " + ratingMatrix[3, numerKolumny]);
                if (qualificationOfTheBestOption == wartoscKomorkiMacierzOcen)
                {
                    Console.WriteLine("kolumna naj kwali = " + numerKolumny);
                    for (int numerWiersza = 0; numerWiersza < workingMatrix.GetLength(0); numerWiersza++)
                    {
                        wartoscKomorkiMacierzOcen = ratingMatrix[3, numerWiersza];
                        if (qualificationOfTheBestOption == wartoscKomorkiMacierzOcen)
                        {
                            Console.WriteLine("wiersz naj kwali = " + numerWiersza);
                            double pomocna1 = workingMatrix[numerWiersza, numerKolumny];
                            matrixNajlepszychOpcjiWewnatrz[numerWierszaX, numerKolumnyY] = pomocna1;
                            numerNajlepszejOpcjiWew = numerWiersza;
                            numerWierszaX++;
                        }
                    }
                    numerWierszaX = 0;
                    numerKolumnyY++;
                    listaNumerowZNazwNajlepszychOpcjiWewnatrz.Add(workingListOfNumbersOfOptions[numerKolumny]);
                }

            }

            // WYPISYWANIE ZAWARTOSCI listaNumerowZNazwNajlepszychOpcjiWewnatrz
            Console.WriteLine("listaNumerowZNazwNajlepszychOpcjiWewnatrz:");

            /*            for (int p = 0; p < listaNumerowZNazwNajlepszychOpcjiWewnatrz.Count; p++)
                        {
                            Console.WriteLine(listaNumerowZNazwNajlepszychOpcjiWewnatrz[p]);
                        }
                        Console.WriteLine("\n\n");*/

            ////////////// SYTUACJA 1

            // sytuacja gdy jest jedna opcja z najlepszym qualification
            if (matrixNajlepszychOpcjiWewnatrz.GetLength(1) == 1)
            {
                if (typeOfDistillation == true)
                {
                    Console.WriteLine("USUWANIE 1");
                    listaNumerowZNazwOpcjiUsytWRank.Add(workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]);

                    listaNumerowZNazwOpcjiUsytWRank.Sort();

                    topDownRanking[1, workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]] = (liczbaZajetychMiejscWRankWDestZstep + 1);

                    /*                    Console.WriteLine("PRZED USUWANIEM");
                                        foreach (int item in listaNumerowZNazwOpcjiOgolZstep) { Console.Write(item + " "); }
                                        Console.WriteLine();
                                        Console.WriteLine("numerNajlepszejOpcjiWew = " + numerNajlepszejOpcjiWew);

                                        Console.WriteLine("workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew] = " + workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]);*/

                    listaNumerowZNazwOpcjiOgolZstep.Remove(workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]);

                    /*                    Console.WriteLine("PO USUNIĘCIU");
                                        foreach (int item in listaNumerowZNazwOpcjiOgolZstep) { Console.Write(item + " "); }
                                        Console.WriteLine();
                                        Console.WriteLine("dla TRUE rozmiar listaNumerowZNazwOpcji PO = " + workingListOfNumbersOfOptions.Count);*/
                    listaNumZNazwPomoc = listaNumerowZNazwOpcjiOgolZstep;
                    liczbaZajetychMiejscWRankWDestZstep++;
                }
                else
                {
                    listaNumerowZNazwOpcjiUsytWRank.Add(workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]);
                    listaNumerowZNazwOpcjiUsytWRank.Sort();
                    upwardRanking[1, workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]] = (liczbaZajetychMiejscWRankWDestWstep + 1);
                    listaNumerowZNazwOpcjiOgolWstep.Remove(workingListOfNumbersOfOptions[numerNajlepszejOpcjiWew]);

                    Console.WriteLine("dla FALSE rozmiar listaNumerowZNazwOpcji PO = " + workingListOfNumbersOfOptions.Count);
                    listaNumZNazwPomoc = listaNumerowZNazwOpcjiOgolWstep;
                    liczbaZajetychMiejscWRankWDestWstep++;
                }

                Console.WriteLine("listaNumZNazwPomoc = " + listaNumZNazwPomoc.Count);
                // SPRAWDZAMY CZY OGÓLNIE ZOSTAŁY NAM JESZCZE JAKIEŚ OPCJE DO PORÓWNANIA
                if (listaNumZNazwPomoc.Count > 1)
                {
                    Double[,] nowyRoboczy = new double[listaNumZNazwPomoc.Count, listaNumZNazwPomoc.Count];
                    Console.WriteLine("Rozmiar nowyRoboczy = " + listaNumZNazwPomoc.Count);
                    int wspolrzednaXWiersz = 0;
                    int wspolrzednaYKolumna = 0;
                    Console.WriteLine("numerNajlepszejOpcjiWew = " + numerNajlepszejOpcjiWew);
                    miejsceA = 0;
                    miejsceB = 0;
                    //   Console.WriteLine("miejsceA: " + miejsceA);
                    //   Console.WriteLine("miejsceB: " + miejsceB);

                    for (int numerWiersza = 0; numerWiersza < roboczyMatrixDOgol.GetLength(0); numerWiersza++)
                    {
                        //if (!CzyJestWLiscie(numerWiersza, listaNumerowZNazwOpcjiUsytWRank)) {
                        if (!listaNumerowZNazwOpcjiUsytWRank.Contains(numerWiersza))
                        {
                            for (int numerKolumny = 0; numerKolumny < roboczyMatrixDOgol.GetLength(1); numerKolumny++)
                            {
                                if (!listaNumerowZNazwOpcjiUsytWRank.Contains(numerKolumny))
                                {
                                    double wartoscKomorki = roboczyMatrixDOgol[numerWiersza, numerKolumny];
                                    nowyRoboczy[wspolrzednaXWiersz, wspolrzednaYKolumna] = wartoscKomorki;
                                    wspolrzednaYKolumna++;
                                }
                            }
                            wspolrzednaXWiersz++;
                        }
                        wspolrzednaYKolumna = 0;
                    }
                    wspolrzednaXWiersz = 0;
                    wspolrzednaYKolumna = 0;
                    DoStepSecond(nowyRoboczy, typeOfDistillation, listaNumZNazwPomoc);
                }
                else if (listaNumZNazwPomoc.Count == 1)
                {
                    if (typeOfDistillation == true)
                    {
                        topDownRanking[1, listaNumZNazwPomoc[0]] = (liczbaZajetychMiejscWRankWDestZstep + 1);
                        liczbaZajetychMiejscWRankWDestZstep++;
                    }
                    else if (typeOfDistillation == false)
                    {
                        upwardRanking[1, listaNumZNazwPomoc[0]] = (liczbaZajetychMiejscWRankWDestWstep + 1);
                        liczbaZajetychMiejscWRankWDestWstep++;
                    }
                    Console.WriteLine("KONIEC DEFINITYWNY");
                }
                else
                {
                    Console.WriteLine("BRAK OPCJI W listaNumerowZNazwOpcji KONIEC");
                }
            }

            ////////////// SYTUACJA 2

            else if (matrixNajlepszychOpcjiWewnatrz.GetLength(1) > 1 && newDelta > 0)
            {
                DoStepFourth(newDelta, matrixNajlepszychOpcjiWewnatrz, typeOfDistillation, listaNumerowZNazwNajlepszychOpcjiWewnatrz);
            }

            ////////////// SYTUACJA 3

            else if (matrixNajlepszychOpcjiWewnatrz.GetLength(1) > 1 && newDelta == 0)
            {
                for (int k = 0; k < listaNumerowZNazwNajlepszychOpcjiWewnatrz.Count; k++)
                {
                    if (typeOfDistillation == true)
                    {
                        listaNumerowZNazwOpcjiUsytWRank.Add(listaNumerowZNazwNajlepszychOpcjiWewnatrz[k]);
                        listaNumerowZNazwOpcjiUsytWRank.Sort();
                        //  NAJPIERW NAJLEPSZYM OPCJOM W MATRIXIE ZAPISUJEMY JAKIE MIEJSCE W RANKINGU ZAJĘŁY
                        topDownRanking[1, listaNumerowZNazwNajlepszychOpcjiWewnatrz[k]] = (liczbaZajetychMiejscWRankWDestZstep + 1);
                        Console.WriteLine("USUWANIE 2");
                        // Z listaNumerowZNazwOpcji USUWAMY NUMERY OPCJI, KTÓRE OTRZYMAŁY SWOJE MIEJSCE W RANKINGU
                        for (int j = 0; j < listaNumerowZNazwOpcjiOgolZstep.Count; j++)
                        {
                            if (listaNumerowZNazwOpcjiOgolZstep[j] == listaNumerowZNazwNajlepszychOpcjiWewnatrz[k])
                            {
                                Console.WriteLine("USUWANIE 3");

                                /*                                Console.WriteLine("PRZED USUNIĘCIEM");
                                                                foreach (int item in listaNumerowZNazwOpcjiOgolZstep) { Console.Write(item + " "); }
                                                                Console.WriteLine();*/
                                listaNumerowZNazwOpcjiOgolZstep.RemoveAt(j);

                                /*                                Console.WriteLine("PO USUNIĘCIU");
                                                                foreach (int item in listaNumerowZNazwOpcjiOgolZstep) { Console.Write(item + " "); }
                                                                Console.WriteLine();*/
                                break;
                            }
                        }
                    }
                    else
                    {
                        listaNumerowZNazwOpcjiUsytWRank.Add(listaNumerowZNazwNajlepszychOpcjiWewnatrz[k]);
                        listaNumerowZNazwOpcjiUsytWRank.Sort();
                        //  NAJPIERW NAJGORSZYM OPCJOM W MATRIXIE ZAPISUJEMY JAKIE MIEJSCE W RANKINGU ZAJĘŁY
                        upwardRanking[1, listaNumerowZNazwNajlepszychOpcjiWewnatrz[k]] = (liczbaZajetychMiejscWRankWDestWstep + 1);

                        // Z listaNumerowZNazwOpcji USUWAMY NUMERY OPCJI, KTÓRE OTRZYMAŁY SWOJE MIEJSCE W RANKINGU   
                        for (int j = 0; j < listaNumerowZNazwOpcjiOgolWstep.Count; j++)
                        {
                            if (listaNumerowZNazwOpcjiOgolWstep[j] == listaNumerowZNazwNajlepszychOpcjiWewnatrz[k])
                            {
                                listaNumerowZNazwOpcjiOgolWstep.RemoveAt(j);
                                break;
                            }
                        }
                    }
                }

                // to musimy dodać żeby w rankingDestylacji... dać znać, że kolejne miejsce w rankingu zostały już zajętę
                if (typeOfDistillation == true)
                {
                    liczbaZajetychMiejscWRankWDestZstep++;
                    listaNumZNazwPomoc = listaNumerowZNazwOpcjiOgolZstep;

                    Console.WriteLine("listaNumerowZNazwOpcjiOgolZstep = " + listaNumerowZNazwOpcjiOgolZstep.Count);
                    Console.WriteLine("listaNumZNazwPomoc = " + listaNumZNazwPomoc.Count);
                }
                else if (typeOfDistillation == false)
                {
                    liczbaZajetychMiejscWRankWDestWstep++;
                    listaNumZNazwPomoc = listaNumerowZNazwOpcjiOgolWstep;

                    Console.WriteLine("listaNumerowZNazwOpcjiOgolWstep = " + listaNumerowZNazwOpcjiOgolWstep.Count);
                    Console.WriteLine("listaNumZNazwPomoc = " + listaNumZNazwPomoc.Count);
                }

                // TERAZ SPRAWDZAMY CZY OPROCZ WYGRANYCH OPCJI ZOSTAŁY NAM JESZCZE JAKIEŚ DO PORÓWNANIA  
                // JEŚLI ZOSTAŁO NAM JESZCZE DO PORÓWNANIA KILKA OPCJI TO MUSIMY ZAAKTUALIZOWAĆ MATRIX ROBOCZY (USUNĄĆ OPCJE ULOKOWANE JUZ W RANKINGU) I WYWOŁAĆ ODPOWIEDNIĄ FUNKCJĘ KROKU
                if (listaNumZNazwPomoc.Count > 1)
                {
                    Double[,] nowyRoboczy = new Double[listaNumZNazwPomoc.Count, listaNumZNazwPomoc.Count];
                    Console.WriteLine("nowyRoboczy o rozmiarze = " + listaNumZNazwPomoc.Count);
                    int wspolrzednaXWiersz = 0;
                    int wspolrzednaYKolumna = 0;
                    int miejsceA = 0;
                    int miejsceB = 0;

                    for (int numerWiersza = 0; numerWiersza < roboczyMatrixDOgol.GetLength(0); numerWiersza++)
                    {
                        //if (!CzyJestWLiscie(numerWiersza, listaNumerowZNazwOpcjiUsytWRank)) {
                        if (!listaNumerowZNazwOpcjiUsytWRank.Contains(numerWiersza))
                        {
                            for (int numerKolumny = 0; numerKolumny < roboczyMatrixDOgol.GetLength(1); numerKolumny++)
                            {
                                //if (!CzyJestWLiscie(numerKolumny, listaNumerowZNazwOpcjiUsytWRank)) {
                                if (!listaNumerowZNazwOpcjiUsytWRank.Contains(numerKolumny))
                                {
                                    double wartoscKomorki = roboczyMatrixDOgol[numerWiersza, numerKolumny];
                                    nowyRoboczy[wspolrzednaXWiersz, wspolrzednaYKolumna] = wartoscKomorki;
                                    wspolrzednaYKolumna++;
                                }
                            }
                            wspolrzednaXWiersz++;
                        }
                        wspolrzednaYKolumna = 0;
                    }
                    wspolrzednaXWiersz = 0;
                    wspolrzednaYKolumna = 0;

                    DoStepSecond(nowyRoboczy, typeOfDistillation, listaNumZNazwPomoc);
                }

                // JEŚLI ZOSTAŁA NAM OSTATNIA OPCJA TO LĄDUJE ONA NA KOŃCU RANKINGU
                else if (listaNumZNazwPomoc.Count == 1)
                {
                    if (typeOfDistillation == true)
                    {
                        listaNumerowZNazwOpcjiUsytWRank.Add(listaNumZNazwPomoc[0]);
                        listaNumerowZNazwOpcjiUsytWRank.Sort();
                        topDownRanking[1, listaNumZNazwPomoc[0]] = (liczbaZajetychMiejscWRankWDestZstep + 1);
                        listaNumZNazwPomoc.Remove(0);
                        liczbaZajetychMiejscWRankWDestZstep++;
                    }
                    else
                    {
                        listaNumerowZNazwOpcjiUsytWRank.Add(listaNumZNazwPomoc[0]);
                        listaNumerowZNazwOpcjiUsytWRank.Sort();
                        upwardRanking[1, listaNumZNazwPomoc[0]] = (liczbaZajetychMiejscWRankWDestWstep + 1);
                        listaNumZNazwPomoc.Remove(0);
                        liczbaZajetychMiejscWRankWDestWstep++;
                    }
                }
                else
                {
                    Console.WriteLine("KONIEC BO listaNumZNazwPomoc (czyli OglZstep / OglWstep) PUSTY - brak jakiejkolwiek opcji");
                }
            }
        }


        private List<DataTable> listOfDataTable = new List<DataTable>();
        public List<DataTable> ListOfDataTable { get { return listOfDataTable; } }


        public void PreparedDataTable<T>(ref T[,] matrixData, string namePage)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = namePage;
            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(690, 350);
            DataTable dataTable = new DataTable();

            /* tu mamy liczbaKryteriow+1 to +1 jest dlatego, że pierwsza kolumna (o indeksie 0) jest kolumną nazw 
            w tej pętli dodajemy nazwy kolumn do listy im dedykowanej */
            for (int licz = 0; licz < (matrixData.GetLength(1) + 1); licz++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = "A" + licz;
                dataTable.Columns.Add(column);
            }

            int x;

            if ("Rank. Zstep.".Equals(namePage) || "Rank. Wstep.".Equals(namePage) || "Rank. Final.".Equals(namePage))
            {
                dataTable.Columns[0].ColumnName = "Wariant";
                x = 1;
            }
            else
            {
                dataTable.Columns[0].ColumnName = "X";
                x = 0;
            }
            for (int y = x; y < matrixData.GetLength(0); y++)
            {
                List<string> row = new List<string>();
                for (int z = 0; z < matrixData.GetLength(1) + 1; z++)
                {
                    if (z == 0)
                    {
                        if ("Rank. Zstep.".Equals(namePage) || "Rank. Wstep.".Equals(namePage) || "Rank. Final.".Equals(namePage))
                        {
                            row.Add("Pozycja");
                        }
                        else
                        {
                            row.Add("A" + (y + 1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("SPRAWDZAMY matrixDATA = " + matrixData[y, z - 1].ToString());
                        string item = matrixData[y, z - 1].ToString();
                        row.Add(item);
                    }
                }
                dataTable.Rows.Add(row.ToArray<string>());
            }

            dataTable.TableName = namePage;
            listOfDataTable.Add(dataTable);
            /*            DataPage dataPage = new DataPage();
                        dataPage.Data = dataTable;
                        dataPage.PageName = namePage;
                        listOfDataPage.Add(dataPage);*/
            //dataTableDictionary.Add(namePage, dataTable);
            //listOfDataTables.Add(dataTable);

            /*            dataGridView.DataSource = dataTable;
                        tabPage.Controls.Add(dataGridView);
                        tabControl_LeaderBoards.TabPages.Add(tabPage);*/
        }


        public void PreparedDataTable(Double[,] matrixData, string namePage, List<Int32> listaNazwOpcji)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = namePage;
            DataGridView dataGridView = new DataGridView();
            dataGridView.Size = new Size(690, 350);
            DataTable dataTable = new DataTable();
            Boolean bool1 = namePage.Contains("Ocen");
            Boolean bool2 = namePage.Contains("Finalna");

            /* tu mamy liczbaKryteriow+1 to +1 jest dlatego, że pierwsza kolumna (o indeksie 0) jest kolumną nazw 
            w tej pętli dodajemy nazwy kolumn do listy im dedykowanej */
            for (int licz = 0; licz < matrixData.GetLength(1) + 1; licz++)
            {
                DataColumn column = new DataColumn();
                if (bool1 && licz > 0 && licz < matrixData.GetLength(1) + 1)
                {
                    column.ColumnName = "A" + (listaNazwOpcji[licz - 1] + 1).ToString();
                    dataTable.Columns.Add(column);
                }
                else
                {
                    column.ColumnName = "A" + licz;
                    dataTable.Columns.Add(column);
                }
            }

            dataTable.Columns[0].ColumnName = "X";

            for (int y = 0; y < matrixData.GetLength(0); y++)
            {
                DataRow dataRow = dataTable.NewRow();
                List<string> row; row = new List<string>();

                for (int z = 0; z < matrixData.GetLength(1) + 1; z++)
                {
                    if (z == 0)
                    {
                        if (bool1)
                        {
                            switch (y)
                            {
                                case 1:
                                    row.Add("Power");
                                    break;
                                case 2:
                                    row.Add("Weakness");
                                    break;
                                case 3:
                                    row.Add("Qualification");
                                    break;
                            }
                        }
                        else
                        {
                            row.Add("A" + (y + 1));
                        }
                    }
                    else
                    {
                        if (bool2)
                        {
                            switch (matrixData[y, z - 1])
                            {
                                case -1.0:
                                    row.Add("\u20B1");
                                    break;
                                case 0.0:
                                    row.Add("I");
                                    break;
                                case 1.0:
                                    row.Add("\u03A1");
                                    break;
                                case 2.0:
                                    row.Add("R");
                                    break;
                            }
                        }
                        else
                        {
                            row.Add(matrixData[y, z - 1].ToString());
                        }
                    }
                }

                if (bool1 && y != 0 || !bool1)
                {
                    dataTable.Rows.Add(row.ToArray<string>());
                    dataTable.TableName = namePage;
                }
            }
            listOfDataTable.Add(dataTable);
        }


        int pomocna = 0;

        public void Exchange(int max, int min)
        {

            Console.WriteLine("ZAMIEN WYKONANE" + min);

            for (int j = 0; j < upwardRanking.GetLength(1); j++)
            {
                if ((Int32)(upwardRanking[1, j]) == min)
                {
                    upwardRanking[1, j] = 0;
                }
                if ((Int32)(upwardRanking[1, j]) == max)
                {
                    upwardRanking[1, j] = min;
                }
            }
            for (int j = 0; j < upwardRanking.GetLength(1); j++)
            {
                if ((Int32)(upwardRanking[1, j]) == 0)
                {
                    upwardRanking[1, j] = max;
                }
            }

            if (min < pomocna)
            {
                min++;
                max--;
                Exchange(max, min);
            }
        }


        int maxim = 0;

        public void FindMax(double[,] rankingOfOptionsAfterDistillation)
        {
            for (int i = 0; i < upwardRanking.GetLength(1); i++)
            {
                if (maxim < (Int32)(upwardRanking[1, i]))
                {
                    maxim = (Int32)(upwardRanking[1, i]);
                }
            }
            pomocna = (maxim / 2) + 1;
        }


        int wiersz = -1;
        Boolean tescik = false;
        Boolean tescikBol = false;
        int liczenie = 0;

        public void FindMin()
        {
            liczenie++;
            Console.WriteLine("PPPPPPPPPPPPP = {0}", liczenie);

            if (listaAltWRank.Any())
            {
                Console.WriteLine("PPPPPPP   A1");
                listaAltWRank.Sort();
            }
            listaDlaRank = new List<int>();
            listaChwilowa = new List<int>();
            wiersz = -1;

            for (int i = 0; i < listaAlternatyw.Count; i++)
            {
                if (!listaAltWRank.Any() && !listaAlternatyw[i].Any())
                {
                    Console.WriteLine("PPPPPPP   1");
                    listaDlaRank.Add((i + 1));
                    wiersz = i;
                    listaChwilowa.Add((i + 1));
                }
                else if (listaAlternatyw[i].Count == listaAltWRank.Count)
                {
                    Console.WriteLine("PPPPPPP   2");
                    listaAltWRank.Sort();
                    for (int k = 0; k < listaAlternatyw[i].Count; k++)
                    {
                        if (listaAlternatyw[i][k] == listaAltWRank[k]) { tescik = true; Console.WriteLine("PPPPPPP   3"); }
                        else
                        {
                            Console.WriteLine("PPPPPPP   4");
                            tescik = false;
                            break;
                        }
                    }
                    if (tescik)
                    {
                        Console.WriteLine("PPPPPPP   5");
                        listaDlaRank.Add((i + 1));
                        listaChwilowa.Add((i + 1));
                        wiersz = i;
                    }
                }
                else if (listaAlternatyw[i].Count < listaAltWRankNieSort.Count && !listaAltWRankNieSort.Contains(i + 1))
                {
                    Console.WriteLine("PPPPPPP   6");
                    for (int f = 0; f < listaChwilowa.Count; f++)
                    {
                        double pomoc1 = FinalRankingMatrix[i, listaChwilowa[f] - 1];
                        double pomoc2 = FinalRankingMatrix[listaChwilowa[f] - 1, i];

                        if ((pomoc1 == 2.0 || pomoc1 == 0.0) && (pomoc2 == 2.0 || pomoc2 == 0.0))
                        {
                            Console.WriteLine("PPPPPPP   7");
                            tescikBol = true;
                        }
                        else
                        {
                            Console.WriteLine("PPPPPPP   8");
                            tescikBol = false;
                            break;
                        }
                    }
                    if (tescikBol)
                    {
                        Console.WriteLine("PPPPPPP   9");
                        listaDlaRank.Add((i + 1));
                        listaChwilowa.Add((i + 1));
                        wiersz = i;
                    }
                }
            }

            if (listaChwilowa.Any())
            {
                Console.WriteLine("PPPPPPP   10");
                for (int w = 0; w < listaChwilowa.Count; w++)
                {
                    listaAltWRank.Add(listaChwilowa[w]);
                    listaAltWRankNieSort.Add(listaChwilowa[w]);
                }
            }

            if (listaAltWRank.Count < listaAlternatyw.Count)
            {
                Console.WriteLine("PPPPPPP   11");
                listaRank.Add(listaDlaRank);
                FindMin();
            }
            else
            {
                Console.WriteLine("PPPPPPP   12");
                listaRank.Add(listaDlaRank);
            }
        }


        public void PrepareTopDownDistillation()
        {
            listaNumerowZNazwOpcjiUsytWRank.Clear();
            newDelta = 0.0;
            typDestylacji = true;
        }


        public void PrepareUpwardDistillation()
        {
            listaNumerowZNazwOpcjiUsytWRank.Clear();
            newDelta = 0.0;
            typDestylacji = false;
        }


        public void PrepareUpwardScore()
        {
            FindMax(upwardRanking);
            Exchange(maxim, 1);
        }


        public void ShowSets(ref List<Double[,]> listaZbiorow, string name)
        {

            // wypisywanie zbiorów zgodności dla każdego z kryterium do Output kompilatora i do TextArea
            for (int a = 0; a < listaZbiorow.Count; a++)
            {
                Double[,] cos = listaZbiorow[a];
                PreparedDataTable(ref cos, "Zbior " + name + (a + 1));
            }
        }


        public void ShowMatrix(ref Double[,] matrix, string name)
        {
            PreparedDataTable(matrix, "Macierz " + name, lul);
        }


        public void ShowTableDataOfDistillation(ref double[,] tabDestillation)
        {
            Console.WriteLine("TAB DEST");
            for (int i = 0; i < tabDestillation.GetLength(0); i++)
            {
                for (int j = 0; j < tabDestillation.GetLength(1); j++)
                {
                    Console.WriteLine(tabDestillation[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public void CreateOutrankingSets(ref List<double[,]> listOfOutrankingSets)
        {

            Console.WriteLine("SPRAWDZAMY listaZbiorowNieZgodnosci.size() =" + listaZbiorowNieZgodnosci.Count);

            for (int numerZbioru = 0; numerZbioru < listaZbiorowNieZgodnosci.Count; numerZbioru++)
            {

                /* tworzymy nowy obiekt matrixa (wymiar zależy od zadeklarowanej liczby alternatyw), do którego będą zapisywane nowe wartości */
                Double[,] matrixKryterium = new Double[numberOfAlternatives, numberOfAlternatives];

                for (int numerWiersza = 0; numerWiersza < listaZbiorowNieZgodnosci[numerZbioru].GetLength(1); numerWiersza++)
                {

                    for (int numerKolumny = 0; numerKolumny < listaZbiorowNieZgodnosci[numerZbioru].GetLength(0); numerKolumny++)
                    {

                        if (listaZbiorowNieZgodnosci[numerZbioru][numerKolumny, numerWiersza] > concordanceMatrix[numerKolumny, numerWiersza])
                        {
                            matrixKryterium[numerKolumny, numerWiersza] = 1;
                        }
                        else
                        {
                            matrixKryterium[numerKolumny, numerWiersza] = 0;
                        }
                    }
                }
                listOfOutrankingSets.Add(matrixKryterium);
            }
        }


        public void ShowDistillation(string name, double[,] miejscaOpcjiPoDestylacji)
        {
            Console.WriteLine("WYPISYWANIE OPCJI I ICH MIEJSC W RANKINGU DESTYLACJI {0}", name);
            for (int i = 0; i < miejscaOpcjiPoDestylacji.GetLength(0); i++)
            {
                for (int j = 0; j < miejscaOpcjiPoDestylacji.GetLength(1); j++)
                {
                    Console.WriteLine(miejscaOpcjiPoDestylacji[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }


        // dodałem by wypisać matrixy i sprawdzic w nich wartosci
        public void WriteConcordaceSetsIntoConsoleOutput(List<double[,]> concordanceSets)
        {
            // wypisujemy matrixa dla i-tego kryterium
            for (int i = 0; i < listaZbiorowZgodnosci.Count; i++) 
            {
                Console.WriteLine($"ZBIOR ZGODNOŚCI KRYT. #{i}");
                // wybór k-tego wiersza
                for (int k = 0; k < numberOfAlternatives; k++)
                {
                    // wybór j-tej kolumny
                    for (int j = 0; j < numberOfAlternatives; j++)
                    {
                        int wordLength = concordanceSets[i][k, j].ToString().Length;
                        Console.Write(concordanceSets[i][k, j].ToString().PadLeft(5-wordLength));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
