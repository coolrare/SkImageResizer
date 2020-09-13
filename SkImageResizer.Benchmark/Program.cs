using System;
using BenchmarkDotNet.Running;

namespace SkImageResizer.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SkImageResizerBenchmark>();
        }
    }
}