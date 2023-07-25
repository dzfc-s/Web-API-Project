using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.Models;
using Web_API_Project.Services.UserService;

namespace Web_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = _userService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            if(result is null)
                return NotFound($"User with id {id} is not found!");
            return Ok(result);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var result = _userService.AddUser(user);
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = _userService.UpdateUser(id, request);
            if (result is null)
                return NotFound($"User with id {id} is not found!");

            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);

            if (result is null)
                return NotFound($"User with id {id} is not found!");

            return Ok(result);
        }
    }
}
