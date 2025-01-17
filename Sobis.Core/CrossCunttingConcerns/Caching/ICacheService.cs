﻿namespace Sobis.Core.CrossCunttingConcerns.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool isAdded(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
