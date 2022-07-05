using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day08
    {

        private static string[,] digitArray = new string[200, 14];
        private static List<int> outputSums = new List<int>();

        public static void Part1()
        {
            string path = @"C:\Users\Richard\Downloads\input8.txt";
            var linesList = File.ReadAllLines(path).ToList();
            var numberOfLines = File.ReadLines(path).Count();

            int counter = 0;


            for (int i = 0; i < numberOfLines; i++)
            {

                string[] first = linesList[i].Split(new char[] { ' ', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 10; j < 14; j++)
                {
                    int codeLength = first[j].Length;

                    if (codeLength == 2 || codeLength == 3 || codeLength == 4 || codeLength == 7)
                    {
                        counter++;
                    }

                    digitArray[i, j] = first[j];
                }

            }

            Console.WriteLine("Day 08, part 1: The sum of 1, 3, 4 and 7's is: " + counter);

        }

        public static void Part2()
        {
            string path = @"C:\Users\Richard\Downloads\input8.txt";
            var linesList = File.ReadAllLines(path).ToList();
            var numberOfLines = File.ReadLines(path).Count();


            for (int i = 0; i < numberOfLines; i++)
            {

                string[] first = linesList[i].Split(new char[] { ' ', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string[] tempChars = new string[10];
                string[] tempOutput = new string[4];


                for (int k = 0; k < 10; k++)
                {
                    tempChars[k] = first[k];
                }


                for (int j = 10; j < 14; j++)
                {
                    tempOutput[j - 10] = first[j];
                }

                Check(tempChars, tempOutput);

            }

            var results = outputSums.Sum();

            Console.WriteLine("Day 08, part 2: The sum of outputs is: " + results);

        }


        public static void Check(string[] codes, string[] outputs)
        {

            //Known values

            var one = Array.FindAll(codes, element => element.Length == 2);
            var four = Array.FindAll(codes, element => element.Length == 4);
            var seven = Array.FindAll(codes, element => element.Length == 3);
            var eight = Array.FindAll(codes, element => element.Length == 7);


            //Unknown values


            char[] fours = four[0].ToCharArray();
            char[] ones = one[0].ToCharArray();

            var nine = Array.FindAll(codes, element => element.Length == 6 && element.Contains(fours[0]) && element.Contains(fours[1]) && element.Contains(fours[2]) && element.Contains(fours[3]));
            var three = Array.FindAll(codes, element => element.Length == 5 && element.Contains(ones[0]) && element.Contains(ones[1]));


            var zero = Array.FindAll(codes, element => element.Length == 6 && element.Contains(ones[0]) && element.Contains(ones[1]) && !fours.All(element.Contains));
            var six = Array.FindAll(codes, element => element.Length == 6 && !fours.All(element.Contains) && !ones.All(element.Contains));

            char[] sixes = six[0].ToCharArray();

            var five = Array.FindAll(codes, element => element.Length == 5 && !ones.All(element.Contains) && element.All(sixes.Contains));
            var two = Array.FindAll(codes, element => element.Length == 5 && !ones.All(element.Contains) && !element.All(sixes.Contains));


            char[] zeroes = zero[0].ToCharArray();
            char[] fives = five[0].ToCharArray();
            char[] twos = two[0].ToCharArray();
            char[] sevens = seven[0].ToCharArray();
            char[] eights = eight[0].ToCharArray();
            char[] nines = nine[0].ToCharArray();


            var answer = string.Empty;

            foreach (var code in outputs)
            {
                if (code.Length == 2)
                {
                    answer += "1";
                    continue;
                }
                if (code.Length == 3)
                {
                    answer += "7";
                    continue;
                }
                if (code.Length == 4)
                {
                    answer += "4";
                    continue;
                }
                if (code.Length == 7)
                {
                    answer += "8";
                    continue;
                }
                if (code.Length == 6 && fours.All(code.Contains))
                {
                    answer += "9";
                    //continue;
                }
                if (code.Length == 5 && ones.All(code.Contains))
                {
                    answer += "3";
                    continue;
                }
                if (code.Length == 6 && code.Contains(ones[0]) && code.Contains(ones[1]) && !fours.All(code.Contains))
                {
                    answer += "0";
                    continue;
                }
                if (code.Length == 6 && !ones.All(code.Contains) && !fours.All(code.Contains))
                {
                    answer += "6";
                    continue;
                }
                if (code.Length == 5 && !ones.All(code.Contains) && code.All(sixes.Contains))
                {
                    answer += "5";
                    continue;
                }
                if (code.Length == 5 && !ones.All(code.Contains) && !code.All(sixes.Contains))
                {
                    answer += "2";
                    continue;
                }
            }


            var returnSum = Convert.ToInt32(answer);

            outputSums.Add(returnSum);


        }
    }
}
