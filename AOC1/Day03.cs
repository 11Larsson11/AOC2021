using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day03
    {
        public static void Part1and2()
        {

            string path = @"C:\Users\Richard\Downloads\input3.txt";

            var lines = File.ReadLines(path).ToArray();
            var linesList = File.ReadAllLines(path).ToList();
            var numberOfLines = linesList[0].Length;


            var lineLength = 0;
            var numLength = 0;

            int[] gammaRate = new int[12];

            var epsilonRates = "";
            var gammaRates = "";



            foreach (var line in lines)

            {

                for (int i = 0; i < line.Length; i++)
                {

                    if (line[i] == '1')

                    {
                        gammaRate[i] += 1;
                    }

                }

                lineLength = line.Length;
                numLength = lines.Length;
            }

            // Solution for part 1


            for (int i = 0; i < lineLength; i++)
            {

                if (gammaRate[i] > numLength / 2)
                {
                    epsilonRates += 0;
                    gammaRates += 1;
                }

                else
                {
                    epsilonRates += 1;
                    gammaRates += 0;
                }

            }


            //Part 1 results


            var result = Convert.ToInt32(gammaRates, 2) * Convert.ToInt32(epsilonRates, 2);

            Console.WriteLine("Day 3, part 1: the result is " + result);



            //Solution for part 2



            var numbers = new List<string>(linesList);
            var numbers2 = new List<string>(linesList);


            //Oxygen loop

            for (var i = 0; i < numberOfLines; i++)
            {
                var ones = numbers.Count(s => s[i] == '1');

                var mostCommon = ones >= numbers.Count / 2d ? '1' : '0';


                numbers = numbers.Where(s => s[i] == mostCommon).ToList();

                if (numbers.Count == 1) break;
            }

            //CO2 loop

            for (var i = 0; i < linesList[0].Length; i++)
            {
                var ones = numbers2.Count(s => s[i] == '1');

                var leastCommon = ones < numbers2.Count / 2d ? '1' : '0';

                numbers2 = numbers2.Where(s => s[i] == leastCommon).ToList();

                if (numbers2.Count == 1) break;
            }


            //Part 2 results

            var oxygenValue = Convert.ToInt32(numbers.First(), 2);
            var co2Value = Convert.ToInt32(numbers2.First(), 2);


            var total2 = oxygenValue * co2Value;

            Console.WriteLine("Day 3, part 2: the result is " + total2);


        }
    }
}
