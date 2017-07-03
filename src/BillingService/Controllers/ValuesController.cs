using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BillingService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug($"Call to BillingService.Controllers.ValuesController.Get() on {Environment.MachineName}");

            return $"Hello from {Environment.MachineName}";
        }
    }
}
