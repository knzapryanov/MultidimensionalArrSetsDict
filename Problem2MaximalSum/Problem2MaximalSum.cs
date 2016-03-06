using System.Collections.Generic;
using System;
using System.Linq;

namespace Problem2MaximalSum
{
    class Problem2MaximalSum
    {
        public static void Main()
        {
            string fillStr = Console.ReadLine();
            int[] rowsColsCount = fillStr.Split(' ').Select(Int32.Parse).ToArray();
            int[,] matrix = new Int32[rowsColsCount[0], rowsColsCount[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                fillStr = Console.ReadLine();
                int[] tempArr = fillStr.Split(' ').Select(Int32.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = tempArr[j];
                }
            }

            int sum = 0;
            int tempSum = 0;
            int bigestSumRowIndex = 0;
            int bigestSumColIndex = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    tempSum = GetSumOfNineCellsSquareMatrix(matrix, i, j);
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        bigestSumRowIndex = i;
                        bigestSumColIndex = j;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Sum = {0}", sum);
            PrintNineCellsSquareMatrix(matrix, bigestSumRowIndex, bigestSumColIndex);

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static int GetSumOfNineCellsSquareMatrix(int[,] matrix, int rowIndex, int colIndex)
        {
            int sum = 0;
            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colIndex; j < colIndex + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum;
        }

        static void PrintNineCellsSquareMatrix(int[,] matrix, int rowIndex, int colIndex)
        {
            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colIndex; j < colIndex + 3; j++)
                {
                    Console.Write("{0,-4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}