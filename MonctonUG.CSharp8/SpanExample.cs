using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.CSharp8
{
    public static class SpanExample
    {
        public static void Run()
        {
            var startsWithT = "Test".AsSpan().StartsWith("T");
            var c = (new int[] { 1 }).AsSpan();
            var d = c.Slice(1, 1);
            Console.WriteLine($"Starts with T: {startsWithT}");
        }
    }
}
