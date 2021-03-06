using HepsiYemekCase.Infrastructure.Abstractions.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;


namespace HepsiYemekCase.Infrastructure.Redis
{
    public class RedisCache : ICache
    {
        private readonly IDatabase _redisDb;
        public RedisCache()
        {
            _redisDb = RedisConnectionFactory.Connection.GetDatabase();
        }
        public void Delete(string key)
        {
            _redisDb.KeyDelete(key);
        }

        public bool Exists(string key)
        {
            return _redisDb.KeyExists(key);
        }

        public T Get<T>(string key)
        {
            var redisObject = _redisDb.StringGet(key);
            return redisObject.HasValue ? JsonSerializer.Deserialize<T>(redisObject) : Activator.CreateInstance<T>();
        }

        public void Set<T>(string key, T obj, DateTime expireDate)
        {
            var expireTimeSpan = expireDate.Subtract(DateTime.Now);
            _redisDb.StringSet(key, JsonSerializer.Serialize(obj), expireTimeSpan);
        }
        public void Dispose()
        {
            RedisConnectionFactory.Connection.Dispose();
        }
    }
}
