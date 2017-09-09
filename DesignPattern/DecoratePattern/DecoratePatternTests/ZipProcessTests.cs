using NUnit.Framework;
using ZipLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZipLib.Tests
{
    [TestFixture()]
    public class ZipProcessTests
    {
        private string newline = Environment.NewLine;

        private void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        [Test()]
        public void Zip_ReadFile()
        {
            string filePath = @"test.zip";
            string except = $"你好 123456 12@()!@ {newline} fsfd嘻嘻哈哈!!";
            IProcess process = new ZipProcess(new FileProcess(), "123456", "Hell.log");

            process.Write(filePath, Encoding.UTF8.GetBytes(except));
            byte[] buffer = process.Read(filePath);

            DeleteFile(filePath);
            string result = Encoding.UTF8.GetString(buffer);

            Assert.AreEqual(result, except);
        }
    }
}