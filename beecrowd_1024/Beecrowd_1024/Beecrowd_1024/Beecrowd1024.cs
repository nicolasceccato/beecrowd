namespace Beecrowd_1024;

using System;
using System.Collections.Generic;
using System.Linq;

public class Beecrowd1024
{
    static void Main(string[] args)
    {

        int numberOfInputs = Convert.ToInt32(Console.ReadLine());
        List<string> originalListOfInputs = new List<string>();
        for (int i = 0; i < numberOfInputs; i++)
        {
            originalListOfInputs.Add(Console.ReadLine());
        }
        
        List<string> newListOfInputs = new List<string>();
        foreach (var input in originalListOfInputs)
        {
            newListOfInputs.Add(ProcessString(input));
        }

        foreach (var input in newListOfInputs)
        {
            Console.WriteLine(input);
        }

    }

    private static string ProcessString(string input)
    {
        string processedString = new string(input.Select(ShiftCharacter).ToArray());

        char[] charArray = processedString.ToCharArray();
        Array.Reverse(charArray);

        processedString = new string(charArray);

        int halfLength = processedString.Length / 2;

        for (int i = halfLength; i < processedString.Length; i++)
        {
            charArray[i] = (char)(charArray[i] - 1);
        }

        return new string(charArray);
    }

    static char ShiftCharacter(char c)
    {
        if (char.IsLetter(c))
        {
            char baseChar = char.IsLower(c) ? 'a' : 'A';
            return (char)((c - baseChar + 3) % 26 + baseChar);
        }
        else
        {
            return c;
        }
    }
}