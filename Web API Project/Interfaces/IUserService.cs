using Web_API_Project.Models;

namespace Web_API_Project.Interfaces
{
    public interface IUserService<T>
    {
        Task<List<T>> GetAllUsers();
        Task<T?> GetUserById(int id);
        Task<List<T>> AddUser(T user);
        Task<List<T>?> UpdateUser(int id, T request);
        Task<List<T>?> DeleteUser(int id);
    }
}
