using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    class Program
    {
        private static List<string> StrategyGuide = new List<string>();
        private static Dictionary<string, int> StrategyGuidePossibilities = new Dictionary<string, int>()
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 3 }
        };
        private static int LostPoints = 0;
        private static int DrawPoints = 3;
        private static int WinPoints = 6;

        static void Main(string[] args)
        {
            //TaskOne();
            TaskTwo();
        }

        private static void TaskOne()
        {
            ReadInput();
            var myTotalScore = GetMyTotalScore();
            Console.WriteLine("Task One answer: " + myTotalScore);
        }

        private static void TaskTwo()
        {
            ReadInputWithStrategy();
            var myTotalScore = GetMyTotalScore();
            Console.WriteLine("Task Two answer: " + myTotalScore);
        }

        private static int GetMyTotalScore()
        {
            int totalScore = 0;

            foreach (string round in StrategyGuide)
            {
                string oponent = round[0].ToString();
                string me = round[1].ToString();

                if (oponent == me) //draw
                {
                    totalScore += StrategyGuidePossibilities[me];
                    totalScore += DrawPoints;
                    continue;
                }

                totalScore += StrategyGuidePossibilities[me];
                /*
                 A - Rock
                 B - Paper
                 C - Scissors
                 */
                switch (round)
                {
                    case "AB":
                    case "BC":
                    case "CA":
                        // win
                        totalScore += WinPoints;
                        break;
                        //case "BA":
                        //case "CB":
                        //case "AC":
                        //default:
                        //    // lose
                        //    totalScore += LostPoints;
                        //    break;
                }
            }


            return totalScore;
        }

        private static void ReadInput()
        {
            string inputLine = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                inputLine = inputLine.Replace("X", "A").Replace("Y", "B").Replace("Z", "C").Replace(" ", "");
                StrategyGuide.Add(inputLine);

                inputLine = Console.ReadLine();
            }
        }

        private static void ReadInputWithStrategy()
        {
            string inputLine = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                inputLine = inputLine.Replace(" ", "");
                string oponent = inputLine[0].ToString();

                if (inputLine[1].ToString() == "Y")
                {
                    inputLine = inputLine[0].ToString() + inputLine[0];
                }
                else if (inputLine[1].ToString() == "X")
                {
                    int loseValue = (StrategyGuidePossibilities[oponent] - 1);
                    if (0 >= loseValue)
                    {
                        loseValue = 3;
                    }
                    string loseKey = StrategyGuidePossibilities.FirstOrDefault(kv => kv.Value == loseValue).Key;

                    inputLine = inputLine[0] + loseKey;
                }
                else if (inputLine[1].ToString() == "Z")
                {
                    int winValue = StrategyGuidePossibilities[oponent] + 1;
                    if (winValue >= 4)
                    {
                        winValue = 1;
                    }
                    string winKey = StrategyGuidePossibilities.FirstOrDefault(kv => kv.Value == winValue).Key;

                    inputLine = inputLine[0] + winKey;
                }

                StrategyGuide.Add(inputLine);

                inputLine = Console.ReadLine();
            }
        }
    }
}
