using Web_API_Project.Data;
using Web_API_Project.Interfaces;
using Web_API_Project.Models;

namespace Web_API_Project.Services.AssistantService
{
    public class AssistantService : IUserService<Assistant>
    {
        private readonly DataContext _context;

        public AssistantService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Assistant>> AddUser(Assistant assistant)
        {
            _context.Assistants.Add(assistant);

            await _context.SaveChangesAsync();

            return await _context.Assistants.ToListAsync();
        }


        public async Task<List<Assistant>?> DeleteUser(int id)
        {
            var assistant = await _context.Assistants.FindAsync(id);

            if (assistant is null)
                return null;

            _context.Assistants.Remove(assistant);

            await _context.SaveChangesAsync();

            return await _context.Assistants.ToListAsync();
        }

        public async Task<List<Assistant>> GetAllUsers()
        {
            var assistants = await _context.Assistants.ToListAsync();
            return assistants;
        }

        public async Task<Assistant?> GetUserById(int id)
        {
            var assistant = await _context.Assistants.FindAsync(id);

            if (assistant is null)
                return null;

            return assistant;
        }

        public async Task<List<Assistant>?> UpdateUser(int id, Assistant request)
        {
            var assistant = await _context.Assistants.FindAsync(id);

            if (assistant is null)
                return null;

            assistant.FirstName = (request.FirstName == "string" || request.FirstName == "") ? assistant.FirstName : request.FirstName;
            assistant.LastName = (request.LastName == "string" || request.LastName == "") ? assistant.LastName : request.LastName;
            assistant.WorkingYears = (request.WorkingYears == 0) ? assistant.WorkingYears : request.WorkingYears;
            assistant.SubjectTeaching = (request.SubjectTeaching == "string" || request.SubjectTeaching == "") ? assistant.SubjectTeaching : request.SubjectTeaching;

            await _context.SaveChangesAsync();

            return await _context.Assistants.ToListAsync();
        }
    }
}
