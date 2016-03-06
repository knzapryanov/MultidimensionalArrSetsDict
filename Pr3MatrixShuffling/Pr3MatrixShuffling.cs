using System;
using System.Collections.Generic;
using System.Linq;

class Pr3MatrixShuffling
{
    public static void Main()
    {
        string fillStr = Console.ReadLine();
        int[] rowsColsCount = fillStr.Split(' ').Select(Int32.Parse).ToArray();
        string[,] matrix = new String[rowsColsCount[0], rowsColsCount[1]];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            fillStr = Console.ReadLine();
            string[] tempArr = fillStr.Split(' ').ToArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = tempArr[j];
            }
        }

        string command = String.Empty;
        for (; ; )
        {
            command = Console.ReadLine();
            string[] commandWords = command.Split(' ').ToArray();

            if (commandWords[0] == "END")
            {
                break;
            }
            else if (commandWords.Length != 5 || commandWords[0] != "swap")
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                bool isCommandValid = true;
                // Check are row indexes valid
                for (int i = 1; i <= 3; i += 2)
                {
                    if (Int32.Parse(commandWords[i]) > rowsColsCount[0] - 1)
                    {
                        isCommandValid = false;
                    }
                }
                // Check are col indexes valid
                for (int i = 2; i <= 4; i += 2)
                {
                    if (Int32.Parse(commandWords[i]) > rowsColsCount[1] - 1)
                    {
                        isCommandValid = false;
                    }
                }

                if (isCommandValid)
                {
                    int x1 = Int32.Parse(commandWords[1]);
                    int y1 = Int32.Parse(commandWords[2]);
                    int x2 = Int32.Parse(commandWords[3]);
                    int y2 = Int32.Parse(commandWords[4]);

                    string temp = String.Empty;
                    temp = matrix[x1, y1];
                    matrix[x1, y1] = matrix[x2, y2];
                    matrix[x2, y2] = temp;
                    Console.WriteLine("(after swapping {0} and {1}):", matrix[x1, y1], matrix[x2, y2]);
                    PrintStringMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }

    static void PrintStringMatrix(string[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, -6}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}