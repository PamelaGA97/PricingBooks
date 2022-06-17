using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;

namespace PricingBooks.Controllers
{
    [Route("price-management")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private PriceManager _priceManager;
        public PriceController(PriceManager priceManager)
        {
            _priceManager = priceManager;
        }

        [HttpGet]
        [Route("prices")]
        public IActionResult GetPrices()
        {
            return Ok(_priceManager.GetPrices());
        }
    }
}

