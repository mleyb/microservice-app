using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace BillingService
{
    public interface IRedis
    {
        TimeSpan Ping();
    }

    public class Redis : IRedis
    {
        private static readonly Lazy<ConnectionMultiplexer> _connection;

        static Redis()
        {
            string connectionString = GetConnectionString();

            _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionString));
        }

        public TimeSpan Ping()
        {
            IDatabase db = GetConnection().GetDatabase();

            return db.Ping();
        }

        private static ConnectionMultiplexer GetConnection() => _connection.Value;

        private static string GetConnectionString()
        {
            IPAddress[] addresses = Dns.GetHostAddressesAsync("redis").Result;
            
            string connectionString = String.Join(",", addresses.Select(x => x.MapToIPv4().ToString() + ":" + "6379"));
        
            return connectionString;
        }
    }
}