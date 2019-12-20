using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder.Benchmarks
{
    [HardwareCounters(HardwareCounter.CacheMisses)]
    public class ReplaceBenchmark : BenchmarkBase
    {
        [Benchmark]
        public void StrandedStringBuilderLargeAppendReplace()
        {
            StrandedSb.Replace("2018256345", "123");
        }

        [Benchmark]
        public void SystemStringBuilderLargeAppendReplace()
        {
            SystemSb.Replace("2018256345", "123");
        }


        [Benchmark]
        public void StrandedStringBuilderReplaceMany()
        {
            StrandedSb.Replace("1618543976", "123");
            StrandedSb.Replace("1813591724", "123");
            StrandedSb.Replace("2018256345", "123");
        }

        [Benchmark]
        public void SystemStringBuilderReplaceMany()
        {
            SystemSb.Replace("1618543976", "123");
            SystemSb.Replace("1813591724", "123");
            SystemSb.Replace("2018256345", "123");
        }
    }
}
