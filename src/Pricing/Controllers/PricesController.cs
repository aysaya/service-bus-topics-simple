using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Pricing.Controllers
{
    [Route("api/[controller]")]
    public class PricesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
