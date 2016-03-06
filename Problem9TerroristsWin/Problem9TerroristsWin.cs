// Mine complicated solution of the problem which give 75 points in Judge
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem9TerroristsWin
{
    static void Main()
    {
        //string inputString = String.Empty;
        //inputString = Console.ReadLine();
        char[] inputString = Console.ReadLine().ToCharArray();
        int currentBombFirstIndex = 0;
        int currentBombLastIndex = 0;
        List<int[]> bombsInformationList = new List<int[]>();
        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] == '|')
            {
                currentBombFirstIndex = i;
                int[] currentBombInfo = new Int32[3];
                currentBombInfo[0] = currentBombFirstIndex;
                int bombPower = 0;
                do
                {
                    i++;
                    bombPower += Encoding.ASCII.GetBytes(inputString[i].ToString())[0];
                } while (inputString[i + 1] != '|');
                i++;
                bombPower = bombPower % 10;
                currentBombLastIndex = i;
                currentBombInfo[1] = currentBombLastIndex;
                currentBombInfo[2] = bombPower;
                bombsInformationList.Add(currentBombInfo);
            }
        }

        for (int i = 0; i < bombsInformationList.Count; i++)
        {
            ReplaceCharactersAtGivenPosition(inputString, bombsInformationList[i][0], bombsInformationList[i][1], bombsInformationList[i][2]);
        }

        Console.WriteLine(inputString);
    }

    //static void ReplaceCharactersAtGivenPosition(char[] stringToReplace, int startIndex, int lastIndex, int bombPower)
    static void ReplaceCharactersAtGivenPosition(char[] inputChars, int startIndex, int lastIndex, int bombPower)
    {
        //var newString = new StringBuilder(stringToReplace);
        //int charsToRemoveCount = (lastIndex + 1 + bombPower) - (startIndex - bombPower);
        //newString.Remove(startIndex - bombPower, charsToRemoveCount);
        //newString.Insert(startIndex - bombPower, new String('.', charsToRemoveCount));
        //return newString.ToString();
        //char[] inputChars = stringToReplace.ToCharArray();
        int currentStartIndex = startIndex - bombPower < 0 ? 0 : startIndex - bombPower ;
        int currentLastIndex = lastIndex + bombPower > inputChars.Length ? inputChars.Length - 1 : lastIndex + bombPower;
        for (int i = currentStartIndex; i <= currentLastIndex; i++)
        {
            inputChars[i] = '.';
        }
        //stringToReplace = inputChars.ToString();
    }
}

// Not mine but similar except that the bomb explodes immediately with the method. 
// The start and end indexes are not stored in list of arrays because it is unnecessary complication.
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//    class Problem9TerroristsWin
//    {
//        static void Main(string[] args)
//        {
//            char[] input = Console.ReadLine().ToCharArray();

//            int impact1 = 0;
//            int impact2 = 0;
//            for (int i = 0; i < input.Length; i++)
//            {
//                if (input[i].ToString() == "|")
//                {
//                    impact1 = i;
//                    i++;
//                    StringBuilder sb = new StringBuilder();
//                    while (input[i].ToString() != "|")
//                    {
//                        sb.Append(input[i]);
//                        i++;
//                    }
//                    impact2 = i;
//                    Explosion(input, sb, impact1, impact2);
//                }
//            }
//            Console.WriteLine(String.Join("", input));
//        }

//        private static void Explosion(char[] input, StringBuilder sb, int impact1, int impact2)
//        {
//            string bomb = sb.ToString();
//            int sum = 0;
//            for (int j = 0; j < bomb.Length; j++)
//            {
//                sum += (char)bomb[j];
//            }
//            int radius = sum % 10;
//            for (int h = (impact1 - radius < 0 ? 0 : impact1 - radius);
//                h <= (impact2 + radius > input.Length - 1 ? input.Length - 1 : impact2 + radius); h++)
//            {
//                input[h] = '.';
//            }
//        }
//    }
