using System;

namespace Vector_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //i love making colorful and descriptive interfaces
            //vector input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Input first vector. One value at a time!");
            Console.ForegroundColor = ConsoleColor.White;
            Vector test1 = new Vector(Convert.ToSingle(Console.ReadLine()), Convert.ToSingle(Console.ReadLine()), Convert.ToSingle(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Input second vector. One value at a time!");
            Console.ForegroundColor = ConsoleColor.White;
            Vector test2 = new Vector(Convert.ToSingle(Console.ReadLine()), Convert.ToSingle(Console.ReadLine()), Convert.ToSingle(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Input Scalar.");
            Console.ForegroundColor = ConsoleColor.White;
            float scalar = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("");

            //tests
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vector.Add: " + (test1 + test2) + " (v1 + v2)");
            Console.WriteLine("Vector.Subtract: " + (test1 - test2) + " (v1 - v2)");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Vector.Negate: " + (-test1) + " (v1 * -1)");
            Console.WriteLine("Vector.Scale: " + (test1 * scalar) + " (v1 * scalar)");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("GetMagnitude: " + test1.GetMagnitude);
            Console.WriteLine("GetDirection: " + test1.GetDirection);
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("DotProduct: " + Vector.DotProduct(test1, test2));
            Console.WriteLine("CrossProduct: " + Vector.CrossProduct(test1, test2));
            Console.WriteLine("AngleBetween (Rad): " + Vector.AngleBetween(test1, test2));
            Console.WriteLine("AngleBetween (Deg): " + (Vector.AngleBetween(test1, test2) / MathF.PI) * 180); // thank you braden
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vector.Normalize: " + Vector.Normalize(test1) + " (Product [Should be ~ 1]: " + Vector.Normalize(test1).GetMagnitude + ")");
            Console.WriteLine("Equal: " + (test1 == test2));
            Console.WriteLine("");


            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
