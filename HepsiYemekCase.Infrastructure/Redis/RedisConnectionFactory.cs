﻿using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace HepsiYemekCase.Infrastructure.Redis
{
    public class RedisConnectionFactory
    {
        static RedisConnectionFactory()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost:6379");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection => lazyConnection.Value;
        public static void DisposeConnection()
        {
            if (lazyConnection.Value.IsConnected)
            {
                lazyConnection.Value.Dispose();
            }
        }

    }
}
