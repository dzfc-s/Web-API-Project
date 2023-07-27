using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        private readonly IUserService<Assistant> _assistantService;
        public AssistantController(IUserService<Assistant> assistantService)
        {
            _assistantService = assistantService;
        }

        [HttpGet("GetAllAssistants")]
        public async Task<ActionResult<List<Assistant>>> GetAllAssistants()
        {
            var result = await _assistantService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetAssistantById")]
        public async Task<ActionResult<Assistant>> GetAssistantById(int id)
        {
            var result = await _assistantService.GetUserById(id);
            if (result is null)
                return NotFound($"Assistant with id {id} is not found!");
            return Ok(result);
        }

        [HttpPost("AddAssistant")]
        public async Task<ActionResult<List<Assistant>>> AddAssistant(Assistant assistant)
        {
            var result = await _assistantService.AddUser(assistant);
            return Ok(result);
        }

        [HttpPut("UpdateAssistant")]
        public async Task<ActionResult<List<Assistant>>> UpdateAssistant(int id, Assistant request)
        {
            var result = await _assistantService.UpdateUser(id, request);
            if (result is null)
                return NotFound($"Assistant with id {id} is not found!");

            return Ok(result);
        }

        [HttpDelete("DeleteAssistant")]
        public async Task<ActionResult<List<Assistant>>> DeleteAssistant(int id)
        {
            var result = await _assistantService.DeleteUser(id);

            if (result is null)
                return NotFound($"Assistant with id {id} is not found!");

            return Ok(result);
        }
    }
}
