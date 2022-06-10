using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day04
    {

        private static readonly List<SingleBoards> allBoards = new List<SingleBoards>();

        public static void Part1()
        {
            string path = @"C:\Users\Richard\Downloads\input4.txt";
            var numberOfLines = File.ReadLines(path).Count();
            var linesList = File.ReadAllLines(path).ToList();

            var bingoNumbers = linesList[0].Split(',').Select(int.Parse).ToList();
            int[,] singleBoard = new int[5, 5];
            int lineNr = 0;



            for (int i = 1; i < numberOfLines; i++)
            {


                if (linesList[i] != "" + "")
                {
                    string[] first = linesList[i].Split(new char[] { ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < 5; j++)
                    {
                        int number = Convert.ToInt32(first[j]);
                        singleBoard[lineNr, j] = number;
                    }
                    lineNr++;
                }


                if (linesList[i] == "")

                {
                    int[,] singleBoard2 = new int[5, 5];

                    singleBoard = singleBoard2;
                    lineNr = 0;

                    allBoards.Add(new SingleBoards(singleBoard2));


                }

            }

            int numbersFound = 0;

            foreach (var number in bingoNumbers)
            {
                foreach (var board in allBoards)
                {
                    board.Check(number);

                    if (board.IsWinner())
                    {
                        numbersFound++;

                        if (numbersFound == 1)
                        {
                            Console.WriteLine("Day 4, part 1 - the final score is: " + board.FinalScore());
                            break;
                        }


                    }
                }
            }
        }

        public static void Part2()
        {
            string path = @"C:\Users\Richard\Downloads\input4.txt";
            var numberOfLines = File.ReadLines(path).Count();
            var linesList = File.ReadAllLines(path).ToList();

            var bingoNumbers = linesList[0].Split(',').Select(int.Parse).ToList();
            int[,] singleBoard = new int[5, 5];
            int lineNr = 0;



            for (int i = 1; i < numberOfLines; i++)
            {


                if (linesList[i] != "" + "")
                {
                    string[] first = linesList[i].Split(new char[] { ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < 5; j++)
                    {
                        int number = Convert.ToInt32(first[j]);
                        singleBoard[lineNr, j] = number;
                    }
                    lineNr++;
                }


                if (linesList[i] == "")

                {
                    int[,] singleBoard2 = new int[5, 5];

                    singleBoard = singleBoard2;
                    lineNr = 0;

                    allBoards.Add(new SingleBoards(singleBoard2));


                }

            }


            int lastNr = 0;

            List<int> boards = new List<int>();

            foreach (var number in bingoNumbers)
            {
                foreach (var board in allBoards)
                {
                    board.Check(number);

                    if (allBoards.All(b => b.IsWinner()))
                    {
                        lastNr++;

                        if (lastNr == 1)
                        {
                            Console.WriteLine("Day 4, part two: The sum of the last board is " + board.FinalScore());
                            break;
                        }
                        
                    }
                }
            }
        }


        private class SingleBoards
        {
            private readonly int[,] _singleBoard = new int[5, 5];
            private readonly bool[,] _markedNrs = new bool[5, 5];
            int lastNr = 0;
            bool winnerFound;


            public SingleBoards(int[,] filledBoard)
            {
                _singleBoard = filledBoard;
            }

            public void Check(int bingoNr)
            {
                if (IsWinner())
                {
                    return;
                }

                else
                {
                    lastNr = bingoNr;

                    for (var i = 0; i < 5; i++)
                    {
                        for (var j = 0; j < 5; j++)
                        {
                            if (_singleBoard[i, j] == bingoNr)
                            {
                                _markedNrs[i, j] = true;
                            }
                        }
                    
                    }

                    for (var i = 0; i < 5; i++)
                    {

                        bool testRow = true;
                        bool testCol = true;

                        for (var j = 0; j < 5; j++)
                        {
                            testRow &= _markedNrs[i, j];
                            testCol &= _markedNrs[j, i];
                        }

                        if (testRow == false && testCol == false)
                        {
                            //winnerFound = false;
                            continue;
                        }

                        else
                        {
                            winnerFound = true;
                            return;
                        }


                    }
                }
            }


            public bool IsWinner()
            {
                return winnerFound;
            }

            public int FinalScore()
            {
                var sumOfNrs = 0;

                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if (_markedNrs[i, j] == false)
                        {
                            sumOfNrs += _singleBoard[i, j];
                        }
                    }
                }

                var answer = sumOfNrs * lastNr;


                return answer;
            }
        }
    }
}
