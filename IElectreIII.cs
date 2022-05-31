using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreAp
{
    interface IElectreIII
    {
        double DoInvers(Double symbolA, Double symbolB, int numberOfSymbol);
        void CalculateThreshold(Double[,,] table, Double value, int i, int mod);
        void CreateOutrankingSets(ref List<Double[,]> listOfOutrankingSets);
        void DoStageFirst();
        void DoStageSecond();
        double CalculateSDeltaK(double deltaLast);
        void DoStepSecond(Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepFourth(Double deltaLast, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepFifth(Double lastDelta, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepSixth(Double[,] ratingMatrix, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepSeventh(Double[,] ratingMatrix, double qualificationOfTheBestOption, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void FindMin(List<List<Int32>> listaRank);
        void CreateFinalRanking(ref Double[,] finalRankingMatrix);
        void CreateTabOfDistillation(ref double[,] tableOfDistillation, ref double[,] placesOfOptionsAfterDistillation, int valueX, int valueY, int valueZ, ElectreIII.TestOperationDelegate testOperation);
        void CreateSumTableOfDistillations(ref Double[,] tabSum);
        void FindHighestRankAndSetPointerValueToMiddleRank(double[,] rankingOfOptionsAfterDistillation);
        void ChangeRankingPlacesToUpwardStyle(int actualHighestRank, int actualLowestRank);
        void ShowTableDataOfDistillation(ref Double[,] tabDistillation);
        void ShowMatrix(ref Double[,] matrix, string name);
    }
}
