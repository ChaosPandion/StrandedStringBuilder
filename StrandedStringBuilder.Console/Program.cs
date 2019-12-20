using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StrandedStringBuilder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var permutations = new List<(string insert, int index, string expectation)>();
            var data = new[] { "AAA", "BBB", "CCC", "DDD" };
            var fullString = "AAABBBCCCDDD";
            var totalLengh = 12;

            for (int i = 0; i < totalLengh; i++)
            {
                var v = fullString.Insert(i, "ZZZ");
                permutations.Add(("ZZZ", i, v));
            }

            var sb = new System.Text.StringBuilder();
            foreach (var p in permutations)
            {
                sb.AppendLine($"[InlineData(new[] {{ \"AAA\", \"BBB\", \"CCC\", \"DDD\" }}, \"{p.insert}\", {p.index}, \"{p.expectation}\")]");
            }
            Debug.WriteLine(sb);
        }
    }
}
