using System;
using System.IO;

namespace Epam.Mentoring.MemoryManagement.Disposable
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "-" + "log.txt");

            using (var fileWriter = new FileWriter(filePath))
            {
                fileWriter.Write("First test string");

                Console.WriteLine($"'First test string' -> '{filePath}'");
                Console.ReadKey();
            }
        }
    }
}