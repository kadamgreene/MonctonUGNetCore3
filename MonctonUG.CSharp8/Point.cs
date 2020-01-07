﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonctonUG.CSharp8
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Deconstruct(out int x, out int y) =>
        (x, y) = (X, Y);

        public static implicit operator Point((int x, int y) src) => new Point(src.x, src.y);
    }
}
