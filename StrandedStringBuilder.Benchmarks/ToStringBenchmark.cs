using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder.Benchmarks
{
    [HardwareCounters(HardwareCounter.CacheMisses)]
    public class ToStringBenchmark : BenchmarkBase
    {
        [Benchmark]
        public string StrandedStringBuilderLargeAppendToString()
        {
            return StrandedSb.ToString();
        }

        [Benchmark]
        public string MagicStringBuilderLargeAppendToString()
        {
            return MagicSb.ToString();
        }

        [Benchmark]
        public string SystemStringBuilderLargeAppendToString()
        {
            return SystemSb.ToString();
        }
    }
}
