using System.Text;

namespace beecrowd_1022;

public class Beecrowd1022
{
    static void Main(string[] args)
    {
        int quantity = Convert.ToInt32(Console.ReadLine());

        int firstNumerator;
        int firstDenominator;
        int secondNumerator;
        int secondDenominator;
        char operatation;

        int numerator = 0;
        int denominator = 0;
        int simpNumerator = 0;
        int simpDenominator = 0;

        int positiveNumerator = 0;
        int positiveDenominator = 0;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < quantity; i++)
        {
            string line = Console.ReadLine();

            string[] values = line.Trim().Split(' ');

            firstNumerator = Convert.ToInt32(values[0]);
            firstDenominator = Convert.ToInt32(values[2]);
            operatation = Convert.ToChar(values[3]);
            secondNumerator = Convert.ToInt32(values[4]);
            secondDenominator = Convert.ToInt32(values[6]);

            if (operatation == '+')
            {
                denominator = firstDenominator * secondDenominator;
                numerator = ((denominator / firstDenominator) * firstNumerator) +
                            ((denominator / secondDenominator) * secondNumerator);
            }
            else if (operatation == '-')
            {
                denominator = firstDenominator * secondDenominator;
                numerator = ((denominator / firstDenominator) * firstNumerator) -
                            ((denominator / secondDenominator) * secondNumerator);
            }
            else if (operatation == '*')
            {
                numerator = (firstNumerator * secondNumerator);
                denominator = firstDenominator * secondDenominator;
            }
            else
            {
                numerator = (firstNumerator * secondDenominator);
                denominator = firstDenominator * secondNumerator;
            }

            positiveNumerator = numerator;
            positiveDenominator = denominator;
            
            if (numerator > denominator)
            {
                if (denominator < 0)
                {
                    positiveDenominator *= -1;
                }
                
                for (int j = positiveDenominator; j > 1; j--)
                {
                    if (numerator % j == 0 && denominator % j == 0)
                    {
                        simpNumerator = numerator / j;
                        simpDenominator = denominator / j;
                        break;
                    }
                    else
                    {
                        simpNumerator = numerator;
                        simpDenominator = denominator;
                    }
                }
            }
            else
            {
                if (numerator < 0)
                {
                    positiveNumerator *= -1;
                }
                for (int j = positiveNumerator; j > 1; j--)
                {
                    if (numerator % j == 0 && denominator % j == 0)
                    {
                        simpNumerator = numerator / j;
                        simpDenominator = denominator / j;
                        break;
                    }
                    else
                    {
                        simpNumerator = numerator;
                        simpDenominator = denominator;
                    }
                }
            }

            Console.WriteLine("{0}/{1} = {2}/{3}", numerator, denominator, simpNumerator, simpDenominator);

        }
    }
}
