using Web_API_Project.Data;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Services.ProfessorService
{
    public class ProfessorService : IUserService<Professor>
    {
        private readonly DataContext _context;

        public ProfessorService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> AddUser(Professor professor)
        {
            _context.Professors.Add(professor);

            await _context.SaveChangesAsync();

            return await _context.Professors.ToListAsync();
        }


        public async Task<List<Professor>?> DeleteUser(int id)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor is null)
                return null;

            _context.Professors.Remove(professor);

            await _context.SaveChangesAsync();

            return await _context.Professors.ToListAsync();
        }

        public async Task<List<Professor>> GetAllUsers()
        {
            var professors = await _context.Professors.ToListAsync();
            return professors;
        }

        public async Task<Professor?> GetUserById(int id)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor is null)
                return null;

            return professor;
        }

        public async Task<List<Professor>?> UpdateUser(int id, Professor request)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor is null)
                return null;

            professor.FirstName = (request.FirstName == "string" || request.FirstName == "") ? professor.FirstName : request.FirstName;
            professor.LastName = (request.LastName == "string" || request.LastName == "") ? professor.LastName : request.LastName;
            professor.WorkingYears = (request.WorkingYears == 0) ? professor.WorkingYears : request.WorkingYears;
            professor.SubjectTeaching = (request.SubjectTeaching == "string" || request.SubjectTeaching == "") ? professor.SubjectTeaching : request.SubjectTeaching;

            await _context.SaveChangesAsync();

            return await _context.Professors.ToListAsync();
        }
    }
}
