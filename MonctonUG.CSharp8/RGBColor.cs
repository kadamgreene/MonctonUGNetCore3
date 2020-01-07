using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.CSharp8
{
    public struct RGBColor
    {
        public readonly int Red;
        public readonly int Green;
        public readonly int Blue;

        public RGBColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public override string ToString()
        {
            return $"R: {Red:X}, G: {Green:X}, B: {Blue:X}";
        }
    }
}
