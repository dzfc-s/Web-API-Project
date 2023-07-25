using Web_API_Project.Models;

namespace Web_API_Project.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        List<User> AddUser(User user);
        List<User>? UpdateUser(int id, User request);
        List<User>? DeleteUser(int id);
    }
}
