using Microsoft.AspNetCore.Mvc;
using TennisBookings.Merchandise.Api.Models.Output;

namespace TennisBookings.Merchandise.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        [HttpGet("total")]
        public IActionResult GetStockTotal()
        {
            return Ok(new StockTotalOutputModel { StockItemTotal = 100});
        }
    }
}
