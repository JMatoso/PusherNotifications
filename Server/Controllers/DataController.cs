using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class DataController : ControllerBase
    {
        private PushService pusher;
        public DataController()
        {
            pusher = new();
        }

        [HttpPost("message/{value}")]
        public async Task<ActionResult> SendMessage(string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                await pusher.Send(value);
                return Ok("Your message has been sent.");
            }

            return BadRequest("Do not send a empty message!");
        }
    }
}