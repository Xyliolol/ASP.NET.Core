
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [Route("person/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
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
            personRepository.Add(newPerson);
            return Ok(newPerson);
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
            personRepository.Delete(Id);
            return NoContent();
        }
    }
}

