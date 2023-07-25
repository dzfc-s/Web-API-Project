using Web_API_Project.Models;

namespace Web_API_Project.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, FirstName = "Selma", LastName = "Dzafic", Role = "Student"},
            new User { Id = 2, FirstName = "Nudzejm", LastName = "Delanovic", Role = "Student" },
            new User { Id = 3, FirstName = "Denis", LastName = "Music", Role = "Professor" }
        };

        public List<User> AddUser(User user)
        {
            users.Add(user);
            return users;
        }

        public List<User>? DeleteUser(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            users.Remove(user);

            return users;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User? GetUserById(int id)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            return user;
        }

        public List<User>? UpdateUser(int id, User request)
        {
            var user = users.Find(x => x.Id == id);

            if (user is null)
                return null;

            user.FirstName = (request.FirstName == "string" || request.FirstName == "") ? user.FirstName : request.FirstName;
            user.LastName = (request.LastName == "string" || request.LastName == "") ? user.LastName : request.LastName;
            user.Role = (request.Role == "string" || request.Role == "") ? user.Role : request.Role;

            return users;

        }
    }
}
