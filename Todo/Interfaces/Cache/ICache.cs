using System;

namespace Todo.Interfaces.Cache
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expiration);
        void Remove(string key);
    }
}
