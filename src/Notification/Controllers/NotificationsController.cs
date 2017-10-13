using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
