using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day01
    {
        public static void Part1and2()
        {
            string path = @"C:\Users\Richard\Downloads\input.txt";

            int count = 0;
            int counter = 0;
            var lines = File.ReadLines(path).ToArray();

            int[] array = new int[lines.Length];


            foreach (var line in lines)
            {

                int numberA = Int32.Parse(line);

                array[count++] = numberA;

            }


            for (int i = 1; i < lines.Length; i++)
            {
                if (array[i - 1] < array[i])
                    counter++;
            }

            Console.WriteLine("Day 1, part 1: The number of occurances with greater numbers are: " + counter);

            for (int i = 3; i < lines.Length; i++)
            {
                if ((array[i - 3] + array[i - 2] + array[i - 1]) < (array[i - 2] + array[i - 1] + array[i]))
                    counter++;
            }

            Console.WriteLine("Day 1, part 2: The number of occurances with greater sequence than last are " + counter);

        }
    }
}
