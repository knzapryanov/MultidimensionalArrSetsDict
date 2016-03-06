using System;
using System.Collections.Generic;
using System.Linq;

class Pr5CollectTheCoins
{
    public static void Main()
    {
        //			string[] board = new String[4];
        //			for (int i = 0; i < 4; i++) 
        //			{
        //				board[i] = Console.ReadLine();
        //			}
        //			string movementCommands = Console.ReadLine();
        string[] board = 
			{
				"Sj0u$hbc",
				"$87yihc87",
				"Ewg3444",
				"$4$$"
			};
        //string movementCommands = "V>>^^>>>VVV<<";
        int rowIndex = 0;
        int colIndex = 0;
        int coins = 0;
        int wallHits = 0;

        Console.WriteLine("This is the game board:");
        Console.WriteLine();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                Console.Write("{0, -2}", board[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.Write("Enter moves \"V > ^ <\": ");
        string movementCommands = Console.ReadLine();

        for (int i = 0; i < movementCommands.Length; i++)
        {
            //char move = Console.ReadKey().KeyChar;
            switch (movementCommands[i])
            {
                case '>':
                    if (board[rowIndex][colIndex] == '$')
                    {
                        coins++;
                    }
                    if (colIndex + 1 == board[rowIndex].Length)
                    {
                        wallHits++;
                    }
                    else
                    {
                        colIndex++;
                    }
                    break;
                case 'V':
                    if (board[rowIndex][colIndex] == '$')
                    {
                        coins++;
                    }
                    if (rowIndex + 1 > 3 || colIndex >= board[rowIndex + 1].Length)
                    {
                        wallHits++;
                    }
                    else
                    {
                        rowIndex++;
                    }
                    break;
                case '<':
                    if (board[rowIndex][colIndex] == '$')
                    {
                        coins++;
                    }
                    if (colIndex - 1 < 0)
                    {
                        wallHits++;
                    }
                    else
                    {
                        colIndex--;
                    }
                    break;
                case '^':
                    if (board[rowIndex][colIndex] == '$')
                    {
                        coins++;
                    }
                    if (rowIndex - 1 < 0 || colIndex >= board[rowIndex - 1].Length)
                    {
                        wallHits++;
                    }
                    else
                    {
                        rowIndex--;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command symbol!");
                    break;
            }
        }

        Console.WriteLine("Coins collected: {0}", coins);
        Console.WriteLine("Walls hit: {0}", wallHits);

        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }
}