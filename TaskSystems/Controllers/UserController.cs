using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystems.Models;
using TaskSystems.Repositories.Interfaces;

namespace TaskSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);

            //return await _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var getUserById = await _userRepository.GetUserById(id);
            return Ok(getUserById);

            //return await _userRepository.GetUserById(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> InsertUser([FromBody] User user)
        {

            var newUser = await _userRepository.InsertUser(user);
            return newUser;
            //return await _userRepository.InsertUser(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            user.Id = id;
            var searchUser = await _userRepository.UpdateUser(user, id);
            return searchUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            bool apagado = await _userRepository.DeleteUser(id);
            return Ok(apagado);
        }
    }
}