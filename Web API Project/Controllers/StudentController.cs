using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUserService<Student> _studentService;
        public StudentController(IUserService<Student> studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var result = await _studentService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("GetStudentById")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var result = await _studentService.GetUserById(id);
            if (result is null)
                return NotFound($"Student with id {id} is not found!");
            return Ok(result);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            var result = await _studentService.AddUser(student);
            return Ok(result);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id, Student request)
        {
            var result = await _studentService.UpdateUser(id, request);
            if (result is null)
                return NotFound($"Student with id {id} is not found!");

            return Ok(result);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteUser(id);

            if (result is null)
                return NotFound($"Student with id {id} is not found!");

            return Ok(result);
        }
    }
}
