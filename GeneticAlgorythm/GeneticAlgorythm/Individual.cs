using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm
{
    class Individual
    {
        private static Random Rand = new Random();

        private static int ChromosomeSize = 32;
        public static int GetChromosomeSize() { return ChromosomeSize; }

        private int[] Chromosomes = new int[ChromosomeSize];

        public Individual()
        {
            for (int j = 0; j < ChromosomeSize; j++)
            {
                Chromosomes[j] = Rand.Next() % 2;
            }
        }

        public Individual(int[] chromosomes)
        {
            for (int i = 0; i < ChromosomeSize; i++)
            {
                Chromosomes[i] = chromosomes[i];
            }
        }

        public void Mutate(int mutationCount)
        {
            for (int i = 0; i < mutationCount; i++)
            {
                int y = Rand.Next() % ChromosomeSize;

                if (Chromosomes[y] == 1) Chromosomes[y] = 0;
                else if (Chromosomes[y] == 0) Chromosomes[y] = 1;
            }
        }

        public static Individual Crossover(Individual First, Individual Second, int crossoverPoint)
        {
            int[] chromosomes = new int[ChromosomeSize];

            for (int i = 0; i < ChromosomeSize; i++)
            {
                if (i < crossoverPoint)
                {
                    chromosomes[i] = First.Chromosomes[i];
                }
                else chromosomes[i] = Second.Chromosomes[i];
            }

            Individual result = new Individual(chromosomes);

            return result;
        }

        public double ToDouble(int FloatSize)
        {
            double result = 0;

            int power = ChromosomeSize - FloatSize - 1;

            for (int i = ChromosomeSize - 1; i > 0; i--)
            {
                result += Math.Pow(2, power) * Chromosomes[i];
                power--;
            }

            if (Chromosomes[0] == 1) result *= -1;

            return result;
        }

        override
        public string ToString()
        {
            string result = "";
            for (int j = ChromosomeSize - 1; j >= 0; j--)
            {
                result += Chromosomes[j].ToString();
            }

            return result;
        }
    }
}
