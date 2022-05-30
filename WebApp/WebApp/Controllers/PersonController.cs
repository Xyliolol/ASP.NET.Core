
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;
using WebApp.Validation;

namespace WebApp.Controllers
{
    [Authorize]
    [Route("person/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly PersonRepository personRepository;
        private IPersonValidator personValidator;
        private IPersDelValidator personDelValidator;
        public PersonController(PersonRepository personRepository,
            IPersonValidator personValidator,
             IPersDelValidator personDelValidator)
        {
            this.personRepository = personRepository;
            this.personValidator = personValidator;
            this.personDelValidator = personDelValidator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = personRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonModel newPerson)

        {
            var validation = new OperationResult<PersonModel>(personValidator.ValidateEntity(newPerson));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            personRepository.Add(newPerson);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonModel newPerson)

        {
            personRepository.Update(newPerson);
            return Ok(newPerson);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int Id)
        {
            var request = new PersonDeleteModel { Id = Id };
            var validation = new OperationResult<PersonDeleteModel>(personDelValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            personRepository.Delete(Id);
            return NoContent();
        }
    }
}

