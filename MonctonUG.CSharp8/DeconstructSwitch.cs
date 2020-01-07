using System;

namespace MonctonUG.CSharp8
{
    internal class DeconstructSwitch
    {
        internal static void Run()
        {
            Console.WriteLine(GetQuadrant((1, 1)));
            Console.WriteLine(GetQuadrant((1, -1)));
            Console.WriteLine(GetQuadrant((-1, 1)));
            Console.WriteLine(GetQuadrant((-1, -1)));
            Console.WriteLine(GetQuadrant(null));
        }

        static Quadrant GetQuadrant(Point? point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
    }
}