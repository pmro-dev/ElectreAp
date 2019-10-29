using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreAp
{
    interface IAlgorithm
    {

        void CreateConcordanceSets();
        void ShowSets(ref List<Double[,]> listaZbiorow, string name);
        void CreateDiscordanceSets();
        void DoCalculations();

    }
}
