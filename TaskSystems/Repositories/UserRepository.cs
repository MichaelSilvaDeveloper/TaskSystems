using Microsoft.EntityFrameworkCore;
using TaskSystems.Data;
using TaskSystems.Models;
using TaskSystems.Repositories.Interfaces;

namespace TaskSystems.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemsDBContext _dBContext;

        public UserRepository(TaskSystemsDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var searchUserById = await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado n banco de dados");
            return searchUserById;
        }

        public async Task<User> InsertUser(User user)
        {   
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            var searchUserById = await GetUserById(id);
            if (searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado n banco de dados");

            searchUserById.Name = user.Name;
            searchUserById.Email = user.Email;

            _dBContext.Users.Update(searchUserById);
            await _dBContext.SaveChangesAsync();

            return searchUserById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var searchUserById = await GetUserById(id);
            if (searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado n banco de dados");
            _dBContext.Users.Remove(searchUserById);
            await _dBContext.SaveChangesAsync();
            return true;
        }
    }   
}