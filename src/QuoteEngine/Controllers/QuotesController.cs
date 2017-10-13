using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteEngine.ResourceAccessors;

namespace QuoteEngine.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private readonly IQueryRA queryRa;
        public QuotesController(IQueryRA queryRa)
        {
            this.queryRa = queryRa;
        }
        // GET api/values
        [HttpGet]
        public async Task<object[]> Get()
        {
            return await queryRa.GetAllAsync();
        }

        
    }
}
