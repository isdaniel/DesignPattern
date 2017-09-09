using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ZipLib
{
    public interface IProcess
    {
        byte[] Read(string path);

        void Write(string writePath, byte[] buffer);
    }

    public abstract class ProcessBase : IProcess
    {
        protected readonly IProcess _process;

        public ProcessBase(IProcess process)
        {
            _process = process;
        }

        public abstract byte[] Read(string path);

        public abstract void Write(string writePath, byte[] buffer);
    }

    /// <summary>
    /// 讀取檔案
    /// </summary>
    public class FileProcess : IProcess
    {
        public byte[] Read(string path)
        {
            return File.ReadAllBytes(path);
        }

        public void Write(string writePath, byte[] buffer)
        {
            File.WriteAllBytes(writePath, buffer);
        }
    }

    /// <summary>
    /// 讀取Zip使用
    /// </summary>
    public class ZipProcess : ProcessBase
    {
        private string _passWord;//= ConfigurationManager.AppSettings["password"];
        private string _fileName; //= ConfigurationManager.AppSettings["fileName"];

        public ZipProcess(IProcess process) : base(process)
        {
        }

        public ZipProcess(IProcess process, string password, string fileName) : base(process)
        {
            _passWord = password;
            _fileName = fileName;
        }

        public override byte[] Read(string path)
        {
            byte[] buffer = _process.Read(path);
            return ZipReader(path, buffer);
        }

        public override void Write(string writePath, byte[] data)
        {
            byte[] buffer = ZipWriter(data);
            _process.Write(writePath, buffer);
        }

        private byte[] ZipWriter(byte[] buffer)
        {
            using (MemoryStream outputMemStream = new MemoryStream())
            using (ZipOutputStream zipStream = new ZipOutputStream(outputMemStream))
            using (MemoryStream memStreamIn = new MemoryStream(buffer))
            {
                zipStream.SetLevel(9); //0-9, 9 being the highest level of compression

                ZipEntry newEntry = new ZipEntry(_fileName);
                newEntry.DateTime = DateTime.Now;
                zipStream.Password = _passWord;
                zipStream.PutNextEntry(newEntry);

                StreamUtils.Copy(memStreamIn, zipStream, new byte[4096]);//將zip流搬到memoryStream中
                zipStream.CloseEntry();

                zipStream.IsStreamOwner = false;   // False stops the Close also Closing the underlying stream.
                zipStream.Close();                 // Must finish the ZipOutputStream before using outputMemStream.

                return outputMemStream.ToArray();
            }
        }

        /// <summary>
        /// 讀取zip檔
        /// </summary>
        /// <param name="buffer">zip檔案byte</param>
        /// <returns></returns>
        private byte[] ZipReader(string filePath, byte[] buffer)
        {
            byte[] zipBuffer = default(byte[]);
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var zip = new ZipFile(memoryStream);
                zip.Password = _passWord;
                using (MemoryStream streamWriter = new MemoryStream())
                {
                    byte[] bufferReader = new byte[4096];
                    var file = zip.GetEntry(_fileName); //設置要去得的檔名
                    //如果有檔案
                    if (file != null)
                    {
                        var zipStream = zip.GetInputStream(file);
                        StreamUtils.Copy(zipStream, streamWriter, bufferReader);
                        zipBuffer = streamWriter.ToArray();
                    }
                }
            }
            return zipBuffer;
        }
    }

    internal class Program
    {
        private static string newline = Environment.NewLine;

        private static void Main(string[] args)
        {
            string filePath = @"C:\Users\dog83\Desktop\test.zip";
            string content = $"你好 123456 12@()!@ {newline} fsfd嘻嘻哈哈!!";
            //string filePath = @"C:\Users\dog83\Desktop\view123.zip";
            //IProcess process = new ZipProcess(new FileProcess());
            //string content = "Hello Zip";
            IProcess process = new ZipProcess(new FileProcess());
            process.Write(filePath, Encoding.UTF8.GetBytes(content));
            byte[] buffer = process.Read(filePath);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            Console.ReadKey();
        }
    }
}