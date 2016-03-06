using System;
using System.Collections.Generic;
using System.Linq;

class Pr4SequenceInMatrix
{
    public static void Main()
    {
        //			string fillStr = Console.ReadLine();
        //			int[] rowsColsCount = fillStr.Split(' ').Select(Int32.Parse).ToArray();
        //			string[,] matrix = new String[rowsColsCount[0],rowsColsCount[1]];
        //			for (int i = 0; i < matrix.GetLength(0); i++)
        //			{
        //				fillStr = Console.ReadLine();
        //				string[] tempArr = fillStr.Split(' ').ToArray();
        //				for (int j = 0; j < matrix.GetLength(1); j++) 
        //				{
        //					matrix[i,j] = tempArr[j];
        //				}
        //			}
        string[,] matrix =
			{
				{"s","qq","s"},
				{"pp","pp","s"},
				{"pp","qq","s"}
			};

        int finalRowIndex = 0;
        int finalColIndex = 0;
        int finalLongestSeq = 0;
        int[] currentIndexLongestSeqInEachDirection = new Int32[4];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentIndexLongestSeqInEachDirection[0] = GetLongestSeqRightDirection(matrix, row, col);
                currentIndexLongestSeqInEachDirection[1] = GetLongestSeqDownRightDirection(matrix, row, col);
                currentIndexLongestSeqInEachDirection[2] = GetLongestSeqDownDirection(matrix, row, col);
                currentIndexLongestSeqInEachDirection[3] = GetLongestSeqDownLeftDirection(matrix, row, col);
                if (currentIndexLongestSeqInEachDirection.Max() > finalLongestSeq)
                {
                    finalLongestSeq = currentIndexLongestSeqInEachDirection.Max();
                    finalRowIndex = row;
                    finalColIndex = col;
                }
            }
        }

        // Ugly and slow way to print the result with commas in between
        string[] temp = new String[finalLongestSeq];
        for (int i = 0; i < finalLongestSeq; i++)
        {
            //Console.Write("{0} ", matrix[finalRowIndex,finalColIndex]);
            temp[i] = matrix[finalRowIndex, finalColIndex];
        }
        Console.Write("{0} ", String.Join(",", temp));

        Console.WriteLine();
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey(true);
    }

    public static int GetLongestSeqRightDirection(string[,] matrix, int rowIndex, int colIndex)
    {
        int rightDirectionSeqCount = 1;
        while (colIndex < matrix.GetLength(1) - 1 && matrix[rowIndex, colIndex] == matrix[rowIndex, colIndex + 1])
        {
            rightDirectionSeqCount++;
            colIndex++;
        }
        return rightDirectionSeqCount;
    }

    public static int GetLongestSeqDownRightDirection(string[,] matrix, int rowIndex, int colIndex)
    {
        int downRightDirectionSeqCount = 1;
        while (colIndex < matrix.GetLength(1) - 1
               && rowIndex < matrix.GetLength(0) - 1
               && matrix[rowIndex, colIndex] == matrix[rowIndex + 1, colIndex + 1])
        {
            downRightDirectionSeqCount++;
            rowIndex++;
            colIndex++;
        }
        return downRightDirectionSeqCount;
    }

    public static int GetLongestSeqDownDirection(string[,] matrix, int rowIndex, int colIndex)
    {
        int downDirectionSeqCount = 1;
        while (rowIndex < matrix.GetLength(0) - 1 && matrix[rowIndex, colIndex] == matrix[rowIndex + 1, colIndex])
        {
            downDirectionSeqCount++;
            rowIndex++;
        }
        return downDirectionSeqCount;
    }

    public static int GetLongestSeqDownLeftDirection(string[,] matrix, int rowIndex, int colIndex)
    {
        int downLeftDirectionSeqCount = 1;
        while (colIndex > 0
               && rowIndex < matrix.GetLength(0) - 1
               && matrix[rowIndex, colIndex] == matrix[rowIndex + 1, colIndex - 1])
        {
            downLeftDirectionSeqCount++;
            rowIndex++;
            colIndex--;
        }
        return downLeftDirectionSeqCount;
    }
}