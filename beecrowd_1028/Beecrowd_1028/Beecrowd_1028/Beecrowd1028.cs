using System;

public class Beecrowd1028
{
    static void Main(string[] args)
    {

        int cases = Convert.ToInt32(Console.ReadLine());
        

        for (int i = 0; i < cases; i++)
        {
            string[] values = Console.ReadLine().Split(' ');
            int firstPlayer = Convert.ToInt32(values[0]);
            int secondPlayer = Convert.ToInt32(values[1]);
            Console.WriteLine(FindMDC(firstPlayer, secondPlayer));
        }
        

    }

    private static int FindMDC(int firstPlayer, int secondPlayer)
    {
        int resto;

        do {
            resto = firstPlayer % secondPlayer;

            firstPlayer = secondPlayer;
            secondPlayer = resto;

        } while (resto != 0);

        return firstPlayer;
    }
    /*private static int FindMDC(int firstPlayer, int secondPlayer)
    {
        int aux;

        if (firstPlayer > secondPlayer)
        {
            aux = firstPlayer;
            firstPlayer = secondPlayer;
            secondPlayer = aux;
        }

        int i;
        for (i = firstPlayer; i > 1 && !(firstPlayer % i == 0 && secondPlayer % i == 0) ; i--)
        {
            
        }

        return i;
    }*/
}