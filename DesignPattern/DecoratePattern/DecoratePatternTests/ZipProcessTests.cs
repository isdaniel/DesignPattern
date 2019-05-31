using NUnit.Framework;
using ZipLib;
using System;
using System.Collections.Generic;
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
        public void Zip_RaedFile()
        {
            string filePath = @"test.zip";
            string except = $"你好 123456 12@()!@ {newline} fsfd嘻嘻哈哈!!";
            DecorateFactory factory = new DecorateFactory(new FileProcess());

            factory.SetProcess(new ZipProcess()
            {
                PassWord = "123456",
                FileName = "Hell.log"
            });

            IProcess process = factory.GetProcess();
            
            process.Write(filePath, Encoding.UTF8.GetBytes(except));
            byte[] buffer = process.Read(filePath);

            DeleteFile(filePath);
            string result = Encoding.UTF8.GetString(buffer);

            Assert.AreEqual(result, except);
        }
    }
}