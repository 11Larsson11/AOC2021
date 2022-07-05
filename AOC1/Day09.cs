using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day09
    {

        public static double[,] depthVals = new double[100, 100];
        public static double part1 = 0;
        public static List<int> basins = new List<int>();

        public static void Part1()
        {

            Generate();


            for (int k = 0; k < 100; k++)
            {
                for (int l = 0; l < 100; l++)
                {

                    var measurement = depthVals[k, l];

                    int boolNr = 0;


                    if (k > 0)
                    {
                        var above = depthVals[k - 1, l];

                        if (above <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (k < 99)
                    {
                        var below = depthVals[k + 1, l];

                        if (below <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (l > 0)
                    {
                        var left = depthVals[k, l - 1];

                        if (left <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (l < 99)
                    {
                        var right = depthVals[k, l + 1];

                        if (right <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (boolNr == 0)
                    {
                        var answer = measurement + 1;

                        part1 += answer;

                    }
                }
            }

            Console.WriteLine("Day 9, part 1: The sum is " + part1);

        }

        public static void Part2()
        {

            Generate();


            for (int k = 0; k < 100; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    BasinCalc(depthVals[k, l]);
                }
            }



            







        }

        public static void BasinCalc(double val)
        {

            List<int> xValueList = new List<int>();
            List<int> yValueList = new List<int>();




            for (int k = 0; k < 100; k++)
            {
                for (int l = 0; l < 100; l++)
                {

                    var measurement = depthVals[k, l];

                    int boolNr = 0;


                    if (k > 0)
                    {
                        var above = depthVals[k - 1, l];

                        if (above <= val)
                        {
                            boolNr++;
                        }
                    }

                    if (k < 99)
                    {
                        var below = depthVals[k + 1, l];

                        if (below <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (l > 0)
                    {
                        var left = depthVals[k, l - 1];

                        if (left <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (l < 99)
                    {
                        var right = depthVals[k, l + 1];

                        if (right <= measurement)
                        {
                            boolNr++;
                        }
                    }

                    if (boolNr == 0)
                    {
                        var answer = measurement + 1;

                        part1 += answer;

                    }
                }
            }







        }


        public static void Generate()
        {
            string path = @"C:\Users\Richard\Downloads\input9.txt";
            var linesList = File.ReadAllLines(path).ToList();
            var numberOfLines = File.ReadLines(path).Count();
            int lineLength = 0;


            foreach (var line in linesList)
            {

                for (int j = 0; j < 100; j++)
                {
                    depthVals[lineLength, j] = Char.GetNumericValue(line[j]);
                }

                lineLength++;

            }
        }
    }
}
