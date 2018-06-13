using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static Invoker invoker;
        static void Main(string[] args)
        {
            invoker = new Invoker();
            Console.WriteLine("請輸入 動作 1.新增日誌  2.調用目前記錄 3.刪除前一筆資料 其他任意按鈕離開");
  
            while (Invoke(Console.ReadKey(true).Key))
            {

            }
            Console.WriteLine("結束!");
        }

        static bool Invoke(ConsoleKey keyPress)
        {
            bool result = true;
            switch (keyPress)
            {
                case ConsoleKey.NumPad1:
                    string input = Console.ReadLine();
                    invoker.Add(new LogCommand(new KeyboradInfo() { Name = input, CreateDate = DateTime.Now }));
                    break;
                case ConsoleKey.NumPad2:
                    invoker.Excute();
                    break;
                case ConsoleKey.NumPad3:
                    invoker.UnExcute();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
    }

    public interface ICommand {
        void Excute();
        void UnExcute();
    }

    public class Invoker
    {
        private Stack<ICommand> _commandList = new Stack<ICommand>();

        public void Excute()
        {
            foreach (var command in _commandList)
            {
                command.Excute();
            }
        }

        public void Add(ICommand command)
        {
            _commandList.Push(command);
        }

        public void UnExcute() {
            ICommand current = _commandList.Pop();
            current.UnExcute();
        }
    }

    public class LogCommand : ICommand
    {
        public KeyboradInfo Info { get; set; }

        public LogCommand(KeyboradInfo _info) {
            Info = _info;
        }
        public void Excute() 
        {
            Console.WriteLine($"Create Date:{Info.CreateDate.ToLongTimeString()} Data:{Info.Name}");
        }

        public void UnExcute()
        {
            Console.WriteLine($"Data haskk Remove {Info.Name}");
        }
    }

    public class KeyboradInfo
    {

       public string Name { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
