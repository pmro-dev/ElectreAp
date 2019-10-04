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
    class Tables
    {
        Double zmiennaHelp;
        String valueHelp = "";
       // TabPage tabPage;

        public void CreateMatrixBasedOnTable(){ }
        public void DivideThresholdsToLists(){ }
        public void CreateMatrixForAlternativeData(){ }
        public void CreateConcordanceMatrix(List<Double[][]> listOfConcordanceSets, int numberOfAlternatives){ }
        public void ShowConcordanceMatrix(){ }

        public List<String> columnNames = new List<String>();
        //List<List<String>> data = new List<List<String>>();

        public DataTable CreateTable(int numberOfAlternatives, int numberOfCriterions, Double[,] tabelaMatrix, Double[,] tabelaAlternatyw) {

            DataTable dataTab = new DataTable();

            for (int i = 0; i < numberOfCriterions +1; i++)
            {
                if (i == 0) { columnNames.Add("X"); }
                else { columnNames.Add("F" + i); }
                DataColumn column = new DataColumn();
                column.ColumnName = columnNames[i];
                dataTab.Columns.Add(column);
            }

            int zmienna = 1;

            for (int y = 0; y < numberOfAlternatives+3; y++)
            {
                List<string> row = new List<string>();

                for (int z = 0; z < numberOfCriterions+1; z++)
                {
                    if (z == 0)
                    {
                        row.Add("A" + zmienna);

                        if (y >= 3)
                        {
                            zmienna++;
                        }
                    }
                    else
                    {
                        row.Add("0.00");
                    }
                }

                //Console.WriteLine("row count = "+row.Count+"  and columnNames count = "+columnNames.Count);

                dataTab.Rows.Add(row.ToArray<string>());
            }

            tabelaMatrix = new double[numberOfAlternatives+9, numberOfCriterions];

            for (int y = 0; y < numberOfAlternatives + 9; y++)
            {
                for (int z = 0; z < numberOfCriterions; z++)
                {
                    tabelaMatrix[y,z] = 0.00;
                }
            }

            tabelaAlternatyw = new double[numberOfAlternatives, numberOfCriterions];

            for (int y = 0; y < numberOfAlternatives; y++)
            {
                for (int z = 0; z < numberOfCriterions; z++)
                {
                    tabelaAlternatyw[y, z] = 0;
                }
            }

            return dataTab;
        }
        public void ExchangingListOfRanksToTable(List<List<Int32>> listOfRanks) { }
        public void ShowOptionRankingOfDistillation(String[][] rankingOfOptionsAfterDistillation) { }
    }
}
