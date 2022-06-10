using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day02
    {

        public static void Part1and2()
        {

            string path = @"C:\Users\Richard\Downloads\input2.txt";

            int forward = 0;
            int depth = 0;

            int aim = 0;
            int position = 0;

            var lines = File.ReadLines(path).ToArray();
            int[] array = new int[lines.Length];


            foreach (var line in lines)
            {

                if (line.StartsWith("f"))
                {

                    int value = int.Parse(new String(line.Where(Char.IsDigit).ToArray()));

                    forward += value;

                    position += value * aim;

                }

                if (line.StartsWith("u"))
                {
                    int value = int.Parse(new String(line.Where(Char.IsDigit).ToArray()));

                    depth -= value;

                    aim -= value;

                }

                if (line.StartsWith("d"))
                {
                    int value = int.Parse(new String(line.Where(Char.IsDigit).ToArray()));

                    depth += value;

                    aim += value;
                }

            }

            var total = forward * depth;

            var total2 = forward * position;

            Console.WriteLine("Day 2, part 1: The total is " + total);   //Part 1

            Console.WriteLine("Day 2, part 2: The total is " + total2);  //Part 2

        }
    }
}
