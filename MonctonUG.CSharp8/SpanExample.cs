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
            var startsWithT = "Test".AsSpan(2, 3).StartsWith("T");
            var c = (new int[] { 1, 2, 3, 4 }).AsSpan();
            var d = c.Slice(1, 1);
            d[0] = 5;
            Console.WriteLine($"Starts with T: {startsWithT}");
        }
    }
}
