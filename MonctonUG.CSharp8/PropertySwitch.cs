using System;

namespace MonctonUG.CSharp8
{
    internal class PropertySwitch
    {
        internal static void Run()
        {
            var Fredericton = new Address { City = "Fredericton", Province = "NB", Postal = "E3A 0H1" };
            var Toronto = new Address { City = "Toronto", Province = "ON", Postal = "M4B 1B5" };

            decimal PriceWithTax(decimal price, Address addr) => addr switch
            {
                { Province: "ON" } => price * (decimal)1.13,
                { Province: "NB" } => price * (decimal)1.15,
                _ => throw new InvalidOperationException($"Unsupported province ({addr.Province})")
            };

            foreach (var addr in new Address[] { Fredericton, Toronto })
            {
                Console.WriteLine($"The final price in {addr.City}, {addr.Province} is {PriceWithTax(15, addr)}");
            }
        }
    }
}