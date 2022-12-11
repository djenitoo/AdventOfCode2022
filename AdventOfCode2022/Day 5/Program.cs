using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day_5
{
    class Program
    {
        private static Dictionary<int, Stack<string>> Stacks = new System.Collections.Generic.Dictionary<int, Stack<string>>()
        {
            { 1, new Stack<string>(new List<string>{"R", "P", "C", "D", "B", "G" }) },
            { 2, new Stack<string>(new List<string>{"H", "V", "G" }) },
            { 3, new Stack<string>(new List<string>{"N", "S", "Q", "D", "J", "P", "M" }) },
            { 4, new Stack<string>(new List<string>{"P", "S", "L", "G", "D", "C", "N", "M" }) },
            { 5, new Stack<string>(new List<string>{"J", "B", "N", "C", "P", "F", "L", "S" }) },
            { 6, new Stack<string>(new List<string>{"Q", "B", "D", "Z", "V", "G", "T", "S" }) },
            { 7, new Stack<string>(new List<string>{"B", "Z", "M", "H", "F", "T", "Q" }) },
            { 8, new Stack<string>(new List<string>{"C", "M", "D", "B", "F"}) },
            { 9, new Stack<string>(new List<string>{"F", "C", "Q", "G"}) }
        };
        private static List<int[]> Moves = new List<int[]>();

        static void Main(string[] args)
        {
            ReadInput();
            //TaskOne();
            TaskTwo();
        }

        private static void TaskOne()
        {
            DoMoves();
            var topStackNames = GetTopStackNames();

            Console.Write("Task One answer: " + topStackNames);
        }

        private static void TaskTwo()
        {
            DoCrateMover9001Moves();
            var topStackNames = GetTopStackNames();

            Console.Write("Task Two answer: " + topStackNames);
        }

        private static string GetTopStackNames()
        {
            var result = "";

            foreach (var stackItem in Stacks)
            {
                result += stackItem.Value.Pop();
            }

            return result;
        }

        private static void DoMoves()
        {
            foreach (var move in Moves)
            {
                for (int i = 0; i < move[0]; i++)
                {
                    var poped = Stacks[move[1]].Pop();
                    //push
                    Stacks[move[2]].Push(poped);
                }
            }
        }

        private static void DoCrateMover9001Moves()
        {
            foreach (var move in Moves)
            {
                var poped = new List<string>(); 
                for (int i = 0; i < move[0]; i++)
                {
                    //pop
                    poped.Add(Stacks[move[1]].Pop());
                }
                for (int i = poped.Count - 1; i >= 0; i--)
                {
                    //push
                    Stacks[move[2]].Push(poped[i]);
                }
            }
        }

        private static void ReadInput()
        {
            string inputLine = Console.ReadLine().Trim();

            while (!string.IsNullOrWhiteSpace(inputLine))
            {
                var splitMoves = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Moves.Add(new int[] { int.Parse(splitMoves[1]), int.Parse(splitMoves[3]), int.Parse(splitMoves[5]) });

                inputLine = Console.ReadLine().Trim();

            }

        }
    }
}
