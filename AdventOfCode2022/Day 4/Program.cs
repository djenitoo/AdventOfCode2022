using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4
{
    class Program
    {
        private static List<List<int>> CleaningAssigment = new List<List<int>>();

        static void Main(string[] args)
        {
            ReadInput();
            TaskOne();
            TaskTwo();
        }

        private static void TaskOne()
        {
            var countOfFullyOverlappingCleaningAssigments = GetCountOfAssigmentsFullyContainedInOther();

            Console.WriteLine("Task One answer: " + countOfFullyOverlappingCleaningAssigments);
        }

        private static void TaskTwo()
        {
            var countOfAtLeastPartialOverlapCleaningAssigments = GetCountOfAssigmentsAtLeastPartialOverlap();
            Console.WriteLine("Task Two answer: " + countOfAtLeastPartialOverlapCleaningAssigments);
        }

        private static int GetCountOfAssigmentsFullyContainedInOther()
        {
            var count = 0;

            foreach (var groupAssigment in CleaningAssigment)
            {
                var smallCleaningRangeSectionMap = new Dictionary<int, int>();
                int[] smallerRange = null;
                int[] biggerRange = null;

                if (groupAssigment[1] - groupAssigment[0] > groupAssigment[3] - groupAssigment[2])
                {
                    biggerRange = new int[]
                    {
                        groupAssigment[0],
                        groupAssigment[1]
                    };
                    smallerRange = new int[]
                    {
                        groupAssigment[2],
                        groupAssigment[3],
                    };
                }
                else
                {
                    smallerRange = new int[]
                    {
                        groupAssigment[0],
                        groupAssigment[1]
                    };
                    biggerRange = new int[]
                    {
                        groupAssigment[2],
                        groupAssigment[3],
                    };
                }

                for (int i = smallerRange[0]; i <= smallerRange[1]; i++)
                {
                    smallCleaningRangeSectionMap[i] = 1;
                }

                for (int i = biggerRange[0]; i <= biggerRange[1]; i++)
                {
                    if (smallCleaningRangeSectionMap.ContainsKey(i))
                    {
                        smallCleaningRangeSectionMap[i] = smallCleaningRangeSectionMap[i] + 1;
                    }
                }

                if (smallCleaningRangeSectionMap.Values.All(v => v > 1))
                {
                    count++;
                }

            }

            return count;
        }

        private static int GetCountOfAssigmentsAtLeastPartialOverlap()
        {
            var count = 0;

            foreach (var groupAssigment in CleaningAssigment)
            {
                var smallCleaningRangeSectionMap = new Dictionary<int, int>();
                int[] smallerRange = null;
                int[] biggerRange = null;

                if (groupAssigment[1] - groupAssigment[0] > groupAssigment[3] - groupAssigment[2])
                {
                    biggerRange = new int[]
                    {
                        groupAssigment[0],
                        groupAssigment[1]
                    };
                    smallerRange = new int[]
                    {
                        groupAssigment[2],
                        groupAssigment[3],
                    };
                }
                else
                {
                    smallerRange = new int[]
                    {
                        groupAssigment[0],
                        groupAssigment[1]
                    };
                    biggerRange = new int[]
                    {
                        groupAssigment[2],
                        groupAssigment[3],
                    };
                }

                for (int i = smallerRange[0]; i <= smallerRange[1]; i++)
                {
                    smallCleaningRangeSectionMap[i] = 1;
                }

                for (int i = biggerRange[0]; i <= biggerRange[1]; i++)
                {
                    if (smallCleaningRangeSectionMap.ContainsKey(i))
                    {
                        count++;
                        break;
                    }
                }

            }

            return count;
        }

        private static void ReadInput()
        {
            string inputLine = Console.ReadLine().Trim();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                List<int> currentCleaningAssigment = new List<int>();
                var splitAssigments = inputLine.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in splitAssigments)
                {
                    currentCleaningAssigment.Add(int.Parse(item));
                }

                CleaningAssigment.Add(currentCleaningAssigment);
                inputLine = Console.ReadLine();
            }
        }
    }
}
