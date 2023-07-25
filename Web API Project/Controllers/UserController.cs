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
            new User { Id = 2, FirstName = "Nudzejm", LastName = "Delanovic", Role = "Student" },
            new User { Id = 3, FirstName = "Denis", LastName = "Music", Role = "Professor" }
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

        [HttpPost("AddUser")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return NotFound($"User with id {id} does not exist! ");

            user.FirstName = (request.FirstName == "string" || request.FirstName == "") ? user.FirstName : request.FirstName;
            user.LastName = (request.LastName == "string" || request.LastName == "") ? user.LastName : request.LastName;
            user.Role = (request.Role == "string" || request.Role == "") ? user.Role : request.Role;

            return Ok(user);
            return Ok(users);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return NotFound($"User with id {id} does not exist! ");

            users.Remove(user);

            return Ok(users);
        }
    }
}
