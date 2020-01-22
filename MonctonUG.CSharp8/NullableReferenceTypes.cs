using System;

namespace MonctonUG.CSharp8
{
#nullable enable
    internal class NullableReferenceTypes
    {
        internal static void Run()
        {
            NullForgivingWrapper(null);
        }

        public static void WriteOutput(string value)
        {
            Console.WriteLine(value.ToUpper());
        }

        private static void NullForgivingWrapper(string? biglongnamesoyoucanseetheunderline)
        {
            WriteOutput(biglongnamesoyoucanseetheunderline!);

        }
    }
#nullable restore
}