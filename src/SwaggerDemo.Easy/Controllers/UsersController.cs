using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Hard.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1", Deprecated = true)]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Pobiera użytkownika po id
        /// </summary>
        /// <param name="id">Id użytkownika</param>
        /// <response code="200">Zwraca znalezionego użytkownika</response>
        /// <response code="404">Nie znaleziono takiego użytkownika</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult GetById(int id)
        {
            User testUser = new User
            {
                Email = "test@example.com",
                Id = 1,
                Name = "Test"
            };

            return Ok(testUser);
        }

        /// <summary>
        /// Tworzy nowego użytkownika
        /// </summary>
        /// <param name="data">Dane użytkownika</param>
        /// <response code="200">Użytkownik został utworzony</response>
        [HttpPost]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult Create(User data)
        {
            return Ok(data);
        }

        /// <summary>
        /// Modyfikuje użytkownika o przekazanym id. Modyfikacji ulegają wszystkie pola oprócz hasła
        /// </summary>
        /// <param name="data">Dane użytkownika</param>
        /// <response code="200">Użytkownik został zmodyfikowany</response>
        /// <response code="403">Nie masz uprawnień do modyfikacji użytkownika</response>
        [HttpPost("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public IActionResult Modify([FromBody] User data)
        {
            return Ok(data);
        }
    }
}
