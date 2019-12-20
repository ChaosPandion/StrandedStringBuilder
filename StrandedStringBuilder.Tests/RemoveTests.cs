using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StrandedStringBuilder.Tests
{
    public class RemoveTests
    {
        [Theory]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 1, "AABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 2, "ABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 3, "BBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 4, "BBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 5, "BCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 6, "CCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 7, "CCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 8, "CDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 9, "DDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 10, "DD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 11, "D")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 12, "")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 1, "AABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 2, "ABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 3, "ABBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 4, "ABCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 5, "ACCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 6, "ACCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 7, "ACDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 8, "ADDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 9, "ADD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 10, "AD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 1, 11, "A")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 1, "AABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 2, "AABBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 3, "AABCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 4, "AACCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 5, "AACCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 6, "AACDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 7, "AADDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 8, "AADD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 9, "AAD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 2, 10, "AA")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 1, "AAABBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 2, "AAABCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 3, "AAACCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 4, "AAACCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 5, "AAACDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 6, "AAADDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 7, "AAADD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 8, "AAAD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 3, 9, "AAA")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 1, "AAABBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 2, "AAABCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 3, "AAABCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 4, "AAABCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 5, "AAABDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 6, "AAABDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 7, "AAABD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 4, 8, "AAAB")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 1, "AAABBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 2, "AAABBCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 3, "AAABBCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 4, "AAABBDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 5, "AAABBDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 6, "AAABBD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 5, 7, "AAABB")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 1, "AAABBBCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 2, "AAABBBCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 3, "AAABBBDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 4, "AAABBBDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 5, "AAABBBD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 6, 6, "AAABBB")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 1, "AAABBBCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 2, "AAABBBCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 3, "AAABBBCDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 4, "AAABBBCD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 7, 5, "AAABBBC")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 8, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 8, 1, "AAABBBCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 8, 2, "AAABBBCCDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 8, 3, "AAABBBCCD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 8, 4, "AAABBBCC")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 9, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 9, 1, "AAABBBCCCDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 9, 2, "AAABBBCCCD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 9, 3, "AAABBBCCC")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 10, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 10, 1, "AAABBBCCCDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 10, 2, "AAABBBCCCD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 11, 0, "AAABBBCCCDDD")]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 11, 1, "AAABBBCCCDD")]
        public void RemoveSuccess(string[] append, int index, int length, string expectation)
        {
            var sb = new StringBuilder();
            foreach (var item in append)
                sb.Append(item);
            sb.Remove(index, length);
            Assert.Equal(expectation, sb.ToString());
        }

        [Theory]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, -1, 0)]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, -1)]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 13, 1)]
        [InlineData(new[] { "AAA", "BBB", "CCC", "DDD" }, 0, 13)]
        public void RemoveFailure(string[] append, int index, int length)
        {
            var sb = new StringBuilder();
            foreach (var item in append)
                sb.Append(item);
            Assert.Throws<ArgumentOutOfRangeException>(() => sb.Remove(index, length));
        }
    }
}
