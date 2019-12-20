using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder.Benchmarks
{
    public class InsertBenchmark : BenchmarkBase
    {
        static readonly int[] InsertIndexes = new[] { 10, 40, 100, 400, 600 };
        const int InsertIndex = 100;
        const string InsertText = "123123124124124124124123124124124124124124";

        [Benchmark]
        public void StrandedLargeInsert()
        {
            StrandedSb.Insert(InsertIndex, InsertText);
        }

        [Benchmark]
        public void MagicLargeInsert()
        {
            MagicSb.Insert(InsertIndex, InsertText);
        }

        [Benchmark]
        public void SystemLargeInsert()
        {
            SystemSb.Insert(InsertIndex, InsertText);
        }

        [Benchmark]
        public void StrandedLargeInsertMany()
        {
            foreach (var index in InsertIndexes)
                StrandedSb.Insert(index, InsertText);
        }

        [Benchmark]
        public void MagicLargeInsertMany()
        {
            foreach (var index in InsertIndexes)
                MagicSb.Insert(index, InsertText);
        }

        [Benchmark]
        public void SystemLargeInsertMany()
        {
            foreach (var index in InsertIndexes)
                SystemSb.Insert(index, InsertText);
        }
    }
}
