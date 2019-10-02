using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreAp
{
    interface IAlgorithm
    {
        void CreateMatrixBasedOnTable();
        void DivideThresholdsToLists();
        void CreateMatrixForAlternativeData();
        void CreateConcordanceSets();
        void ShowConcordanceSets();
        void CreateConcordanceMatrix(List<Double[][]> listOfConcordanceSets, int numberOfAlternatives);
        void ShowConcordanceMatrix();
        void AddMathFormsImgToList(String path);
        void CreateTable(int numberOfAlternatives, int numberOfCriterions);
        void CreateDiscordanceSets();
        void ShowDiscordanceSets();
        void ReadDataFromFileToTable(string path);
        void SaveDataToExelFile(string path);
        void SaveTableToExelFile(string path);
        void DoCalculations();
        void ValidDataInTextBox();
        void ChoisePath();

    }
}
