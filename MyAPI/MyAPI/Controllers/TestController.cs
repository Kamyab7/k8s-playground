using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("/Test")]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return Ok(_context.Messages.ToList());
        }
    }
}
