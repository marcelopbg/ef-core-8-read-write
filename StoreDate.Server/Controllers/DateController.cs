using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StoreDate.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext context = context;

        [HttpPost(Name = "GetUserClick")]
        public async Task<IActionResult> Post()
        {
            await context.Dates.AddAsync(new DateWrapper() { Date = DateTime.Now });
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet(Name = "GetLastLick")]
        public async Task<IActionResult> Get() {
            var result = await context.Dates.OrderByDescending(d => d.Id).FirstAsync();
            return Ok(result);
        }
    }
}
