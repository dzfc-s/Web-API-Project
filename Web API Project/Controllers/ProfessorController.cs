using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IUserService<Professor> _professorService;
        public ProfessorController(IUserService<Professor> professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("GetAllProfessors")]
        public async Task<ActionResult<List<Professor>>> GetAllProfessors()
        {
            var result = await _professorService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetProfessorById")]
        public async Task<ActionResult<Professor>> GetProfessorById(int id)
        {
            var result = await _professorService.GetUserById(id);
            if (result is null)
                return NotFound($"Professor with id {id} is not found!");
            return Ok(result);
        }

        [HttpPost("AddProfessor")]
        public async Task<ActionResult<List<Professor>>> AddProfessor(Professor professor)
        {
            var result = await _professorService.AddUser(professor);
            return Ok(result);
        }

        [HttpPut("UpdateProfessor")]
        public async Task<ActionResult<List<Professor>>> UpdateProfessor(int id, Professor request)
        {
            var result = await _professorService.UpdateUser(id, request);
            if (result is null)
                return NotFound($"Professor with id {id} is not found!");

            return Ok(result);
        }

        [HttpDelete("DeleteProfessor")]
        public async Task<ActionResult<List<Professor>>> DeleteProfessor(int id)
        {
            var result = await _professorService.DeleteUser(id);

            if (result is null)
                return NotFound($"Professor with id {id} is not found!");

            return Ok(result);
        }
    }
}
