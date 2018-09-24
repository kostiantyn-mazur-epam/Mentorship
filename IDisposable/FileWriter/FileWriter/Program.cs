using System;
using System.IO;

namespace Convestudo.Unmanaged
{
    class Program
    {
        private static void Main(string[] args)
        {
            var fileWriter = new FileWriter(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "-" + "log.txt"));

            fileWriter.Write("First test string");

            Console.ReadKey();
        }
    }
}
