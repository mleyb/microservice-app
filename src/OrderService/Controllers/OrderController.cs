using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderService.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post()
        {
            _logger.LogDebug("Publishing order event");

            MessageQueue.Publish(new OrderPlacedEvent());

            _logger.LogDebug("Order event published");
        }
    }
}
