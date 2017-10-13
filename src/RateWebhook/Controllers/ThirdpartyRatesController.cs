using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RateWebhook.Controllers
{
    [Route("api/[controller]")]
    public class ThirdpartyRatesController : Controller
    {
        private readonly ISendMessage sender;
        public ThirdpartyRatesController(ISendMessage sender)
        {
            this.sender = sender;
        }

        [HttpPost]
        public async Task Post([FromBody]object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return;

            await sender.Send(value.ToString());
        }
    }
}
