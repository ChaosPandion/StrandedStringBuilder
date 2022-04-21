using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder.Benchmarks
{
    //[HardwareCounters(HardwareCounter.CacheMisses)]
    public class RemoveBenchmark : BenchmarkBase
    {
        [Benchmark]
        public void StrandedStringBuilderLargeAppendRemove()
        {
            StrandedSb.Remove(10, 30);
        }


        [Benchmark]
        public void MagicStringBuilderLargeAppendRemove()
        {
            MagicSb.Remove(10, 30);
        }

        [Benchmark]
        public void SystemStringBuilderLargeAppendRemove()
        {
            SystemSb.Remove(10, 30);
        }


        [Benchmark]
        public void StrandedStringBuilderRemoveMany()
        {
            StrandedSb.Remove(0, 5);
            StrandedSb.Remove(10, 5);
            StrandedSb.Remove(0, 5);
            StrandedSb.Remove(15, 5);
        }


        [Benchmark]
        public void MagicStringBuilderRemoveMany()
        {
            MagicSb.Remove(0, 5);
            MagicSb.Remove(10, 5);
            MagicSb.Remove(0, 5);
            MagicSb.Remove(15, 5);
        }

        [Benchmark]
        public void SystemStringBuilderRemoveMany()
        {
            SystemSb.Remove(0, 5);
            SystemSb.Remove(10, 5);
            SystemSb.Remove(0, 5);
            SystemSb.Remove(15, 5);
        }
    }
}
