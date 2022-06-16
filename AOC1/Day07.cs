using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day07
    {

        public static void Part1()
        {
            string path = @"C:\Users\Richard\Downloads\input7.txt";
            var linesList = File.ReadAllLines(path).ToList();

            var crabPositions = linesList[0].Split(',').Select(int.Parse).ToArray();
            var listLength = crabPositions.Length;


            var minVal = crabPositions.Min();
            var maxVal = crabPositions.Max();

            int[] distance = new int[maxVal];


            for (int i = 0; i < maxVal; i++)
            {
               
                for (int j = 0; j < listLength; j++)

                {
                    int val = crabPositions[j];

                    if (i == val)
                    {
                        continue;
                    }

                    if (val > i)
                    {
                        int dist = val - i;
                        distance[i] += dist;
                    }

                    if (val < i)
                    {
                        int dist = i - val;
                        distance[i] += dist;
                    }
                }
            }


            var lowest = distance.Min();
            Console.WriteLine("Day 07, part 1: The shortest distance sum is " + lowest);

        }

        public static void Part2()
        {
            string path = @"C:\Users\Richard\Downloads\input7.txt";
            var linesList = File.ReadAllLines(path).ToList();

            var crabPositions = linesList[0].Split(',').Select(int.Parse).ToArray();
            var listLength = crabPositions.Length;


            var minVal = crabPositions.Min();
            var maxVal = crabPositions.Max();

            int[] distance = new int[maxVal];


            for (int i = 0; i < maxVal; i++)
            {

                for (int j = 0; j < listLength; j++)

                {
                    int val = crabPositions[j];

                    if (i == val)
                    {
                        continue;
                    }

                    if (val > i)
                    {
                        int dist = val - i;

                        distance[i] += DistCounter(dist);
                    }

                    if (val < i)
                    {
                        int dist = i - val;

                        distance[i] += DistCounter(dist);

                    }
                }
            }


            var lowest = distance.Min();
            Console.WriteLine("Day 07, part 2: The shortest distance sum is " + lowest);

        }

        public static int DistCounter(int dist)
        {
            int dist2 = 0;

            for (int j = 1; j <= dist; j++)
            {
                dist2 += j;
            }


            return dist2;
        }
    }
}
