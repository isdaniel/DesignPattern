using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Youtuber : IObserveable
    {
        List<IObservea> _observeaList = new List<IObservea>();

        /// <summary>
        /// 訂閱
        /// </summary>
        /// <param name="observea"></param>
        public void AddsubScription(IObservea observea)
        {
            _observeaList.Add(observea);
        }

        /// <summary>
        /// 移除訂閱
        /// </summary>
        /// <param name="observea"></param>
        public void Remove(IObservea observea)
        {
            _observeaList.Remove(observea);
        }

        public void Notify(string notifyMessage)
        {
            foreach (var observea in _observeaList)
            {
                observea.Update(notifyMessage);
            }
        }

        public int GetSubScriptCount()
        {
            return _observeaList.Count;
        }
    }
}
