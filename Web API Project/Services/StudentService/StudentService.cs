using Web_API_Project.Data;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Services.UserService
{
    public class StudentService : IUserService<Student>
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> AddUser(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }


        public async Task<List<Student>?> DeleteUser(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return null;

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>> GetAllUsers()
        {
            var students=await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student?> GetUserById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return null;

            return student;
        }

        public async Task<List<Student>?> UpdateUser(int id, Student request)
        {
            var student = await _context.Students.FindAsync(id);

            if (student is null)
                return null;

            student.FirstName = (request.FirstName == "string" || request.FirstName == "") ? student.FirstName : request.FirstName;
            student.LastName = (request.LastName == "string" || request.LastName == "") ? student.LastName : request.LastName;
            student.IndexNumber = (request.IndexNumber == "string" || request.IndexNumber == "") ? student.IndexNumber : request.IndexNumber;
            student.DateOfBirth = (request.DateOfBirth == DateTime.Today || request.DateOfBirth.ToString() == "") ? student.DateOfBirth: request.DateOfBirth;
            student.YearOfStudy = (request.YearOfStudy == 0 ) ? student.YearOfStudy : request.YearOfStudy;

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }
    }
}
