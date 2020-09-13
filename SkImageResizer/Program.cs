using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SkImageResizer
{
    class Program
    {
        static readonly Stopwatch sw = new Stopwatch();

        static async Task Main(string[] args)
        {
            var imageProcess = new SKImageProcess();
            var sourcePath = Path.Combine(Environment.CurrentDirectory, "images");
            var destinationPath1 = Path.Combine(Environment.CurrentDirectory, "output1");
            var destinationPath2 = Path.Combine(Environment.CurrentDirectory, "output2");

            // Sync

            imageProcess.Clean(destinationPath1);

            sw.Start();
            imageProcess.ResizeImages(sourcePath, destinationPath1, 2.0);
            sw.Stop();

            decimal result1 = sw.ElapsedMilliseconds;
            Console.WriteLine($"同步執行花費時間: {result1} ms");

            // Async

            imageProcess.Clean(destinationPath2);

            sw.Restart();

            try
            {
                await imageProcess.ResizeImagesAsync(sourcePath, destinationPath2, 2.0);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Canceled: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception:{ex}");
            }

            sw.Stop();

            decimal result2 = sw.ElapsedMilliseconds;
            Console.WriteLine($"非同步的花費時間: {result2} ms");

            // Result
            // 效能提升比例公式：((Orig - New) / Orig) * 100%

            var result = ((result1 - result2) / result1) * 100;
            Console.WriteLine($"效能提升 {result:f2}%");
        }
    }
}
