using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiYemekCase.Infrastructure.Abstractions.Redis
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T obj, DateTime expireDate);
        void Delete(string key);
        bool Exists(string key);
    }
}
