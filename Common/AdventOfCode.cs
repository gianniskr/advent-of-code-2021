using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public interface IAdventOfCodeSolver
    {
        int SolveProblemA();
        int SolveProblemB();
    }

    public static class AdventOfCode
    {
        public static IEnumerable<string> ReadInput()
        {
            return File.ReadLines($"input.txt");
        }

        public static IEnumerable<int> ReadInputAsInt()
        {
            var lines = File.ReadLines($"input.txt");
            return lines.Select(int.Parse).ToList();
        }

        public static IEnumerable<long> ReadInputAsLong()
        {
            var lines = File.ReadLines($"input.txt");
            return lines.Select(long.Parse);
        }
    }
}