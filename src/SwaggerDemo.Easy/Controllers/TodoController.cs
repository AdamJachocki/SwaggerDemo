using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Hard.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class TodoController : ControllerBase
    {
        [HttpGet("user/{userId}")]
        public IActionResult GetItemsForUser(int userId)
        {
            if (userId == 0)
                return NotFound();

            if (userId < 0)
                return Forbid();

            TodoItem item = new TodoItem
            {
                User = new User { Id = userId }
            };

            return Ok(item);
        }
    }
}
