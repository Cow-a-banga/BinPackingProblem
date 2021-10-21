using System;
using System.Linq;

namespace Algor
{
    class Program
    {
        static void Main(string[] args)
        {

            TestGenerator generator = new TestGenerator();

            var input = generator.Generate(10, 50);

            var alg = new BruteForceAlgorithm();
            var res = alg.Pack(input);
            
            Console.WriteLine(string.Join("\n", input.Things.Select(t=>$"{t.id}  {t.Mass}")));
            Console.WriteLine();
            Console.WriteLine(string.Join("\n", res.ThingsInContainers.Select(c => string.Join(" ", c))));
        }
    }
}