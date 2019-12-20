using System;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class AppendTests
    {
        [Theory]
        [InlineData(new object[] { "A", "B", "C" }, "ABC")]
        [InlineData(new object[] { "A", 1, "C" }, "A1C")]
        [InlineData(new object[] { "A", true, "C" }, "ATrueC")]
        [InlineData(new object[] { 1.0, true, "C" }, "1TrueC")]
        [InlineData(new object[] { "A", "B", "C", "D" }, "ABCD")]
        [InlineData(new object[] { "A", "B", "C", "D", true }, "ABCDTrue")]
        public void Append(object[] data, string expectation)
        {
            var sb = new StringBuilder();
            foreach (var item in data)
                sb.Append(item);
            Assert.Equal(expectation, sb.ToString());
        }
    }
}
