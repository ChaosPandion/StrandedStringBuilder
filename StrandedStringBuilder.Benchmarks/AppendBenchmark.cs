using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrandedStringBuilder.Benchmarks
{
    //[HardwareCounters(HardwareCounter.CacheMisses)]
    public class AppendBenchmark : BenchmarkBase
    {
        [Benchmark]
        public void StrandedStringBuilderAppend()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            foreach (var item in AppendData)
                sb.Append(item);
        }

        [Benchmark]
        public void MagicStringBuilderAppend()
        {
            var sb = new MagicStringBuilder.MagicBuilder();
            foreach (var item in AppendData)
                sb.Append(item);
        }

        [Benchmark]
        public void SystemStringBuilderAppend()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in AppendData)
                sb.Append(item);
        }



        [Benchmark]
        public void StrandedStringBuilderLargeAppend()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in AppendData)
                    sb.Append(item);
        }

        [Benchmark]
        public void MagicStringBuilderLargeAppend()
        {
            var sb = new MagicStringBuilder.MagicBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in AppendData)
                    sb.Append(item);
        }

        [Benchmark]
        public void SystemStringBuilderLargeAppend()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in AppendData)
                    sb.Append(item);
        }


        [Benchmark]
        public void StrandedStringBuilderAppendStringProducer()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            foreach (var item in AppendData)
            {
                var data = item;
                var h = DateTime.Now.Hour;
                var m = DateTime.Now.Minute;
                var s = DateTime.Now.Second;
                sb.Append(() => $"{data}{h}{m}{s}");
            }
        }

        [Benchmark]
        public void MagicStringBuilderAppendStringProducer()
        {
            var sb = new MagicStringBuilder.MagicBuilder();
            foreach (var item in AppendData)
            {
                var data = item;
                var h = DateTime.Now.Hour;
                var m = DateTime.Now.Minute;
                var s = DateTime.Now.Second;
                var r = $"{data}{h}{m}{s}";
                sb.Append(r);
            }
        }

        [Benchmark]
        public void SystemStringBuilderAppendStringProducer()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in AppendData)
            {
                var data = item;
                var h = DateTime.Now.Hour;
                var m = DateTime.Now.Minute;
                var s = DateTime.Now.Second;
                var r = $"{data}{h}{m}{s}";
                sb.Append(r);
            }
        }
    }
}
