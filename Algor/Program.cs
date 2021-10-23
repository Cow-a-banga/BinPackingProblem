using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace BinPackingProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            var writer = new StreamWriter("output.csv");
            var generator = new TestGenerator();
            var capacity = 100;
            var count = 5;

            for (int i = 0; i < 300; i++)
            {
                if (i == 100 || i == 200)
                    count += 3;
                
                var input = generator.Generate(count, capacity);

                var brudeforce = new BruteForceAlgorithm();
                var ffs = new FFSAlgorithm();
                var bf = new BFAlgorithm();

                var timer = Stopwatch.StartNew();
                var resBF = bf.Pack(input);
                var timeBF = timer.Elapsed;

                timer.Restart();
                var resFFS = ffs.Pack(input);
                var timeFFS = timer.Elapsed;

                timer.Restart();
                var resBrude = brudeforce.Pack(input);
                var timeBrude = timer.Elapsed;
                timer.Stop();

                writer.WriteLine($"{capacity},{count},{timeBF.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)}," +
                                  $"{resBF.ContainersNum},{timeFFS.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)}," +
                                  $"{resFFS.ContainersNum},{timeBrude.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)},{resBrude.ContainersNum}");
            }
            
            writer.Close();
        }
    }
}