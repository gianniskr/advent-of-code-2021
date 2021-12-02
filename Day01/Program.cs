using System;
using System.Linq;
using Common;

namespace Day01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solver = new Solver();
            Console.WriteLine(solver.SolveProblemA());
            Console.WriteLine(solver.SolveProblemB());
        }

        private class Solver : IAdventOfCodeSolver<int>
        {
            public int SolveProblemA()
            {
                var lines = AdventOfCode.ReadInputAsInt().ToList();

                var previous = lines.First();
                var depthIncreases = 0;
                foreach (var line in lines)
                {
                    if (line > previous)
                    {
                        depthIncreases++;
                    }

                    previous = line;
                }

                return depthIncreases;
            }

            public int SolveProblemB()
            {
                var lines = AdventOfCode.ReadInputAsInt().ToArray();
                var endOfLine = lines.Length - 2;
                var previous = lines[0] + lines[1] + lines[2];
                var depthIncreases = 0;
                for (var i = 0; i < endOfLine; i++)
                {
                    var line = lines[i] + lines[i + 1] + lines[i + 2];
                    if (line > previous)
                    {
                        depthIncreases++;
                    }
                    previous = line;
                }

                return depthIncreases;
            }
        }
    }
}