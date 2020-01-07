using System;
using System.Collections.Generic;

namespace MonctonUG.CSharp8
{
    internal static class Ranges
    {
        internal static void Run()
        {
            var words = new string[]
            {
                // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0

            Console.WriteLine(String.Join(' ', words[2..4]));
            Console.WriteLine(String.Join(' ', words[^7..4]));
            Console.WriteLine(String.Join(' ', words[2..^5]));
            Console.WriteLine(String.Join(' ', words[^7..^5]));
            Console.WriteLine(String.Join(' ', words[7..]));
            Console.WriteLine(String.Join(' ', words[..4]));
            Console.WriteLine(String.Join(' ', words[^6]));

            if (words[1][^1] == 'k')
            {
                Console.WriteLine("Ends in 'k'");
            }

            List<string> numbers = new List<string> { "1", "2", "3", "4" };
            var twoThree = numbers.GetRange(1..^1);
            Console.WriteLine(String.Join(',', twoThree));
        }

        public static List<T> GetRange<T>(this List<T> src, Range range)
        {
            var offLen = range.GetOffsetAndLength(src.Count);
            return src.GetRange(offLen.Offset, offLen.Length);
        }
    }
}