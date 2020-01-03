using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StrandedStringBuilder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "ABC".AsSpan();
            System.Console.WriteLine(s.ToString());
        }
    }
}
