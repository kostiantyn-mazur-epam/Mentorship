using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFix
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = new List<Point>(Enumerable.Range(1, 10).Select(p => new Point()));
            foreach (var p in points)
            {
                p.IncX();
            }
            foreach (var p in points)
            {
                Console.WriteLine(p.X);
            }
            Console.ReadKey();
        }
    }

    public class Point
    {
        public int X;
        public void IncX()
        {
            X++;
        }
    }
}
