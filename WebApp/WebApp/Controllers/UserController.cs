
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = userRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserModel newUser)

        {
            userRepository.Add(newUser);
            return Ok(newUser);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserModel newUser)

        {
            userRepository.Update(newUser);
            return Ok(newUser);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int Id)
        {
            userRepository.Delete(Id);
            return NoContent();
        }
    }
}

