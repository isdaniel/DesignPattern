using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IToDoList toDo = new Project();

            toDo.Add(new ToDo() { Text = "test1" });
            toDo.Add(new ToDo() { Text = "test2" });

            var project = new Project();
            project.Add(new ToDo() { Text = "test222" });
            toDo.Add(project);
            Console.WriteLine(toDo.GetHtml());

            Console.ReadKey();
        }
    }

    public interface IToDoList{
        string GetHtml();

        void Add(IToDoList toDo);

        void Remove(IToDoList toDo);
    }

    public class Project : IToDoList
    {
        private List<IToDoList> _toDoList = new List<IToDoList>();

        public void Add(IToDoList toDo)
        {
            _toDoList.Add(toDo);
        }

        public string GetHtml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");

            foreach (var todo in _toDoList)
            {
                sb.AppendFormat("<li>{0}</li>", todo.GetHtml());
            }

            sb.AppendLine("</ul>");

            return sb.ToString();
        }

        public void Remove(IToDoList toDo)
        {
            _toDoList.Remove(toDo);
        }
    }

    public class ToDo : IToDoList {

        public string Text{ get; set; }

        public void Add(IToDoList toDo)
        {
            
        }

        public string GetHtml()
        {
            return Text;
        }

        public void Remove(IToDoList toDo)
        {
        }
    }
}
