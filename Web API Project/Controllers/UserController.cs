using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.Models;

namespace Web_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Selma", LastName = "Dzafic", Role = "Student"},
            new User { Id = 2, FirstName = "Nudzejm", LastName = "Delanovic", Role = "Student" }
        };

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
                return NotFound($"User with id {id} does not exist! ");
            return Ok(user);
        }
    }
}
