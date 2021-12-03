using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solver = new Solver();
            Console.WriteLine(solver.SolveProblemA());
            Console.WriteLine(solver.SolveProblemB());
        }

        private class Solver : IAdventOfCodeSolver
        {
            public int SolveProblemA()
            {
                var lines = AdventOfCode.ReadInput().Select(ParseInstructions).ToList();
                var position = 0;
                var depth = 0;
                foreach (var valueTuple in lines)
                {
                    switch (valueTuple.Item1)
                    {
                        case "forward":
                            position = position + valueTuple.Item2;
                            break;
                        case "up":
                            depth = depth - valueTuple.Item2;
                            break;
                        case "down":
                            depth = depth + valueTuple.Item2;
                            break;
                        default:
                            throw new Exception("unknown command");
                    }
                }

                return position * depth;
            }

            public int SolveProblemB()
            {
                var lines = AdventOfCode.ReadInput().Select(ParseInstructions).ToList();
                var position = 0;
                var depth = 0;
                var aim = 0;
                foreach (var valueTuple in lines)
                {
                    switch (valueTuple.Item1)
                    {
                        case "forward":
                            position = position + valueTuple.Item2;
                            depth = depth + aim * valueTuple.Item2;
                            break;
                        case "up":
                            aim = aim - valueTuple.Item2;
                            break;
                        case "down":
                            aim = aim + valueTuple.Item2;
                            break;
                        default:
                            throw new Exception("unknown command");
                    }
                }

                return position * depth;
            }

            private (string, int) ParseInstructions(string line)
            {
                var res = line.Split(' ');
                return (res[0], int.Parse(res[1]));
            }
        }
    }
}