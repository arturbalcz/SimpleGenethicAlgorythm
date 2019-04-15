using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm
{
    class Population
    {
        private Polinomial Polinomial;
        private int ChromosomeSize = Individual.GetChromosomeSize();

        private const int PopulationSize = 2000;
        private const int Precision = 14;
        private const int MutationCount = 2;
        private const int BestCount = 30;
        private const int NewOffspringCount = BestCount * BestCount;

        private List<Individual> PopulationList = new List<Individual>();



        private Individual[] BestIndividuals = new Individual[BestCount];

        Random Rand = new Random();

        public Population(Polinomial polinomial)
        {
            Polinomial = polinomial;
        }

        public void InitPoulation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                Individual P = new Individual();
                PopulationList.Add(P);
            }
        }

        private double CalcFitness(Individual x)
        {
            return Math.Abs(Polinomial.Calc(x.ToDouble(Precision)));

        }

        private int CompareIndividuals(Individual First, Individual Second)
        {
            double FirstFitness = CalcFitness(First);
            double SecondFitness = CalcFitness(Second);

            if (FirstFitness == SecondFitness) return 0;
            else if (FirstFitness > SecondFitness) return 1;
            else return -1;
        }

        public void Selection()
        {
            PopulationList.Sort(CompareIndividuals);

            for (int i = 0; i < BestCount; i++)
            {
                BestIndividuals[i] = PopulationList[i];
            }
        }

        public void Crossover()
        {
            int crossPoint = 0;

            int i = PopulationSize - 1;

            for (int j = 0; j < BestCount; j++)
            {
                crossPoint = Rand.Next() % ChromosomeSize;
                for (int k = 0; k < BestCount; k++)
                {
                    Individual Offspring = Individual.Crossover(BestIndividuals[j], BestIndividuals[k], crossPoint);
                    PopulationList[i] = Offspring;
                    i--;
                    if (i == NewOffspringCount) break;
                }
                if (i == NewOffspringCount) break;
            }
        }

        public void Mutation()
        {
            for (int i = 0; i < PopulationSize; i++)
            {
                PopulationList[i].Mutate(MutationCount);
            }
        }

        public Individual GetBest()
        {
            return PopulationList[0];
        }
    }
}
