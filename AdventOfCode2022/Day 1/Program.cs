using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_1
{
    class Program
    {
        private static List<int> ElfFood = new List<int>();

        static void Main(string[] args)
        {
            ReadInput();
            TaskOne();
            TaskTwo();
        }

        private static void TaskOne()
        {
            //ReadInput();
            Console.WriteLine("Task One answer: " + ElfFood.Max());
        }

        private static void TaskTwo()
        {
            //ReadInput();
            var top3SumOfCalories = ElfFood.OrderByDescending(x => x).Take(3).Sum(x => x);
            Console.WriteLine("Task Two answer: " + top3SumOfCalories);
        }

        private static void ReadInput()
        {
            string inputLine = Console.ReadLine();
            var currentElfFood = 0;

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                currentElfFood += (int.Parse(inputLine));

                inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    ElfFood.Add(currentElfFood);
                    currentElfFood = 0;
                    inputLine = Console.ReadLine();
                }
            }
        }
    }
}
