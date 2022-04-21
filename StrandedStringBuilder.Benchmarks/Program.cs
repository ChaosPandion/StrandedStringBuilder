using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Columns;
using System;
using System.Collections.Generic;
using System.Reflection;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using System.Collections.Immutable;
using System.Linq;

namespace StrandedStringBuilder.Benchmarks
{
    public class StrandedStringBuilderBenchmark
    {
        const int largeAppendCount = 4000;

        private static readonly object[] _appendData = new object[]
        {
            true,
            false,
            3825264,
            819081258,
            404151134,
            1151983273,
            25120296,
            398909940,
            293316475,
            1618543976,
            1813591724,
            2018256345,
            "eb712344-5975-446a-a44e-19e1c00be586",
            "672f3bc9-8e3b-405a-8341-5a41574a69ba",
            "4974a75b-b5c1-492d-8f5e-13dbe75f0c7f",
            "0ba22583-93bb-4261-bb04-f45f550a6fa9",
            "f694d36f-7fa7-41e5-a189-7fea6506cf5e",
            "d67c926a-6f60-400e-9cd7-38a3d42622e8",
            "c5ebde07-ec91-4ffb-8407-cd0e8339a57c",
            "c297e53a-b591-49dd-b8a4-cba0f87c332d",
            "c7ecfdf5-ca02-47ee-8e32-b53716349496",
            "124f91eb-c20c-4df1-a0a1-f33a0203a914",
            new DateTime(2019, 12, 6),
            new DateTime(2019, 11, 6),
            new DateTime(2019, 10, 6),
            new DateTime(2019, 9, 6),
        };

        //[Benchmark]
        //public void StrandedStringBuilderAppend()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //}

        //[Benchmark]
        //public void MagicStringBuilderAppend()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //}

        //[Benchmark]
        //public void SystemStringBuilderAppend()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //}



        //[Benchmark]
        //public void StrandedStringBuilderLargeAppend()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //}

        //[Benchmark]
        //public void MagicStringBuilderLargeAppend()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //}

        //[Benchmark]
        //public void SystemStringBuilderLargeAppend()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //}




        //[Benchmark]
        //public string StrandedStringBuilderAppendToString()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    return sb.ToString();
        //}


        //[Benchmark]
        //public string MagicStringBuilderAppendToString()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    return sb.ToString();
        //}

        //[Benchmark]
        //public string SystemStringBuilderAppendToString()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    return sb.ToString();
        //}



        //[Benchmark]
        //public string StrandedStringBuilderLargeAppendToString()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    return sb.ToString();
        //}

        //[Benchmark]
        //public string MagicStringBuilderLargeAppendToString()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    return sb.ToString();
        //}

        //[Benchmark]
        //public string SystemStringBuilderLargeAppendToString()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    return sb.ToString();
        //}


        //[Benchmark]
        //public void StrandedStringBuilderShortRemove()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    sb.Append("123").Append(456);
        //    sb.Remove(2, 2);
        //}

        //[Benchmark]
        //public void MagicStringBuilderShortRemove()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    sb.Append("123").Append(456);
        //    sb.Remove(2, 2);
        //}

        //[Benchmark]
        //public void SystemStringBuilderShortRemove()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    sb.Append("123").Append(456);
        //    sb.Remove(2, 2);
        //}


        //[Benchmark]
        //public void StrandedStringBuilderLargeAppendRemove()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Remove(10, 30);
        //}


        //[Benchmark]
        //public void MagicStringBuilderLargeAppendRemove()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Remove(10, 30);
        //}

        //[Benchmark]
        //public void SystemStringBuilderLargeAppendRemove()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Remove(10, 30);
        //}


        //[Benchmark]
        //public void StrandedStringBuilderRemoveMany()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    sb.Remove(0, 5);
        //    sb.Remove(10, 5);
        //    sb.Remove(0, 5);
        //    sb.Remove(15, 5);
        //}


        //[Benchmark]
        //public void MagicStringBuilderRemoveMany()
        //{
        //    var sb = new MagicStringBuilder.MagicBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    sb.Remove(0, 5);
        //    sb.Remove(10, 5);
        //    sb.Remove(0, 5);
        //    sb.Remove(15, 5);
        //}

        //[Benchmark]
        //public void SystemStringBuilderRemoveMany()
        //{
        //    var sb = new System.Text.StringBuilder();
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Remove(0, 5);
        //    sb.Remove(10, 5);
        //    sb.Remove(0, 5);
        //    sb.Remove(15, 5);
        //}


        //[Benchmark]
        //public void StrandedStringBuilderReplace()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    sb.Replace("2018256345", "123");
        //}

        //[Benchmark]
        //public void SystemStringBuilderReplace()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    sb.Replace("2018256345", "123");
        //}


        //[Benchmark]
        //public void StrandedStringBuilderLargeAppendReplace()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Replace("2018256345", "123");
        //}

        //[Benchmark]
        //public void SystemStringBuilderLargeAppendReplace()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    for (int i = 0; i < largeAppendCount; i++)
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Replace("2018256345", "123");
        //}


        //[Benchmark]
        //public void StrandedStringBuilderReplaceMany()
        //{
        //    var sb = new StrandedStringBuilder.StringBuilder();
        //        foreach (var item in _appendData)
        //            sb.Append(item);
        //    sb.Replace("1618543976", "123");
        //    sb.Replace("1813591724", "123");
        //    sb.Replace("2018256345", "123");
        //}

        //[Benchmark]
        //public void SystemStringBuilderReplaceMany()
        //{
        //    var sb = new System.Text.StringBuilder();
        //    foreach (var item in _appendData)
        //        sb.Append(item);
        //    sb.Replace("1618543976", "123");
        //    sb.Replace("1813591724", "123");
        //    sb.Replace("2018256345", "123");
        //}
    }

    class SummaryOrderer : IOrderer
    {
        public bool SeparateLogicalGroups => true;

        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase)
        {
            return benchmarksCase.OrderBy(x => x.Descriptor.Type.Name);
        }

        public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
        {
            return "";
        }

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
        {
            return benchmarkCase.Descriptor.Type.Name;
        }

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups)
        {
            return logicalGroups;
        }

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary)
        {
            return benchmarksCases.OrderBy(x => x.Descriptor.Type.Name).ThenBy(x => x.DisplayInfo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance);
            config.AddDiagnoser(MemoryDiagnoser.Default);
            //config.AddHardwareCounters(HardwareCounter.CacheMisses);
            //config.AddHardwareCounters(HardwareCounter.TotalCycles);

            config.Options |= ConfigOptions.JoinSummary;
            config.Orderer = new SummaryOrderer();
            BenchmarkRunner.Run(Assembly.GetExecutingAssembly(), config);
            Console.ReadLine();
        }
    }
}
