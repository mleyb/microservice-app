using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace BillingService
{
    public interface IRedis
    {
        void DoIt();
    }

    public class Redis : IRedis
    {
        public void DoIt()
        {
var dnsTask = Dns.GetHostAddressesAsync("redis");
var addresses = dnsTask.Result;
var connect = string.Join(",", addresses.Select(x => x.MapToIPv4().ToString() + ":" + "6379"));

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connect);
            IDatabase db = redis.GetDatabase();
        }
    }
}