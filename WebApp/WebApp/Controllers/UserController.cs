
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;
using WebApp.Validation;

namespace WebApp.Controllers
{
    [Authorize]
    [Route("user/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public readonly UserRepository userRepository;
        private IUserValidator userValidator;
        private IUserDelValidator userDelValidator;
        public UserController(IUserRepository userRepo,
          IUserValidator userValidator,
          IUserDelValidator userDelValidator)
        {
            this._userRepository = userRepo;
            this.userValidator = userValidator;
            this.userDelValidator = userDelValidator;
        }
        public UserController(UserRepository userRepository,
            IUserValidator userValidator,
            IUserDelValidator userDelValidator)
        {
            this.userRepository = userRepository;
            this.userValidator = userValidator;
            this.userDelValidator = userDelValidator;
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
            var validation = new OperationResult<UserModel>(userValidator.ValidateEntity(newUser));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            userRepository.Add(newUser);
            return NoContent();
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
            var request = new UserDeleteModel { Id = Id };
            var validation = new OperationResult<UserDeleteModel>(userDelValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            userRepository.Delete(Id);
            return NoContent();
        }
    }
}

