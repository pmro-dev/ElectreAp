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
        void CreateOutrankingSets(List<Double[,]> listOfOutrankingSets);
        void ShowOutrankingSets();
        void DoStageFirst();
        void ShowStageFirst();
        void DoStageSecond();
        void ShowStageSecond();
        double CalculateSDeltaK(double deltaLast);
        void DoStepSecond(Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepFourth(Double deltaLast, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepFifth(Double lastDelta, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepSixth(Double[,] ratingMatrix, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void DoStepSeventh(Double[,] ratingMatrix, double qualificationOfTheBestOption, Double[,] workingMatrix, Boolean typeOfDistillation, List<Int32> workingListOfNumbersOfOptions);
        void FindMin();
        void CreateFinalRanking();
        void CheckingIsThereThisSameOptions(int y);
        void CreateTabOfDistillation(double[,] tableOfDistillation, String[,] placesOfOptionsAfterDistillation, int valueX, int valueY, int valueZ);
        void ShowTableDataOfDistillation(Double[,] tabDistillation);
        void CreateSumTableOfDistillations();
        void FindMax(String[,] rankingOfOptionsAfterDistillation);
        void Exchange(int max, int min);
    }
}
