using TaskSystems.Models;

namespace TaskSystems.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> InsertUser(User user);

        Task<User> UpdateUser(User user, int id);

        Task<bool> DeleteUser(int id);
    }
}