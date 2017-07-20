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
        private ILogger _logger;

        public BillingController(ILogger<BillingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug($"Call to BillingController.Get() on {Environment.MachineName}");

            return $"Hello from BillingService on {Environment.MachineName}";
        }
    }
}
