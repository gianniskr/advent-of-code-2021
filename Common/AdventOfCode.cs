﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    public interface IAdventOfCodeSolver
    {
    }

    public interface IAdventOfCodeSolver<T> : IAdventOfCodeSolver
    {
        T SolveProblemA();
        T SolveProblemB();
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

        public static IEnumerable<int> ReadInputAsLong()
        {
            var lines = File.ReadLines($"input.txt");
            return lines.Select(int.Parse);
        }
    }
}