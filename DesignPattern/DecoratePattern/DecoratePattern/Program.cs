using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ZipLib
{
    public interface IProcess
    {
        byte[] Read(string path);

        void Write(string writePath, byte[] buffer);
    }

    public abstract class ProcessBase : IProcess
    {
        /// <summary>
        /// 儲存被裝飾的物件
        /// </summary>
        protected IProcess _process;

        public abstract byte[] Read(string path);

        public abstract void Write(string writePath, byte[] buffer);

        public virtual void SetDecorated(IProcess process)
        {
            _process = process;
        }
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
        public string PassWord { get; set; }
        public string FileName { get; set; }


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
                zipStream.SetLevel(9); 

                ZipEntry newEntry = new ZipEntry(FileName);
                newEntry.DateTime = DateTime.Now;
                zipStream.Password = PassWord;
                zipStream.PutNextEntry(newEntry);

                StreamUtils.Copy(memStreamIn, zipStream, new byte[4096]);//將zip流搬到memoryStream中
                zipStream.CloseEntry();

                zipStream.IsStreamOwner = false;   
                zipStream.Close();                

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
                zip.Password = PassWord;
                using (MemoryStream streamWriter = new MemoryStream())
                {
                    byte[] bufferReader = new byte[4096];
                    var file = zip.GetEntry(FileName); //設置要去得的檔名
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

    /// <summary>
    /// Aes 加密裝飾器
    /// </summary>
    public class AESCrypProcess : ProcessBase
    {
        private AesCryptoServiceProvider aes;

        public string AESKey { get; set; } = "1776D8E110124E75";
        public string AESIV { get; set; } = "B890E7F6BA01C273";

        public AESCrypProcess() 
        {
            aes = new AesCryptoServiceProvider();
            aes.Key = Encoding.UTF8.GetBytes(AESKey);
            aes.IV = Encoding.UTF8.GetBytes(AESIV);
        }

        public override byte[] Read(string path)
        {
            byte[] encryptBytes = _process.Read(path);
            return DecryptData(encryptBytes);
        }

        /// <summary>
        /// 進行解密
        /// </summary>
        /// <param name="encryptBytes"></param>
        /// <returns></returns>
        private byte[] DecryptData(byte[] encryptBytes)
        {
            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream(encryptBytes))
            {
                using (CryptoStream decryptStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    MemoryStream outputStream = new MemoryStream();
                    decryptStream.CopyTo(outputStream);
                    outputBytes = outputStream.ToArray();
                }
            }
            return outputBytes;
        }

        /// <summary>
        /// 裝飾者呼叫方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public override void Write(string path, byte[] data)
        {
            byte[] outputBytes = EncryptData(data);
            _process.Write(path, outputBytes);
        }

        private byte[] EncryptData(byte[] data)
        {
            byte[] outputBytes = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream encryptStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    MemoryStream inputStream = new MemoryStream(data);
                    inputStream.CopyTo(encryptStream);
                    encryptStream.FlushFinalBlock();
                    outputBytes = memoryStream.ToArray();
                }
            }

            return outputBytes;
        }
    }

    public class DecorateFactory
    {
        IProcess _original;

        public DecorateFactory(IProcess original)
        {
            _original = original;
        }

        public DecorateFactory SetProcess(ProcessBase process)
        {
            process.SetDecorated(_original);
            _original = process;
            return this;
        }

        public IProcess GetProcess()
        {
            return _original;
        }
    }

    internal class Program
    {
        //public static Bitmap Watermark(Image srce, string text, Font font, float angle)
        //{
        //    Bitmap dest = new Bitmap(srce);
        //    var color = Color.FromArgb(120, Color.Black);
        //    using (var gr = Graphics.FromImage(dest))
        //    using (var gp = new GraphicsPath())
        //    using (var pen = new Pen(color, 5))
        //    {
        //        var sf = new StringFormat();
        //        sf.LineAlignment = sf.Alignment = StringAlignment.Center;
        //        gp.AddString(text, font.FontFamily, (int)font.Style, font.SizeInPoints,
        //            new Rectangle(-dest.Width / 2, -dest.Height / 2, dest.Width, dest.Height),
        //            sf);
        //        gr.TranslateTransform(dest.Width / 2, dest.Height / 2);
        //        gr.RotateTransform(-angle);
        //        gr.DrawPath(pen, gp);
        //    }
        //    return dest;
        //}

        //private static byte[] GetBuffer()
        //{
        //    using (FileStream fs = new FileStream(@"C:\Users\Daniel\Desktop\P.png", FileMode.Open))
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        Bitmap bitmap = new Bitmap(fs);
        //        bitmap = Watermark(bitmap, "DEMO", new Font(FontFamily.GenericSerif, 200), 45);
        //        bitmap.Save(ms, ImageFormat.Tiff);

        //        return ms.ToArray();
        //    }
        //}

        private static void Main(string[] args)
        {

            //內容
            string filePath = @"C:\test1.zip";
            string content = $"你好 123456 12@()!@ {Environment.NewLine} fsfd嘻嘻哈哈!!";
            //new FileProcess().Write(filePath, Encoding.UTF8.GetBytes(content));
            //設置初始化的被裝飾者
            DecorateFactory factroy = new DecorateFactory(new FileProcess());

            ////設置裝飾的順序
            factroy
                .SetProcess(new AESCrypProcess())
                .SetProcess(new ZipProcess() { FileName = "1.txt", PassWord = "12345" });

            IProcess process = factroy.GetProcess();

            byte[] data_buffer = Encoding.UTF8.GetBytes(content);
            process.Write(filePath, data_buffer);

            byte[] buffer = process.Read(filePath);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            Console.ReadKey();
        }
    }
}