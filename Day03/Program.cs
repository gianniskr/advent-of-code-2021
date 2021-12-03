using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Day03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solver = new Solver();
            //Console.WriteLine(solver.SolveProblemA());
            Console.WriteLine(solver.SolveProblemB());
        }

        public class Solver : IAdventOfCodeSolver
        {
            public int SolveProblemA()
            {
                var lines = AdventOfCode.ReadInput().ToList();
                var len = lines.First().Length;
                var ones = Enumerable.Repeat<int>(0, len).ToArray();
                var zeros = Enumerable.Repeat<int>(0, len).ToArray();
                foreach (var line in lines)
                {
                    for (var i = 0; i < len; i++)
                    {
                        if (line[i] == '1')
                        {
                            ones[i]++;
                        }
                        else
                        {
                            zeros[i]++;
                        }
                    }
                }

                var gammaRateArray = "";
                var epsilonRateArray = "";

                for (var i = 0; i < len; i++)
                {
                    if (ones[i] > zeros[i])
                    {
                        gammaRateArray += "1";
                        epsilonRateArray += "0";
                    }
                    else
                    {
                        gammaRateArray += "0";
                        epsilonRateArray += "1";
                    }
                }

                var gammaRate = Convert.ToInt32(gammaRateArray, 2);
                var epsilonRate = Convert.ToInt32(epsilonRateArray, 2);

                return gammaRate * epsilonRate;
            }

            public int SolveProblemB()
            {
                var lines = AdventOfCode.ReadInput().ToList();
                var flag = true;
                var oxygenEntries = lines;
                var position = 0;
                while (flag)
                {
                    var commonBit = GetCommonBitByCriteria(oxygenEntries, position, '1');
                    oxygenEntries = oxygenEntries.Where(x => x[position] == commonBit).ToList();
                    if (oxygenEntries.Count == 1)
                    {
                        flag = false;
                    }

                    position++;
                }

                flag = true;
                var co2ScrubberEntries = lines;
                position = 0;

                while (flag)
                {
                    var commonBit = GetCommonBitByCriteria(co2ScrubberEntries, position, '1');
                    commonBit = commonBit == '1' ? '0' : '1';
                    co2ScrubberEntries = co2ScrubberEntries.Where(x => x[position] == commonBit).ToList();
                    if (co2ScrubberEntries.Count == 1)
                    {
                        flag = false;
                    }

                    position++;
                }

                var oxygen = Convert.ToInt32(oxygenEntries.First(), 2);
                var co2Scrubber = Convert.ToInt32(co2ScrubberEntries.First(), 2);

                return oxygen * co2Scrubber;
            }

            private char GetCommonBitByCriteria(List<string> lines, int position, char preferredBitOnEqual)
            {
                var len = lines.First().Length;
                var ones = 0;
                var zeros = 0;
                foreach (var line in lines)
                {
                    if (line[position] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeros++;
                    }
                }

                if (ones > zeros)
                {
                    return '1';
                }

                return ones < zeros ? '0' : preferredBitOnEqual;
            }
        }
    }
}