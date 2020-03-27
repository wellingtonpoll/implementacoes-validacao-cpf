using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ValidacaoCpf
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Run();
            }
        }

        static void Run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Parallel.For(0, 1000000, (num, state) => {
                CpfFactory.CreateInstance("529.982.247-25");   
            });

            watch.Stop();
            Console.WriteLine($"Elapsed: {watch.Elapsed.Milliseconds} miliseconds");
        }
    }
}
