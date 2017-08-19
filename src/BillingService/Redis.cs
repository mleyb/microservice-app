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
        void DoIt();
    }

    public class Redis : IRedis
    {
        private ILogger<Redis> _logger;

        public Redis(ILogger<Redis> logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
var dnsTask = Dns.GetHostAddressesAsync("redis");
var addresses = dnsTask.Result;
var connect = string.Join(",", addresses.Select(x => x.MapToIPv4().ToString() + ":" + "6379"));

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connect);
            IDatabase db = redis.GetDatabase();
            _logger.LogDebug(db.Ping().ToString());
        }
    }
}