using System;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class AppendTests
    {
        [Theory]
        [InlineData(new object[] { null, "B", "C" }, "BC")]
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

        [Theory]
        [InlineData(new object[] { null, "B", "C" }, "BC")]
        [InlineData(new object[] { "A", "B", "C" }, "ABC")]
        [InlineData(new object[] { "A", 1, "C" }, "A1C")]
        [InlineData(new object[] { "A", true, "C" }, "ATrueC")]
        [InlineData(new object[] { 1.0, true, "C" }, "1TrueC")]
        [InlineData(new object[] { "A", "B", "C", "D" }, "ABCD")]
        [InlineData(new object[] { "A", "B", "C", "D", true }, "ABCDTrue")]
        public void AppendMany(object[] data, string expectation)
        {
            var sb = new StringBuilder();
            sb.Append(data);
            Assert.Equal(expectation, sb.ToString());
        }

        [Fact]
        public void AppendLine()
        {

            var sb = new StringBuilder();
            sb.AppendLine(1);
            Assert.Equal("1\r\n", sb.ToString());
        }

        [Fact]
        public void AppendLine2()
        {

            var sb = new StringBuilder();
            sb.AppendLine(1);
            sb.AppendLine(2);
            Assert.Equal("1\r\n2\r\n", sb.ToString());
        }
    }
}
