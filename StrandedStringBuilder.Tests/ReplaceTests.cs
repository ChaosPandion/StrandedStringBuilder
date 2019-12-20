using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class ReplaceTests
    {
        [Theory]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, "BBB", "ZZZ", "AAAZZZCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD", "BBB" }, "BBB", "ZZZ", "AAAZZZCCCDDDZZZ")]
        [InlineData(new[] { "AAB", "BBB", "BBC", "DDD", "BBB" }, "BBB", "ZZZ", "AAZZZZZZCDDDZZZ")]
        public void Replace(string[] appendData, string find, string replace, string expectation)
        {
            var sb = new StringBuilder();
            foreach (var item in appendData)
                sb.Append(item);
            sb.Replace(find, replace);
            Assert.Equal(expectation, sb.ToString());
        }
    }
}
