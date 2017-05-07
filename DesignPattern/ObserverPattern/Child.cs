using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Child
    {
        private List<IActionListener> _actions = new List<IActionListener>();

        public void AddActionListener(IList<IActionListener> e)
        {
            _actions.AddRange(e);
        }
        public void AddActionListener(IActionListener e) {
            _actions.Add(e);
        }
        public void weakup() {
            try
            {
                Thread.Sleep(5000);
                foreach (var action in _actions)
                {
                    action.ExcuteAction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
