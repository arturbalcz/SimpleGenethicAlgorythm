using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm
{
    class Program
    {
        private static double E = 0.001;
        private static int Precision = 14;

        static void Main(string[] args)
        {
            double zeroPoint = 0; 

            List<double> parameters = new List<double>();

            //parameters.Add(1);
            //parameters.Add(-3); 
            parameters.Add(7);
            parameters.Add(2);
            parameters.Add(-1);


            Polinomial polinomial = new Polinomial(parameters);

            Console.WriteLine("{0}", polinomial.ToString());

            Population population = new Population(polinomial);

            population.InitPoulation();
            population.Selection();
            Individual best = population.GetBest(); 

            int i = 0;

            Console.WriteLine("Gen {0}\tx={1}\tP(x)={2}", i, best.ToDouble(Precision), polinomial.Calc(best.ToDouble(Precision)));

            while (Math.Abs(polinomial.Calc(best.ToDouble(Precision))) > Math.Abs(zeroPoint-E))
            {
                i++; 

                population.Crossover();
                population.Mutation();
                population.Selection();
 
                best = population.GetBest();

                Console.WriteLine("Gen {0}\tx={1}\tP(x)={2}", i, best.ToDouble(Precision), polinomial.Calc(best.ToDouble(Precision))); 
            }
            
            //-----------------------DEBUG-------------------------------------------------------------------------------------------

            /*
            Individual individual = new Individual();
            Individual individual2 = new Individual();

            Console.WriteLine("{0:F1}\t{1}", individual.ToDouble(1), individual.ToString());
            Console.WriteLine("{0:F1}\t{1}", individual2.ToDouble(1), individual2.ToString());
            Individual individual3 = Individual.Crossover(individual, individual2, 8);
            Console.WriteLine("{0:F1}\t{1}", individual3.ToDouble(1), individual3.ToString());
            individual3.Mutate(2);
            Console.WriteLine("{0:F1}\t{1}", individual3.ToDouble(1), individual3.ToString());
            */
        }
    }
}
