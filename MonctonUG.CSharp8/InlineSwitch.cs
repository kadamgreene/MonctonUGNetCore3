using System;

namespace MonctonUG.CSharp8
{
    internal class InlineSwitch
    {
        internal static void Run()
        {
            Console.WriteLine(FromRainbow(Colors.Orange));
        }

        public static RGBColor FromRainbow(Colors color) => color switch
        {
            Colors.Red => new RGBColor(0xFF, 0x00, 0x00),
            Colors.Orange => new RGBColor(0xFF, 0x7F, 0x00),
            Colors.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
            Colors.Green => new RGBColor(0x00, 0xFF, 0x00),
            Colors.Blue => new RGBColor(0x00, 0x00, 0xFF),
            Colors.Indigo => new RGBColor(0x4B, 0x00, 0x82),
            Colors.Violet => new RGBColor(0x94, 0x00, 0xD3),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(color)),
        };
    }
}