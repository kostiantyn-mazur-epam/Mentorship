using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace Epam.Mentoring.MemoryManagement.Disposable.Tests
{
    [TestClass]
    public class FileWriterTests
    {
        private const string TestFileName = "test.txt";

        private static string CreateTestFilePath()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "-" + TestFileName);
        }

        [TestMethod]
        public void DisposeDoesWork()
        {
            var filePath = CreateTestFilePath();
            var fileWriter = new FileWriter(filePath);

            fileWriter.Dispose();
        }

        [TestMethod]
        public void DisposingCanBeCalledTwise()
        {
            var filePath = CreateTestFilePath();
            var fileWriter = new FileWriter(filePath);

            fileWriter.Dispose();            
        }

        [TestMethod]
        public void ResourceIsLocked()
        {
            var filePath = CreateTestFilePath();
            var fileWriter1 = new FileWriter(filePath);
            fileWriter1.Write("Test");

            Assert.ThrowsException<FileLoadException>(() =>
            {
                var file2 = new FileWriter(filePath);
                file2.Write("adsf");
            });
        }

        [TestMethod]
        public void WriteFewWordsDoesWork()
        {
            var filePath = CreateTestFilePath();
            const string testLine = "TestLine";
            var extectedStr = string.Format("{0}{0}{0}{0}", testLine);
            using (var fileWriter = new FileWriter(filePath))
            {
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
            }

            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
            {
                var str = streamReader.ReadToEnd();
                Assert.AreEqual(extectedStr, str);
            }
        }

        [TestMethod]
        public void WriteLineWritesWithNewLine()
        {
            var filePath = CreateTestFilePath();
            const string testLine = "TestLine";
            var extectedStr = string.Format("{0}{1}{0}{1}{0}{1}{0}", testLine, Environment.NewLine);

            using (var fileWriter = new FileWriter(filePath))
            {
                fileWriter.WriteLine(testLine);
                fileWriter.WriteLine(testLine);
                fileWriter.WriteLine(testLine);
                fileWriter.Write(testLine);
            }

            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.Unicode))
            {
                var str = streamReader.ReadToEnd();
                Assert.AreEqual(extectedStr, str);
            }
        }
    }
}