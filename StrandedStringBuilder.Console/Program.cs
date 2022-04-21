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
            var x = new StrandedStringBuilder.StringBuilder();
            x.Append("A");
            x.Append("B");
            x.Append("C");  
            x.Append("D");
            x.Append(() => "A" + "B" + "C" + "D");
            System.Console.WriteLine(x.ToString());
        }
    }
}
