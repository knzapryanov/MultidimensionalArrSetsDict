using System;
using System.Collections.Generic;
using System.Linq;

class Pr6CountSymbols
{
    public static void Main()
    {
        // Should have used the Set<> functionality for this but I have forgotten for these structres :D
        string inputText = Console.ReadLine();
        char[] inputChars = inputText.ToCharArray();
        char[] distinctSortedChars = inputChars.Distinct().ToArray();
        Array.Sort(distinctSortedChars);
        char[,] charAndCountArr = new Char[distinctSortedChars.Count(), 2];

        for (int i = 0; i < distinctSortedChars.Length; i++)
        {
            charAndCountArr[i, 0] = distinctSortedChars[i];
            int currentCharCount = 0;
            for (int j = 0; j < inputText.Length; j++)
            {
                if (distinctSortedChars[i] == inputText[j])
                {
                    currentCharCount++;
                }
            }
            charAndCountArr[i, 1] = (char)currentCharCount;
        }

        for (int i = 0; i < charAndCountArr.GetLength(0); i++)
        {
            Console.WriteLine("{0} : {1} time/s", charAndCountArr[i, 0], Convert.ToInt32(charAndCountArr[i, 1]));
        }

        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }
}