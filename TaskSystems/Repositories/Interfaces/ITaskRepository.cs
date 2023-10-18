using TaskSystems.Models;

namespace TaskSystems.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Tarefas>> GetAllTasks();

        Task<Tarefas> GetTaskById(int id);

        Task<Tarefas> InsertTask(Tarefas tarefas);

        Task<Tarefas> UpdateTask(Tarefas tarefas, int id);

        Task<bool> DeleteTask(int id);
    }
}