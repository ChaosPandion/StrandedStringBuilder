using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class InsertTests
    {
        [Theory]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 0, "ZZZAAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 1, "AZZZAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 2, "AAZZZABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 3, "AAAZZZBBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 4, "AAABZZZBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 5, "AAABBZZZBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 6, "AAABBBZZZCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 7, "AAABBBCZZZCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 8, "AAABBBCCZZZCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 9, "AAABBBCCCZZZDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 10, "AAABBBCCCDZZZDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "ZZZ", 11, "AAABBBCCCDDZZZD")]
        public void Insert(object[] appendData, string insertData, int index, string expectation)
        {
            var sb = new StringBuilder();
            foreach (var item in appendData)
                sb.Append(item);
            sb.Insert(index, insertData);
            Assert.Equal(expectation, sb.ToString());
        }
    }
}
