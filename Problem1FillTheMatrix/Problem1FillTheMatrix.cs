using System.Collections.Generic;
using System;
using System.Linq;

class Problem1FillTheMatrix
{
    public static void Main()
    {
        int n = 4;
        int[,] matrixA = new Int32[n, n];
        int[,] matrixB = new Int32[n, n];
        FillAndPrintMatrixPatternA(matrixA, n);
        Console.WriteLine();
        FillAndPrintMatrixPatternB(matrixB, n);
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }

    static void FillAndPrintMatrixPatternA(int[,] matrix, int matrixSize)
    {
        int fill = 1;
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                matrix[j, i] = fill;
                fill += 1;
            }
        }

        // Printing
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                Console.Write("{0, -4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void FillAndPrintMatrixPatternB(int[,] matrix, int matrixSize)
    {
        int fill = 1;
        int fillControl = 1;
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                matrix[j, i] = fill;
                if (fillControl % 2 == 1)
                {
                    fill += 1;
                }
                else
                {
                    fill -= 1;
                }
            }
            if (fillControl % 2 == 1)
            {
                fill += matrixSize - 1;
            }
            else
            {
                fill += matrixSize + 1;
            }
            fillControl++;
        }

        // Printing
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                Console.Write("{0, -4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}