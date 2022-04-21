using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using StringHelper;

namespace StrandedStringBuilder.Benchmarks
{
    public abstract class BenchmarkBase
    {
        public const int largeAppendCount = 6000;

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

        protected object[] AppendData => _appendData;


        protected StrandedStringBuilder.StringBuilder StrandedSb;
        protected MagicStringBuilder.MagicBuilder MagicSb;
        protected System.Text.StringBuilder SystemSb;

        [IterationSetup]
        public void Setup()
        {
            StrandedSb = GetLargeStrandedStringbuilder();
            MagicSb = GetLargeMagicStringbuilder();
            SystemSb = GetLargeSystemStringbuilder();
        }

        public StrandedStringBuilder.StringBuilder GetSmallStrandedStringbuilder()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            foreach (var item in _appendData)
                sb.Append(item);
            return sb;
        }

        public StrandedStringBuilder.StringBuilder GetLargeStrandedStringbuilder()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in _appendData)
                    sb.Append(item);
            return sb;
        }

        public MagicStringBuilder.MagicBuilder GetSmallMagicStringbuilder()
        {
            var sb = new MagicStringBuilder.MagicBuilder();
            foreach (var item in _appendData)
                sb.Append(item);
            return sb;
        }

        public MagicStringBuilder.MagicBuilder GetLargeMagicStringbuilder()
        {
            var sb = new MagicStringBuilder.MagicBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in _appendData)
                    sb.Append(item);
            return sb;
        }

        public LiteStringBuilder GetSmallLiteStringbuilder()
        {
            var sb = new LiteStringBuilder();
            foreach (var item in _appendData)
                sb.Append(item);
            return sb;
        }

        public LiteStringBuilder GetLargeLiteStringbuilder()
        {
            var sb = new LiteStringBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in _appendData)
                    sb.Append(item);
            return sb;
        }


        public System.Text.StringBuilder GetSmallSystemStringbuilder()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var item in _appendData)
                sb.Append(item);
            return sb;
        }

        public System.Text.StringBuilder GetLargeSystemStringbuilder()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < largeAppendCount; i++)
                foreach (var item in _appendData)
                    sb.Append(item);
            return sb;
        }
    }
}
