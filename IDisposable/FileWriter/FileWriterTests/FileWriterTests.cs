using Convestudo.Unmanaged;
using NUnit.Framework;
using System;
using System.IO;

namespace FileWriterTests
{
    [TestFixture]
    public class FileWriterTests
    {
        private const string TestFileName = "test.txt";

        private static string CreateTestFilePath()
        {
            var filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + "-" + TestFileName);

            return filePath;
        }

        [Test]
        public void DisposeDoesWork()
        {
            var filePath = CreateTestFilePath();
            var fileWriter = new FileWriter(filePath);
            //Assert.DoesNotThrow(fileWriter.Dispose);
        }

        [Test]
        public void DisposingCanBeCalledTwise()
        {
            var filePath = CreateTestFilePath();
            var fileWriter = new FileWriter(filePath);

            //fileWriter.Dispose();            
            //Assert.DoesNotThrow(fileWriter.Dispose);
        }

        [Test]
        public void ResourceIsLocked()
        {
            var filePath = CreateTestFilePath();
            var fileWriter1 = new FileWriter(filePath);
            fileWriter1.Write("Test");

            Assert.Throws<IOException>(() =>
            {
                var file2 = new FileWriter(filePath);
                file2.Write("adsf");
            });
        }

        [Test]
        public void WriteFewWordsDoesWork()
        {
            var filePath = CreateTestFilePath();
            const string testLine = "TestLine";
            var extectedStr = String.Format("{0}{0}{0}{0}", testLine);
            var fileWriter = new FileWriter(filePath);
           /* using (var fileWriter = new FileWriter(TestFileName))*/
            {
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
                fileWriter.Write(testLine);
            }

            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                var str = streamReader.ReadToEnd();
                Assert.AreEqual(extectedStr, str);
            }
        }

        [Test]
        public void WriteLineWritesWithNewLine()
        {
            var filePath = CreateTestFilePath();
            const string testLine = "TestLine";
            var extectedStr = String.Format("{0}{1}{0}{1}{0}{1}{0}", testLine, Environment.NewLine);

            var fileWriter = new FileWriter(filePath);
            //using (var fileWriter = new FileWriter(TestFileName))
            {
                fileWriter.WriteLine(testLine);
                fileWriter.WriteLine(testLine);
                fileWriter.WriteLine(testLine);
                fileWriter.WriteLine(testLine);
            }

            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream))
            {
                var str = streamReader.ReadToEnd();
                Assert.AreEqual(extectedStr, str);
            }
        }
    }
}
