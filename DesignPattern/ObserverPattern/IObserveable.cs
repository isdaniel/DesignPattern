using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    /// <summary>
    /// 被觀察介面
    /// </summary>
    public interface IObserveable
    {
        void AddsubScription(IObservea observea);
        void Remove(IObservea observea);
        void Notify(string message);
    }

    /// <summary>
    /// 更新訊息
    /// </summary>
    public interface IObservea
    {
        void Update(string message);
    }

}
