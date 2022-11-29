using Model.Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cache
{
    public interface ICacheManager
    {
        void AddOrUpdate<T>(string key, T value);
        void Remove<T>(T item, string key);
        List<T> GetData<T>(string key);
    }
}
