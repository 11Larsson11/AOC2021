using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day05
    {

        private static int[,] grid = new int[1000, 1000];
        private static int[,] numArray = new int[500, 4];


        public static void Part1()
        {
            DataGenerator();

            int answer = 0;

            for (int i = 0; i < 500; i++)
            {

                if (numArray[i, 0] == numArray[i, 2])
                {
                    GridMarkerX(numArray[i, 1], numArray[i, 3], numArray[i, 0]);
                }


                if (numArray[i, 1] == numArray[i, 3])
                {
                    GridMarkerY(numArray[i, 0], numArray[i, 2], numArray[i, 1]);
                }

                else
                {
                    continue;
                }
            }

            for (var i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j] > 1)
                    {
                        answer += 1;
                    }
                }
            }

            Console.WriteLine("Day 05, part 1: The answer is " + answer);

        }


        public static void Part2()
        {

            DataGenerator();

            int answer2 = 0;


            for (int i = 0; i < 500; i++)
            {

                if (numArray[i, 0] == numArray[i, 2])
                {
                    GridMarkerX(numArray[i, 1], numArray[i, 3], numArray[i, 0]);
                    continue;
                }


                if (numArray[i, 1] == numArray[i, 3])
                {
                    GridMarkerY(numArray[i, 0], numArray[i, 2], numArray[i, 1]);
                    continue;
                }

                else
                {
                    GridMarkerDiag(numArray[i, 0], numArray[i, 1], numArray[i, 2], numArray[i, 3]);
                }
            }

            for (var i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (grid[i, j] > 1)
                    {
                        answer2 += 1;
                    }
                }
            }

            Console.WriteLine("Day 05, part 2: The answer is " + answer2);

        }


        public static void DataGenerator()
        {
            string path = @"C:\Users\Richard\Downloads\input5.txt";
            var linesList = File.ReadAllLines(path).ToList();


            for (int i = 0; i < 500; i++)

            {
                string[] first = linesList[i].Split(new char[] { '-', ',', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 4; j++)
                {
                    int number = Convert.ToInt32(first[j]);
                    numArray[i, j] = number;
                }
            }
        }

        public static void GridMarkerX(int a, int b, int c)
        {

            if (a < b)
            {
                for (int i = a; i <= b; i++)
                {
                    grid[c, i] += 1;
                }
            }

            if (a > b)
            {
                for (int i = b; i <= a; i++)
                {
                    grid[c, i] += 1;
                }
            }
        }

        public static void GridMarkerY(int a, int b, int c)
        {

            if (a < b)
            {
                for (int i = a; i <= b; i++)
                {
                    grid[i, c] += 1;
                }
            }

            if (a > b)
            {
                for (int i = b; i <= a; i++)
                {
                    grid[i, c] += 1;
                }
            }
        }

        public static void GridMarkerDiag(int a, int b, int c, int d)
        {
            if (a < c && b > d)
            {
                for (int i = a; i <= c; i++)
                {
                    grid[i, b] += 1;
                    b--; 
                }  
            }

            else if (a < c && b < d)
            {
                for (int i = a; i <= c; i++)
                {
                    grid[i, b] += 1;
                    b++;
                }
            }

            else if (a > c && b > d)
            {
                for (int i = a; i >= c; i--)
                {
                    grid[i, b] += 1;
                    b--;
                }
            }

            else if (a > c && b < d)
            {
                for (int i = a; i >= c; i--)
                {
                    grid[i, b] += 1;
                    b++;
                }
            }
        }
    }
}
