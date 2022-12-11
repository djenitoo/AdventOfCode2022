using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_3
{
    class Program
    {
        private static List<string[]> RucksackInputs = new List<string[]>();
        private static List<string> RucksackTeamInputs = new List<string>();

        static void Main(string[] args)
        {
            //TaskOne();
            TaskTwo();
        }

        private static void TaskOne()
        {
            ReadInput();
            var repeatingItems = GetRepeatingItemInCompartments();
            var sumOfRepeatingItems = GetSumOfRepeatingItems(repeatingItems);

            Console.WriteLine("Task One answer: " + sumOfRepeatingItems);
        }

        private static void TaskTwo()
        {
            ReadInputTaskTwo();
            var badgesOfTeams = GetBadgesOfTeams();
            var sumOfRepeatingItems = GetSumOfRepeatingItems(badgesOfTeams);

            Console.WriteLine("Task Two answer: " + sumOfRepeatingItems);
        }

        private static List<char> GetBadgesOfTeams()
        {
            var badgesOfTeams = new List<char>();

            for (int i = 0; i < RucksackTeamInputs.Count; i += 3)
            {
                var elfMemberOne = RucksackTeamInputs[i];
                var elfMemberTwo = RucksackTeamInputs[i + 1];
                var elfMemberThree = RucksackTeamInputs[i + 2];

                foreach (var item in elfMemberOne)
                {
                    if (elfMemberTwo.IndexOf(item) > -1 && elfMemberThree.IndexOf(item) > -1)
                    {
                        badgesOfTeams.Add(item);
                        break;
                    }
                }
            }

            return badgesOfTeams;
        }

        private static int GetSumOfRepeatingItems(List<char> repeatingItems)
        {
            return repeatingItems.Select(x => GetItemValue(x)).Sum();
        }

        private static int GetItemValue(char item)
        {
            if (char.IsLower(item))
            {
                return (int)item - 96;
            }
            else
            {
                return ((int)item - 64) + 26;
            }
        }

        private static List<char> GetRepeatingItemInCompartments()
        {
            var repeatingItems = new List<char>();

            foreach (var rucksack in RucksackInputs)
            {
                string compartmentOne = rucksack[0];
                string compartmentTwo = rucksack[1];

                foreach (var item in compartmentOne)
                {
                    if (compartmentTwo.IndexOf(item) > -1)
                    {
                        repeatingItems.Add(item);
                        break;
                    }
                }
            }

            return repeatingItems;
        }

        private static void ReadInput()
        {
            string inputLine = Console.ReadLine().Trim();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                var currentRucksackInput = new string[2];
                currentRucksackInput[0] = inputLine.Substring(0, inputLine.Length / 2);
                currentRucksackInput[1] = inputLine.Substring(inputLine.Length / 2);
                RucksackInputs.Add(currentRucksackInput);

                inputLine = Console.ReadLine();
            }
        }

        private static void ReadInputTaskTwo()
        {
            string inputLine = Console.ReadLine().Trim();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                RucksackTeamInputs.Add(inputLine);

                inputLine = Console.ReadLine();
            }
        }
    }
}
