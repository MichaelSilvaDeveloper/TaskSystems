using Microsoft.EntityFrameworkCore;
using TaskSystems.Data;
using TaskSystems.Models;
using TaskSystems.Repositories.Interfaces;

namespace TaskSystems.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemsDBContext _dBContext;

        public TaskRepository(TaskSystemsDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Tarefas>> GetAllTasks()
        {
            return await _dBContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Tarefas> GetTaskById(int id)
        {
            var searchTaskById = await _dBContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (searchTaskById == null)
                throw new Exception($"Tarefa para o id: {id} não foi encontrado n banco de dados");
            return searchTaskById;

        }

        public async Task<Tarefas> InsertTask(Tarefas Tarefa)
        {
            await _dBContext.Tasks.AddAsync(Tarefa);
            await _dBContext.SaveChangesAsync();
            return Tarefa;    
        }

        public async Task<Tarefas> UpdateTask(Tarefas tarefa, int id)
        {
            var searchTaskById = await GetTaskById(id);
            if (searchTaskById == null)
                throw new Exception($"Tarefa para o id: {id} não foi encontrado n banco de dados");

            searchTaskById.Name = tarefa.Name;
            searchTaskById.Description = tarefa.Description;
            searchTaskById.Status = tarefa.Status;
            searchTaskById.UserId = tarefa.UserId;

            _dBContext.Tasks.Update(searchTaskById);
            await _dBContext.SaveChangesAsync();
            return searchTaskById;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var searchTaskById = await GetTaskById(id);
            if (searchTaskById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado n banco de dados");
            _dBContext.Tasks.Remove(searchTaskById);
            await _dBContext.SaveChangesAsync();
            return true;
        }
    }   
}