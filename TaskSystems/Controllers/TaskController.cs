using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystems.Models;
using TaskSystems.Repositories.Interfaces;

namespace TaskSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarefas>>> ListarTodasTarefas()
        {
            var tarefas = await _taskRepository.GetAllTasks();
            return Ok(tarefas);

            //return await _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefas>> GetTaskById(int id)
        {
            var getTaskById = await _taskRepository.GetTaskById(id);
            return Ok(getTaskById);

            //return await _userRepository.GetUserById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Tarefas>> InsertTask([FromBody] Tarefas tarefas)
        {
            var newTask = await _taskRepository.InsertTask(tarefas);
            return newTask;
            //return await _userRepository.InsertUser(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tarefas>> UpdateTask(int id, [FromBody] Tarefas tarefas)
        {
            tarefas.Id = id;
            var searchTask = await _taskRepository.UpdateTask(tarefas, id);
            return searchTask;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefas>> DeleteTask(int id)
        {
            bool apagado = await _taskRepository.DeleteTask(id);
            return Ok(apagado);
        }
    }
}