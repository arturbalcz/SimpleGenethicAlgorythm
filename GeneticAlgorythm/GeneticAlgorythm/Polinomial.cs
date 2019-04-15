using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm
{
    class Polinomial
    {
        private List<double> Parameters = new List<double>();
        private int Number_of_para;


        public Polinomial(List<double> parameters)
        {
            Parameters = parameters;
            Number_of_para = Parameters.Count();
        }


        public double Calc(double x)
        {
            double result = 0;
            int power = Number_of_para - 1;

            foreach (var para in Parameters)
            {
                result += para * Math.Pow(x, power);
                power--;
            }

            return result;
        }

        override
        public string ToString()
        {
            string result = "";
            int power = Number_of_para - 1;

            bool first = true;

            foreach (var para in Parameters)
            {
                if (para != 0)
                {
                    if ((para > 0) && (first == false)) result += "+";

                    first = false;
                    result += para.ToString();

                    if (power != 0)
                    {
                        if (power != 1)
                        {
                            result += "(x^";
                            result += power.ToString();
                            result += ")";
                        }

                        else result += "x";
                    }
                }

                power--;

            }

            return result;
        }
    }
}
