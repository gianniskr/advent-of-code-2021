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
            solver.SolveProblemA();
            solver.SolveProblemB();
        }

        private class Solver : IAdventOfCodeSolver
        {
            public void SolveProblemA()
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

                Console.WriteLine(depthIncreases);
            }

            public void SolveProblemB()
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

                    Console.WriteLine($"{i}: {line} {depthIncreases}");
                    previous = line;
                }

                Console.WriteLine(depthIncreases);
            }
        }
    }
}