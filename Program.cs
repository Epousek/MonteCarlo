using System;

namespace MonteCarlo
{
    class Program
    {
        static double allHits = 100000000;
        static int a = 1;
        static int b = 3;
        static int maxY = 8;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Calculate();
        }

        static void Calculate()
        {
            OneVariableFunction f = TestFunction;
            double bigSurface = Math.Abs(a-b)*maxY;
            double smallSurface;
            double x;
            double y;
            double successfulHits = 0;
            double successfulHitsRatio;

            for (int i = 0; i < allHits; i++)
            {
                x = rnd.Next(a, b) + rnd.NextDouble();
                y = rnd.Next(maxY) + rnd.NextDouble();

                if (f(x) >= y)
                {
                    successfulHits++;
                }
                //Console.WriteLine($"x: {x}; y: {y}; f(x): {f(x)}; successful: {f(x) <= y}");
            }

            successfulHitsRatio = successfulHits / allHits;
            smallSurface = successfulHitsRatio * bigSurface;
            Console.WriteLine("All hits: " + allHits);
            Console.WriteLine("Successful hits: " + successfulHits);
            Console.WriteLine("Ratio: " + successfulHitsRatio);
            Console.WriteLine("Surface under function: " + smallSurface);
        }

        static double TestFunction(double x)
        {
            return Math.Pow(2, x);
        }
    }

    public delegate double OneVariableFunction(double x);
}
