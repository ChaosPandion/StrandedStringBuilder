using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class ClearTests
    {
        [Fact]
        public void Clear()
        {
            var sb = new StrandedStringBuilder.StringBuilder();
            sb.Append(123);
            sb.Clear();
            Assert.Equal("", sb.ToString());
        }
    }
}
