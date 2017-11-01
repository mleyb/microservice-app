using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BillingService.Controllers
{
    [Route("[controller]")]
    public class BillingController : Controller
    {
        private readonly ILogger _logger;
        private readonly IRedis _redis;

        public BillingController(ILogger<BillingController> logger, IRedis redis)
        {
            _logger = logger;
            _redis = redis;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug($"Call to BillingController.Get() on {Environment.MachineName}");

            TimeSpan timeSpan = _redis.Ping();

            _logger.LogDebug($"Ping of Redis cache returned timespan {timeSpan}");

            return $"Hello from BillingService on {Environment.MachineName}";
        }
    }
}
