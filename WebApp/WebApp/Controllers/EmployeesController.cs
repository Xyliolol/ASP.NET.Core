
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [Authorize]
    [Route("employeer/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly EmployeerRepository employeerRepository;
       

        public EmployeesController(EmployeerRepository employeerRepository)
        {
            this.employeerRepository = employeerRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = employeerRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeerModel newEmployeer)

        {
            employeerRepository.Add(newEmployeer);
            return Ok(newEmployeer);
        }

        [HttpPut]
        public IActionResult Update([FromBody] EmployeerModel newEmployeer)

        {
            employeerRepository.Update(newEmployeer);
            return Ok(newEmployeer);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int Id)
        {
            employeerRepository.Delete(Id);
            return NoContent();
        }
    }
}
