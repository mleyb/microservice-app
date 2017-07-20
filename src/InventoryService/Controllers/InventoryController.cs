using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryService.Controllers
{
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private ILogger _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogDebug($"Call to InventoryController.Get() on {Environment.MachineName}");

            return $"Hello from InventoryService {Environment.MachineName}";
        }
    }
}
