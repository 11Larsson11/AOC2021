using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day06
    {
        private static List<int> fishList = new List<int>();
        private static List<long> fishListLong = new List<long>();


        public static void Part1()
        {
            AddData();

            for (int i = 0; i < 80; i++)
            {

                int counter = fishList.Count;

                for (int j = 0; j < counter; j++)
                {
                    int fishNr = fishList[j];
                    Develop(fishNr, j);
                }

            }

            var answer = fishList.Count();
            Console.WriteLine("Day 06, part 1: The number of lanternfishes after 80 days are: " + answer);

        }

        public static void Part2()
        {
            AddData();

            long[] fishArray = new long[9];
            long totalNumber = 0;

            foreach (var item in fishListLong)
            {
                fishArray[item] = fishArray[item] + 1;
            }


            for (int i = 0; i < 256; i++)
            {

                long zeroes = fishArray[0];
                long ones = fishArray[1];
                long twos = fishArray[2];
                long threes = fishArray[3];
                long fours = fishArray[4];
                long fives = fishArray[5];
                long sixes = fishArray[6];
                long sevens = fishArray[7];
                long eights = fishArray[8];

                
                fishArray[8] = zeroes;
                fishArray[7] = eights;
                fishArray[6] = sevens + zeroes;
                fishArray[5] = sixes;
                fishArray[4] = fives;
                fishArray[3] = fours;
                fishArray[2] = threes;
                fishArray[1] = twos;
                fishArray[0] = ones;


            }

            for(int i = 0;i <= 8;i++)
            {
                totalNumber += fishArray[i];

            }

            Console.WriteLine("Day 06, part 2: The total number of lanternfishes after 256 days are " + totalNumber);
        }



        public static void AddData()
        {
            string inputVals = "1,3,4,1,1,1,1,1,1,1,1,2,2,1,4,2,4,1,1,1,1,1,5,4,1,1,2,1,1,1,1,4,1,1,1,4,4," +
"1,1,1,1,1,1,1,2,4,1,3,1,1,2,1,2,1,1,4,1,1,1,4,3,1,3,1,5,1,1,3,4,1,1,1,3,1,1,1,1,1,1,1," +
"1,1,1,1,1,1,5,2,5,5,3,2,1,5,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,5,1,1,1,1,5,1,1,1,1,1,4," +
"1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,3,1,2,4,1,5,5,1,1,5,3,4,4,4,1,1,1,2,1,1,1,1,1,1,2,1," +
"1,1,1,1,1,5,3,1,4,1,1,2,2,1,2,2,5,1,1,1,2,1,1,1,1,3,4,5,1,2,1,1,1,1,1,5,2,1,1,1,1,1,1," +
"5,1,1,1,1,1,1,1,5,1,4,1,5,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,5,4,5,1,1,1,1,1,1,1,5,1," +
"1,3,1,1,1,3,1,4,2,1,5,1,3,5,5,2,1,3,1,1,1,1,1,3,1,3,1,1,2,4,3,1,4,2,2,1,1,1,1,1,1,1,5," +
"2,1,1,1,2";

            var fishInit = inputVals.Split(',').Select(int.Parse).ToList();

            fishList = fishInit;

            var fishInitLong = inputVals.Split(',').Select(long.Parse).ToList();

            fishListLong = fishInitLong;

        }


        public static void Develop(int age, int j)
        {
            if (age == 0)
            {
                fishList.Add(8);
                fishList[j] = 6;
            }

            if (age > 0)
            {
                int newAge = age -= 1;
                fishList[j] = newAge;
            }
        }
    }
}
