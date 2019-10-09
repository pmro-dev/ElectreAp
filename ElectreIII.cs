using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*using static ElectreAp.Tables;*/

namespace ElectreAp
{
    class ElectreIII : DataForAlgorithm, IAlgorithm, IElectreIII
    {

        public ElectreIII()
        {

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
